using UnityEngine;
using System.Linq;
using Alkuul.Domain;
using Alkuul.Core;

namespace Alkuul.Systems
{
    /// <summary>한 잔 평가(감정 일치 + 태그/얼음 보정)</summary>
    [CreateAssetMenu(menuName = "Alkuul/ScoringService")]
    public sealed class ScoringService : ScriptableObject
    {
        [Header("Bonuses")]
        public float techniqueMatch = 5f;
        public float glassMatch = 5f;
        public float garnish1 = 5f, garnish2 = 3f, garnish3 = 2f;
        public float iceLike = 15f, iceDislike = -10f;
        public float lowLeaveThresh = 40f;

        public DrinkResult Evaluate(Order o, Drink d, ServeSystem.Meta meta)
        {
            // 기본 일치율: L1 거리(0~2)를 0~100으로 매핑
            //float match = 100f - 100f * (VectorOps.L1(o.targetEmotions, d.emotions) * 0.5f);
            float match = 100f * VectorOps.Overlap(o.targetEmotions, d.emotions);

            float bonus = 0f;
            if (meta.techniqueTags?.Contains(meta.majorEmotionTag) == true) bonus += techniqueMatch;
            if (meta.glassTags?.Contains(meta.majorEmotionTag) == true) bonus += glassMatch;

            int m = meta.garnishTags?.Count(t => t == meta.majorEmotionTag) ?? 0;
            if (m >= 1) bonus += garnish1; if (m >= 2) bonus += garnish2; if (m >= 3) bonus += garnish3;

            if (meta.iceLiked) bonus += iceLike;
            if (meta.iceDisliked) bonus += iceDislike;

            float satisfaction = Mathf.Clamp(match + bonus, 0f, 100f);
            int tip = Mathf.FloorToInt(10f * Mathf.Pow(satisfaction / 100f, 2f));

            return new DrinkResult { satisfaction = satisfaction, tip = tip, customerLeft = satisfaction < lowLeaveThresh };
        }
    }
}
