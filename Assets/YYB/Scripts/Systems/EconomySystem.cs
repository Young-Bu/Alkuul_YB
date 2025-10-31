using UnityEngine;
using Alkuul.Domain;

namespace Alkuul.Systems
{
    public sealed class EconomySystem : MonoBehaviour
    {
        [SerializeField] private RepSystem rep;
        public int money;

        public void Apply(CustomerResult cr)
        {
            money += Mathf.RoundToInt(cr.totalTip * TipMultiplierByRep(rep.reputation));
        }

        private float TipMultiplierByRep(float repScore) => repScore <= 1.0f ? 0.7f :
                                                           repScore <= 2.0f ? 0.9f :
                                                           repScore <= 3.0f ? 1.0f :
                                                           repScore <= 4.0f ? 1.1f :
                                                           repScore <= 4.5f ? 1.25f : 1.5f;
    }
}

