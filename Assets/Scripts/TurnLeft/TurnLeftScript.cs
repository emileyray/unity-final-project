using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnLeft
{
    public class TurnLeftScript : MonoBehaviour
    {
        public GameObject turnableWrapper;

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.GetComponent<TurnLeftTag>())
            {
                if (collider.gameObject.GetComponent<TurnLeftTag>().isTriggered) return;
                turnableWrapper.transform.RotateAround(gameObject.transform.position, Vector3.up, -90);
                collider.gameObject.GetComponent<TurnLeftTag>().isTriggered = true;
            }
        }
    }
}
