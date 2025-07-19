using Interactions;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Controls
{
    public class InteractionControls : MonoBehaviour
    {
        public LayerMask interactableLayers;
        public float interactionDistance = 3.5f;
        private Camera _camera;
        private Interactable _currentInteractable;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _camera = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            var ray = new Ray(_camera.transform.position, _camera.transform.forward);
            Debug.DrawRay(ray.origin, ray.direction * interactionDistance);

            if (Physics.Raycast(ray, out var hit, interactionDistance, interactableLayers))
            {
                var hits = hit.collider.GetComponents<Interactable>();

                foreach (var interactable in hits)
                {
                    // Handle only first interaction
                    if (!_currentInteractable && interactable.enabled)
                    {
                        _currentInteractable = interactable;
                    }
                    break;
                }
            } else if (_currentInteractable)
            {
                _currentInteractable = null;
            }
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (!context.started) return;
            _currentInteractable?.Interact();
            _currentInteractable = null;
        }
    }
}
