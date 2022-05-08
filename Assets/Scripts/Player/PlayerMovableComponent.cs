using System;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace Player
{
    [Serializable]
    public struct PlayerMovableComponent
    {
        public float offset;
        [SerializeField] public float speed;
    }
}