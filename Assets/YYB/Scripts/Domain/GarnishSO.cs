using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alkuul.Domain
{
    [CreateAssetMenu(menuName = "Alkuul/Garnish")]
    public class GarnishSO : ScriptableObject
    {
        public string id, displayName;
        public string[] tags; // ���� �±�(�ֿ� 1�� ������ ��ġ��)
        public Sprite icon;
    }
}

