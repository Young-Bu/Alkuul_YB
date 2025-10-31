using UnityEngine;
using System.Collections.Generic;
using Alkuul.Domain;
using Alkuul.Systems;

namespace Alkuul.UI
{
    /// <summary>���� �Է�/���ð��� Systems�� �����ϴ� UI</summary>
    public class BrewingUI : MonoBehaviour
    {
        [SerializeField] private BrewingSystem brewing;
        [SerializeField] private ServeSystem serve;

        [Header("Selections")]
        [SerializeField] private TechniqueSO technique;
        [SerializeField] private GlassSO glass;
        [SerializeField] private List<GarnishSO> garnishes = new();
        [SerializeField] private bool useIce;

        public void OnAdd(IngredientSO ingredient, float ml)
        {
            if (ingredient == null) return;
            brewing.Add(ingredient, ml);
        }

        public void OnToggleIce(bool v) => useIce = v;

        public void OnSubmit(Order order, string majorEmotionTag)
        {
            Drink d = brewing.Compute(useIce);
            var meta = ServeSystem.Meta.From(technique, glass, garnishes, useIce, majorEmotionTag);
            var r = serve.ServeOne(order, d, meta);
            Debug.Log($"������: {r.satisfaction:F1}% | ��: {r.tip} | ����: {r.customerLeft}");
        }

        public void ResetUI()
        {
            useIce = false;
            garnishes.Clear();
            brewing.ResetMix();
        }
    }
}

