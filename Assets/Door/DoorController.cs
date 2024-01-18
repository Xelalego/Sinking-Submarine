using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class DoorController : Interactable
{
    public GameObject Door;
    private float doorSpeed = 5f;
    [SerializeField] private bool buttonSwitch = false;
    [SerializeField] private Transform openDestination;
    [SerializeField] private Transform closedDestination;

    // Update is called once per frame
    public void Update()
    {
        if (buttonSwitch)
        {
            Door.transform.position = Vector3.MoveTowards(Door.transform.position, openDestination.transform.position, doorSpeed * Time.deltaTime);
        }
        else
        {
            Door.transform.position = Vector3.MoveTowards(Door.transform.position, closedDestination.transform.position, doorSpeed * Time.deltaTime);
        }
    }

    public void ToggleDoor()
    {
        buttonSwitch = !buttonSwitch;
    }
}
