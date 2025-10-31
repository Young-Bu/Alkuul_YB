using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Alkuul.Domain;

namespace Alkuul.Systems
{
    /// <summary>ÇÑ ÀÜ/ÇÑ ¼Õ´Ô Æò°¡ Áý°è</summary>
    public sealed class ServeSystem : MonoBehaviour
    {
        [SerializeField] private ScoringService scoring;

        public struct Meta
        {
            public string majorEmotionTag;
            public string[] techniqueTags, glassTags, garnishTags;
            public bool iceLiked, iceDisliked;

            public static Meta From(TechniqueSO t, GlassSO g, IEnumerable<GarnishSO> gs, bool ice, string major)
            {
                return new Meta
                {
                    majorEmotionTag = major,
                    techniqueTags = t?.tags,
                    glassTags = g?.tags,
                    garnishTags = gs != null ? System.Linq.Enumerable.SelectMany(gs, x => x.tags).ToArray() : null,
                    iceLiked = ice,
                    iceDisliked = false
                };
            }
        }

        public DrinkResult ServeOne(Order order, Drink drink, Meta meta) => scoring.Evaluate(order, drink, meta);

        public CustomerResult ServeCustomer(string id, Order order, IEnumerable<(Drink drink, Meta meta)> drinks)
        {
            var results = new List<DrinkResult>();
            bool early = false;

            foreach (var (drink, meta) in drinks)
            {
                var r = scoring.Evaluate(order, drink, meta);
                results.Add(r);
                if (r.customerLeft) { early = true; break; }
                if (results.Count >= 3) break;
            }

            float avg = results.Count > 0 ? results.Average(x => x.satisfaction) : 0f;
            int tipSum = results.Sum(x => x.tip);
            float repDelta = early ? -0.25f :
                (avg >= 81 ? 0.25f :
                 avg >= 61 ? 0.1f :
                 avg >= 41 ? 0f :
                 avg >= 21 ? -0.25f : -0.5f);

            return new CustomerResult
            {
                customerId = id,
                drinkResults = results,
                averageSatisfaction = avg,
                totalTip = tipSum,
                reputationDelta = repDelta,
                leftEarly = early
            };
        }
    }
}

