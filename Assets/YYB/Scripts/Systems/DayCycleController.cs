using UnityEngine;
using System.Collections;

namespace Alkuul.Systems
{
    /// <summary>�Ϸ� ����/����/���� ���� ����(MVP)</summary>
    public sealed class DayCycleController : MonoBehaviour
    {
        public int currentDay = 1;

        public void StartDay()
        {
            Debug.Log($"Day {currentDay} ����");
            StartCoroutine(DayRoutine());
        }

        private IEnumerator DayRoutine()
        {
            // TODO: �մ� ť/����/�ֹ�/�� ���� ����
            yield return new WaitForSeconds(1f);
            EndDay();
        }

        private void EndDay()
        {
            Debug.Log($"Day {currentDay} ����");
            currentDay++;
        }
    }
}
