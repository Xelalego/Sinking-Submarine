using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed = 10f;
    [SerializeField]
    private CharacterController Controller;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 MoveAxis = transform.forward * Input.GetAxisRaw("Vertical");
        MoveAxis += transform.right * Input.GetAxisRaw("Horizontal");
        MoveAxis.Normalize();

        Controller.Move(Speed * Time.deltaTime * MoveAxis);
    }
}
