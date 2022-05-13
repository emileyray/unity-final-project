using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnRight
{
    public class TurnRightScript : MonoBehaviour
    {
        public GameObject turnableWrapper;

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.GetComponent<TurnRightTag>())
            {
                if (collider.gameObject.GetComponent<TurnRightTag>().isTriggered) return;
                turnableWrapper.transform.RotateAround(gameObject.transform.position, Vector3.up, 90);
                collider.gameObject.GetComponent<TurnRightTag>().isTriggered = true;
            }
        }
    }
}
