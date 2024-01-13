using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    // Variables
    private Vector3 offset = new Vector3(0, 0.5f, 0);
    [SerializeField] private float sensitivity = 500;
    private float cameraAxisX, cameraAxisY;
    

    // GameObject variables
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Constantly keep camera on player.
        //transform.position = player.transform.position + offset;

        // Initialize mouse movements
        //cameraAxisX += sensitivity * Input.GetAxis("Mouse X"); // speed = 2f;
        cameraAxisY += sensitivity * Input.GetAxis("Mouse X") * Mathf.Min(Time.deltaTime, .1f); // Wtf?!
        
        // Rotate camera based on mouse.
        //cameraAxisY = Mathf.Clamp(cameraAxisY, -45, 45); // limits vertical rotation
        transform.eulerAngles = new Vector3(0.0f, cameraAxisY, 0.0f);
        player.transform.rotation = transform.rotation;
    }
}
