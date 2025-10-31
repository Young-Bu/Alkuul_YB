using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alkuul.Domain
{
    [CreateAssetMenu(menuName = "Alkuul/Technique")]
    public class TechniqueSO : ScriptableObject
    {
        public string id, displayName;
        public string[] tags; // Shake=�г�, Stir=���� ... ��
    }
}

