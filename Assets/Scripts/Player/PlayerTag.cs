using System;
using UnityEngine;

namespace Player
{
    [Serializable]
    public struct PlayerTag
    {
        public GameObject turnableWrapper;
        public GameObject gameObject;
        public GameObject loseTrigger;
    }
}