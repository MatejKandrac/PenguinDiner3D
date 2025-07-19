using UnityEngine;

namespace Interactions
{
    [RequireComponent(typeof(Collider))]
    public abstract class Interactable : MonoBehaviour
    {
        public abstract void Interact();
    }
}
