
using Controls;
using Objects.Foods;
using UnityEngine;

namespace Interactions
{
    public class InteractableFood : Interactable
    {

        public Food foodType;

        public override void Interact()
        {
            var handControls = GameObject.FindGameObjectWithTag(Constants.PlayerTag).GetComponent<HandsControls>();
            if (!handControls.CanPickUp()) return;
            enabled = false;
            handControls.AssignHand(this);
        }
    }
}
