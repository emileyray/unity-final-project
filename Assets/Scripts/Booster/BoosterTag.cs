using System;
using UnityEngine;

namespace Booster
{
    [Serializable]
    public struct BoosterTag
    {
        public GameObject gameObject;
        public int boost;
        public bool isTriggered;
    }
}