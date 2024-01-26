using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LadderController : MonoBehaviour
{
    public Transform charController;
    bool inside = false;
    [SerializeField] private float speedUpDown = 10f;
    public Movement playerInput;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<Movement>();
        inside = false;
    }

    private void OnTriggerEnter(Collider col)
    {
        // If we touch the ladder, disable character controls
        // so they can move up and down the Y axis.
        if (col.gameObject.tag == "Ladder")
        {
            playerInput.enabled = false;
            inside = !inside;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        // We exited the ladder, give back player controls
        // to move along the X axis.
        if (col.gameObject.tag == "Ladder")
        {
            playerInput.enabled = true;
            inside = !inside;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inside && Input.GetKey("w"))
        {
            charController.transform.position += Vector3.up * speedUpDown * Time.deltaTime;
        }

        if (inside && Input.GetKey("s"))
        {
            charController.transform.position += Vector3.down * speedUpDown * Time.deltaTime;
        }

        if (inside && Input.GetKey("a"))
        {
            charController.transform.position += (Vector3.left - Camera.main.transform.right) * speedUpDown * Time.deltaTime;
        }

        if (inside && Input.GetKey("d"))
        {
            charController.transform.position += (Vector3.right + Camera.main.transform.right) * speedUpDown * Time.deltaTime;
        }
    }
}
