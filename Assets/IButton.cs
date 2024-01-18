using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IButton : Interactable
{
    public UnityEvent Event;

    public override void Interact()
    {
        Event.Invoke();
    }
}
