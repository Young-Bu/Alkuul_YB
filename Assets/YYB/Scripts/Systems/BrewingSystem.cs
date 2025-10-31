using UnityEngine;
using System.Collections.Generic;
using Alkuul.Domain;
using Alkuul.Core;

namespace Alkuul.Systems
{
    /// <summary>���� �Է� ���� �� Drink ���</summary>
    public sealed class BrewingSystem : MonoBehaviour
    {
        private readonly List<Portion> _parts = new();

        public void ResetMix() => _parts.Clear();

        public void Add(IngredientSO ing, float ml)
        {
            if (ing == null || ml <= 0f) return;
            _parts.Add(new Portion { ingredient = ing, ml = ml });
        }

        public Drink Compute(bool useIce20ml)
        {
            float total = 0f, abvSum = 0f;
            EmotionVector sum = default;

            foreach (var p in _parts)
            {
                total += p.ml;
                abvSum += p.ingredient.abv * p.ml;
                sum = VectorOps.AddWeighted(sum, p.ingredient.emotions, p.ml);
            }

            if (useIce20ml) total += 20f; // ��(����0/����0)
            float finalABV = (total > 0f) ? abvSum / total : 0f;

            return new Drink
            {
                portions = new List<Portion>(_parts),
                emotions = VectorOps.Normalize(sum),
                finalABV = finalABV
            };
        }
    }
}

