using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alkuul.Domain
{
    /// <summary>2�� ���� Ű���� �� 1�� ���� ����</summary>
    [CreateAssetMenu(menuName = "Alkuul/Emotion/Secondary")]
    public class SecondaryEmotionSO : ScriptableObject
    {
        public string id;
        public string displayName;       // Ű���� ǥ�ø�
        public EmotionVector composition; // 1�� ���� ����(��=1.0 �Ǵ� 100 ���̵�)
    }
}

