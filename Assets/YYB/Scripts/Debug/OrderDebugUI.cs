using UnityEngine;
using System.Collections.Generic;
using Alkuul.Domain;
using Alkuul.Systems;

namespace Alkuul.UI
{
    /// <summary>
    /// ��ư �� ������ �ֹ� ���� �� BrewingUI.Submit���� ȣ���ϴ� �ӽ� ����̹�
    /// </summary>
    public class OrderDebugUI : MonoBehaviour
    {
        [SerializeField] private OrderSystem orderSystem;
        [SerializeField] private BrewingUI brewingUI;

        [Header("Order Params")]
        [SerializeField] private List<SecondaryEmotionSO> keywords = new(); // �ȵ�/��ȸ ��
        [SerializeField] private Vector2 abvRange = new Vector2(0, 100);
        [SerializeField] private float timeLimit = 45f;
        [SerializeField] private string majorEmotionTag = "joy"; // ��/���/���Ͻ� ��Ī��

        public void OnMakeAndSubmit()
        {
            if (orderSystem == null || brewingUI == null)
            {
                Debug.LogWarning("OrderDebugUI: refs missing.");
                return;
            }
            var order = orderSystem.CreateOrder(keywords, abvRange, timeLimit);
            brewingUI.OnSubmit(order, majorEmotionTag);
        }
    }
}
