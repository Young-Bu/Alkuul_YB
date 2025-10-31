using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alkuul.Domain
{
    [System.Serializable]
    public struct DrinkResult
    {
        public float satisfaction; // 0~100
        public int tip;
        public bool customerLeft;  // <40 ��� ��Ż
    }

    [System.Serializable]
    public struct CustomerResult
    {
        public string customerId;
        public List<DrinkResult> drinkResults;
        public float averageSatisfaction;
        public float reputationDelta;
        public int totalTip;
        public bool leftEarly;
    }
}
