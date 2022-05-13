using System;
using UnityEngine;

namespace PickableCube
{
    [Serializable]
    public struct PickableCubeTag
    {
        public CubeBehaviour cubeBehaviour;
        public GameObject gameObject;
        public GameObject loseTrigger;
        public bool isPicked;
        public bool isInStack;
        public bool isLost;
    }
}