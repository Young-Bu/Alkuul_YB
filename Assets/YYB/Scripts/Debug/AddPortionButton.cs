using UnityEngine;
using Alkuul.Domain;
using Alkuul.UI;

public class AddPortionButton : MonoBehaviour
{
    [SerializeField] private BrewingUI target;     // Canvas�� BrewingUIController �巡��
    [SerializeField] private IngredientSO ingredient; // ��ư�� ��� ����
    [SerializeField] private float ml = 30f;          // �� ��ư�� ���� ��

    public void Add()
    {
        if (target == null || ingredient == null) { Debug.LogWarning("AddPortionButton: ref missing"); return; }
        target.OnAdd(ingredient, ml);
    }
}
