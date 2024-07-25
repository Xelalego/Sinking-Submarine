using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FirstPersonCamera : MonoBehaviour
{
    private float cameraAxisX, cameraAxisY;

    [SerializeField]
    private LayerMask InteractableMask;
    [SerializeField]
    private LayerMask ReachBlockingMask;

    public TMP_Text TextPrompt;

    [SerializeField]
    private float smoothFactor = 10f;


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
            //Shorten reach if would push object into wall (softens impact SFX)
            Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 1f, ReachBlockingMask);
            Vector3 point = hit.point;
            if (point == Vector3.zero || point == null) point = transform.position + transform.forward;
            Game.Player.HeldItem.RigidBody.velocity = Vector3.Lerp(Game.Player.HeldItem.RigidBody.velocity, (point - Game.Player.HeldItem.transform.position) * Game.Player.HeldItem.SnappingForce, Time.deltaTime * smoothFactor);
            //Game.Player.HeldItem.RigidBody.velocity = (transform.position + transform.forward - Game.Player.HeldItem.transform.position) * Game.Player.HeldItem.SnappingForce;
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
        if (UIController.Paused) return;
        // Removed DeltaTime, may re-add later if framerate changes sensitivity
        // Initialize mouse movements
        cameraAxisX -= PlayerPrefs.GetFloat("MouseSensitivity") * Input.GetAxis("Mouse Y");// * Mathf.Min(Time.deltaTime, .1f); // speed = 2f;
        cameraAxisY += PlayerPrefs.GetFloat("MouseSensitivity") * Input.GetAxis("Mouse X");// * Mathf.Min(Time.deltaTime, .1f); // Wtf?!
        
        // Rotate camera based on mouse.
        cameraAxisX = Mathf.Clamp(cameraAxisX, -90, 90); // limits vertical rotation
        transform.localEulerAngles = Vector3.right * cameraAxisX;
        transform.parent.localEulerAngles = Vector3.up * cameraAxisY;
    }
}
