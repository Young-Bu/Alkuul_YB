using UnityEngine;
using Alkuul.Domain;

namespace Alkuul.UI
{
    public class ResultUI : MonoBehaviour
    {
        public void ShowDrinkResult(DrinkResult r)
            => Debug.Log($"Drink �� ������ {r.satisfaction}% / �� {r.tip} / ���� {r.customerLeft}");

        public void ShowCustomerResult(CustomerResult c)
            => Debug.Log($"Customer �� ��� {c.averageSatisfaction:F1}% / ���ǥ� {c.reputationDelta:+0.00;-0.00}");
    }
}
