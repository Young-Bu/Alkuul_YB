using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alkuul.Domain
{
    [CreateAssetMenu(menuName = "Alkuul/Ingredient")]
    public class IngredientSO : ScriptableObject
    {
        public string id, displayName;
        public float abv;                // ����(%)
        public EmotionVector emotions;   // ���� �⿩(ml ���)
        public Sprite icon;
    }
}

