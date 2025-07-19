
using Controls;
using UnityEngine;

namespace Interactions
{
    public class InteractableFood : Interactable
    {

        public Food foodType;
        private bool _pickedUp;

        public override void Interact()
        {
            if (_pickedUp) return;
            _pickedUp = true;
            Debug.Log("Food picked up");
            var handControls = GameObject.FindGameObjectWithTag(Constants.PlayerTag).GetComponent<HandsControls>();
            handControls.AssignHand(this);
        }
    }
}
