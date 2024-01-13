using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Diagnostics.Tracing;

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

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Interactable hoveredInteractable = null;
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, Game.Player.MaxReach, InteractableMask))
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

        // Initialize mouse movements
        cameraAxisX -= sensitivity * Input.GetAxis("Mouse Y") * Mathf.Min(Time.deltaTime, .1f); // speed = 2f;
        cameraAxisY += sensitivity * Input.GetAxis("Mouse X") * Mathf.Min(Time.deltaTime, .1f); // Wtf?!
        
        // Rotate camera based on mouse.
        cameraAxisX = Mathf.Clamp(cameraAxisX, -90, 90); // limits vertical rotation
        transform.localEulerAngles = Vector3.right * cameraAxisX;
        transform.parent.localEulerAngles = Vector3.up * cameraAxisY;
    }
}
