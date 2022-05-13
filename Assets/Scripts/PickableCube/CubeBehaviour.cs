using UnityEngine;

namespace PickableCube
{
    public class CubeBehaviour : MonoBehaviour
    {
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}