using UnityEngine;
using Alkuul.Domain;

namespace Alkuul.Systems
{
    public sealed class InnSystem : MonoBehaviour
    {
        public bool TrySleep(CustomerResult cr)
        {
            if (cr.leftEarly) return false;
            // 만취 조건 체크/추가 보상 지급 로직은 추후 확장
            Debug.Log("손님 재움(추가 수익 지급)");
            return true;
        }
    }
}
