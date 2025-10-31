using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alkuul.Domain
{
    [System.Serializable]
    public struct Drink
    {
        public List<Portion> portions;
        public EmotionVector emotions; // ����ȭ�� �ռ� ���
        public float finalABV;
    }
}
