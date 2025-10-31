using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alkuul.Domain
{
    [System.Serializable]
    public struct Drink
    {
        public List<Portion> portions;
        public EmotionVector emotions; // 정규화된 합성 결과
        public float finalABV;
    }
}
