using Interactions;
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
        private InteractableFood _interactableFoodOne;
        private InteractableFood _interactableFoodTwo;

        public void Update()
        {
            if (_interactableFoodOne)
            {
                if (!_positionOneSnapped &&
                    Vector3.Distance(_interactableFoodOne.transform.position, objectOnePosition.position) >
                    animationEndDistance)
                {
                    _interactableFoodOne.transform.position = Vector3.Lerp(_interactableFoodOne.transform.position,
                        objectOnePosition.position, animationSpeed * Time.deltaTime);
                }
                else
                {
                    _positionOneSnapped = true;
                    _interactableFoodOne.transform.position = objectOnePosition.position;
                }
            }

            if (_interactableFoodTwo)
            {
                if (!_positionTwoSnapped &&
                    Vector3.Distance(_interactableFoodTwo.transform.position, objectTwoPosition.position) >
                    animationEndDistance)
                {
                    _interactableFoodTwo.transform.position = Vector3.Lerp(_interactableFoodTwo.transform.position,
                        objectTwoPosition.position, animationSpeed * Time.deltaTime);
                }
                else
                {
                    _positionTwoSnapped = true;
                    _interactableFoodTwo.transform.position = objectTwoPosition.position;
                }
            }
        }


        public void AssignHand(InteractableFood interactableFood)
        {
            if (!_interactableFoodOne)
            {
                _interactableFoodOne = interactableFood;
            }
            else if (!_interactableFoodTwo)
            {
                _interactableFoodTwo = interactableFood;
            }
        }

        public bool CanPickUp()
        {
            return _interactableFoodOne == null || _interactableFoodTwo == null;
        }
    }
}