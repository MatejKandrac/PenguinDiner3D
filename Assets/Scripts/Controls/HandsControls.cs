using Interactions;
using Unity.Properties;
using UnityEngine;

namespace Controls
{
    public class HandsControls : MonoBehaviour
    {
        public Transform objectOnePosition;
        public Transform objectTwoPosition;
        public float animationSpeed = 1f;
        public float animationEndDistance = 0.1f;

        private bool _positionOneSnapped;
        private bool _positionTwoSnapped;
        [DontCreateProperty] public InteractableFood interactableFoodOne;
        [DontCreateProperty] public InteractableFood interactableFoodTwo;

        public void Update()
        {
            if (interactableFoodOne)
            {
                if (!_positionOneSnapped &&
                    Vector3.Distance(interactableFoodOne.transform.position, objectOnePosition.position) >
                    animationEndDistance)
                {
                    interactableFoodOne.transform.position = Vector3.Lerp(interactableFoodOne.transform.position,
                        objectOnePosition.position, animationSpeed * Time.deltaTime);
                }
                else
                {
                    _positionOneSnapped = true;
                    interactableFoodOne.transform.position = objectOnePosition.position;
                }
            }

            if (interactableFoodTwo)
            {
                if (!_positionTwoSnapped &&
                    Vector3.Distance(interactableFoodTwo.transform.position, objectTwoPosition.position) >
                    animationEndDistance)
                {
                    interactableFoodTwo.transform.position = Vector3.Lerp(interactableFoodTwo.transform.position,
                        objectTwoPosition.position, animationSpeed * Time.deltaTime);
                }
                else
                {
                    _positionTwoSnapped = true;
                    interactableFoodTwo.transform.position = objectTwoPosition.position;
                }
            }
        }
        
        public void AssignHand(InteractableFood interactableFood)
        {
            if (!interactableFoodOne)
            {
                interactableFoodOne = interactableFood;
            }
            else if (!interactableFoodTwo)
            {
                interactableFoodTwo = interactableFood;
            }
        }

        public void RemoveFromHand(InteractableFood interactableFood)
        {
            if (interactableFood == interactableFoodOne)
            {
                _positionOneSnapped = false;
                interactableFoodOne = null;
            }
            if (interactableFood == interactableFoodTwo)
            {
                _positionTwoSnapped = false;
                interactableFoodTwo = null;
            }
        }

        public bool CanPickUp()
        {
            return interactableFoodOne == null || interactableFoodTwo == null;
        }
    }
}