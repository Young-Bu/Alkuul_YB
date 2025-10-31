using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alkuul.Domain
{
    [System.Serializable]
    public struct Order
    {
        public EmotionVector targetEmotions; // ��ǥ(1�� ���� ����)
        public Vector2 abvRange;             // ��� ���� ����(�ɼ�)
        public float timeLimit;              // �ܴ� ���ѽð�(��)
    }
}

