using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Combat
{
    [System.Serializable]
    public struct Stat
    {
        [SerializeField] EAttribute attribute;
        public EAttribute Attribute { get => attribute; }
        [SerializeField] int value;
        public int Value { get => value; }
    }
}
