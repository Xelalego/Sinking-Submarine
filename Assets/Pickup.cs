using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Interactable
{
    public Rigidbody RigidBody;

    public enum Size
    {
        Small,
        Medium,
        Large
    }

    public Size size;

    [Tooltip("Multiplies the snapping force to the center of the screen when held by the player")]
    public float SnappingForce = 10f;

    public override void Interact()
    {
        base.Interact();
        Game.Player.HeldItem = this;
        RigidBody.useGravity = false;
        gameObject.layer = 8;
    }

    public void Drop()
    {
        // Held item should already be set to null by the FirstPersonCamera script, but this guarantees it
        if (Game.Player.HeldItem == this) Game.Player.HeldItem = null;
        RigidBody.useGravity = true;
        gameObject.layer = 7;
    }
}
