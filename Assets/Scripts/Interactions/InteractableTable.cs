using Controls;
using Objects.Foods;
using UnityEngine;

namespace Interactions
{
    public class InteractableTable : Interactable
    {
        public float animationSpeed = 1f;
        public float animationEndDistance = 0.1f;

        public Transform foodPositionOne;
        public Transform foodPositionTwo;

        public Food desiredFoodOne;
        public Food desiredFoodTwo;

        private bool _positionOneSnapped;
        private bool _positionTwoSnapped;

        private Transform _placedObjectOne;
        private Transform _placedObjectTwo;

        void Update()
        {
            if (_placedObjectOne)
            {
                if (!_positionOneSnapped &&
                    Vector3.Distance(_placedObjectOne.transform.position, foodPositionOne.position) >
                    animationEndDistance)
                {
                    _placedObjectOne.transform.position = Vector3.Lerp(_placedObjectOne.transform.position,
                        foodPositionOne.position, animationSpeed * Time.deltaTime);
                }
                else
                {
                    _positionOneSnapped = true;
                    _placedObjectOne.transform.position = foodPositionOne.position;
                }
            }

            if (_placedObjectTwo)
            {
                if (!_positionTwoSnapped &&
                    Vector3.Distance(_placedObjectTwo.transform.position, foodPositionTwo.position) >
                    animationEndDistance)
                {
                    _placedObjectTwo.transform.position = Vector3.Lerp(_placedObjectTwo.transform.position,
                        foodPositionTwo.position, animationSpeed * Time.deltaTime);
                }
                else
                {
                    _positionTwoSnapped = true;
                    _placedObjectTwo.transform.position = foodPositionTwo.position;
                }
            }
        }

        public override void Interact()
        {
            if (!desiredFoodOne && !desiredFoodTwo) return;
            var handControls = GameObject.FindGameObjectWithTag(Constants.PlayerTag).GetComponent<HandsControls>();
            var heldItemOne = handControls.interactableFoodOne;
            var heldItemTwo = handControls.interactableFoodTwo;

            if (heldItemOne)
            {
                if (heldItemOne.foodType == desiredFoodOne && !_placedObjectOne)
                {
                    _placedObjectOne = heldItemOne.transform;
                    handControls.RemoveFromHand(heldItemOne);
                }
                else if (heldItemOne.foodType == desiredFoodTwo && !_placedObjectTwo)
                {
                    _placedObjectTwo = heldItemOne.transform;
                    handControls.RemoveFromHand(heldItemOne);
                }
            }
            else if (heldItemTwo)
            {
                if (heldItemTwo.foodType == desiredFoodOne && !_placedObjectOne)
                {
                    _placedObjectOne = heldItemTwo.transform;
                    handControls.RemoveFromHand(heldItemTwo);
                }
                else if (heldItemTwo.foodType == desiredFoodTwo && !_placedObjectTwo)
                {
                    _placedObjectTwo = heldItemTwo.transform;
                    handControls.RemoveFromHand(heldItemTwo);
                }
            }
        }
        
    }
}