using UnityEngine;
using Alkuul.Domain;

namespace Alkuul.Systems
{
    public sealed class InnSystem : MonoBehaviour
    {
        public bool TrySleep(CustomerResult cr)
        {
            if (cr.leftEarly) return false;
            // ���� ���� üũ/�߰� ���� ���� ������ ���� Ȯ��
            Debug.Log("�մ� ���(�߰� ���� ����)");
            return true;
        }
    }
}
