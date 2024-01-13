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
        cameraAxisX -= sensitivity * Input.GetAxis("Mouse Y") * Mathf.Min(Time.deltaTime, .1f); // speed = 2f;
        cameraAxisY += sensitivity * Input.GetAxis("Mouse X") * Mathf.Min(Time.deltaTime, .1f); // Wtf?!
        
        // Rotate camera based on mouse.
        cameraAxisX = Mathf.Clamp(cameraAxisX, -90, 90); // limits vertical rotation
        transform.localEulerAngles = new Vector3(cameraAxisX, 0, 0);
        player.transform.localEulerAngles = new Vector3(0, cameraAxisY, 0);
    }
}
