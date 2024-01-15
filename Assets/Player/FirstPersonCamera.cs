using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FirstPersonCamera : MonoBehaviour
{
    // Variables
    [SerializeField] private float sensitivity = 500;
    private float cameraAxisX, cameraAxisY;

    [SerializeField]
    private LayerMask InteractableMask;

    [SerializeField]
    private TMP_Text TextPrompt;



    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        Interactable hoveredInteractable = null;
        // If holding an item
        if (Game.Player.HeldItem)
        {
            //Lerp?
            //Game.Player.HeldItem.transform.position = Vector3.Lerp(Game.Player.HeldItem.transform.position, transform.position + transform.forward * Game.Player.MaxReach, 0.5f);
            //Game.Player.HeldItem.transform.position = transform.position + transform.forward * Game.Player.MaxReach;
            Game.Player.HeldItem.RigidBody.velocity = (transform.position + transform.forward - Game.Player.HeldItem.transform.position) * 10f;
            if (Input.GetMouseButtonDown(0))
            {
                Game.Player.HeldItem.Drop();
                Game.Player.HeldItem = null;
            }
        } // If not holding an item
        else if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, Game.Player.MaxReach, InteractableMask))
        {
            hoveredInteractable = hit.collider.gameObject.GetComponent<Interactable>();
            if (hoveredInteractable) hoveredInteractable.Hover();
            // Display hover effects here
            if (Input.GetMouseButtonDown(0))
            {
                if (hoveredInteractable) hoveredInteractable.Interact();
            }
        }
        if (hoveredInteractable) TextPrompt.text = hoveredInteractable.HoverMessage;
        else TextPrompt.text = "";
    }

    // Update is called once per frame
    void Update()
    {

        // Initialize mouse movements
        cameraAxisX -= sensitivity * Input.GetAxis("Mouse Y") * Time.deltaTime; //Mathf.Min(Time.deltaTime, .1f); // speed = 2f;
        cameraAxisY += sensitivity * Input.GetAxis("Mouse X") * Time.deltaTime; //Mathf.Min(Time.deltaTime, .1f); // Wtf?!
        
        // Rotate camera based on mouse.
        cameraAxisX = Mathf.Clamp(cameraAxisX, -90, 90); // limits vertical rotation
        transform.localEulerAngles = Vector3.right * cameraAxisX;
        transform.parent.localEulerAngles = Vector3.up * cameraAxisY;
    }
}
