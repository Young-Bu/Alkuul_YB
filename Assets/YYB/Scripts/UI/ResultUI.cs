using UnityEngine;
using Alkuul.Domain;

namespace Alkuul.UI
{
    public class ResultUI : MonoBehaviour
    {
        public void ShowDrinkResult(DrinkResult r)
            => Debug.Log($"Drink ▶ 만족도 {r.satisfaction}% / 팁 {r.tip} / 떠남 {r.customerLeft}");

        public void ShowCustomerResult(CustomerResult c)
            => Debug.Log($"Customer ▶ 평균 {c.averageSatisfaction:F1}% / 평판Δ {c.reputationDelta:+0.00;-0.00}");
    }
}
