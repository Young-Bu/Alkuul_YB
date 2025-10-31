using UnityEngine;
using System.Collections;

namespace Alkuul.Systems
{
    /// <summary>하루 시작/영업/종료 간단 루프(MVP)</summary>
    public sealed class DayCycleController : MonoBehaviour
    {
        public int currentDay = 1;

        public void StartDay()
        {
            Debug.Log($"Day {currentDay} 시작");
            StartCoroutine(DayRoutine());
        }

        private IEnumerator DayRoutine()
        {
            // TODO: 손님 큐/스폰/주문/평가 루프 연결
            yield return new WaitForSeconds(1f);
            EndDay();
        }

        private void EndDay()
        {
            Debug.Log($"Day {currentDay} 종료");
            currentDay++;
        }
    }
}
