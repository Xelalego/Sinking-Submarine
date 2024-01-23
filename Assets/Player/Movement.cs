using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed = 10f;
    [SerializeField]
    [Tooltip("Multiply speed while wading")]
    [Range(0f,1f)]
    private float WadeSpeed = 0.5f;
    [SerializeField]
    private CharacterController Controller;

    [SerializeField]
    private LayerMask GroundMask;
    private float yVel = 0f;
    [SerializeField]
    private Transform GroundCheck;
    [SerializeField]
    private Transform CeilingCheck;

    private float LastGrounded = -Mathf.Infinity;
    [SerializeField]
    private float CoyoteTime = 0.1f;
    public float JumpVel = 10f;
    [SerializeField]
    private float Gravity = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.CheckSphere(GroundCheck.position, 0.5f, GroundMask))
        {
            LastGrounded = Time.time + CoyoteTime;
            yVel = Mathf.Max(-2f, yVel);
        }
        else
        {
            yVel -= Gravity * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && LastGrounded >= Time.time)
        {
            yVel = JumpVel;
        }



        Vector3 MoveAxis = transform.forward * Input.GetAxisRaw("Vertical");
        MoveAxis += transform.right * Input.GetAxisRaw("Horizontal");
        MoveAxis.Normalize();

        if (Game.Manager.WaterLevel >= Game.Player.transform.position.y)
        {
            MoveAxis *= WadeSpeed;
        }

        Controller.Move(Speed * Time.deltaTime * MoveAxis);

        Controller.Move(yVel * Time.deltaTime * Vector3.up);
    }
}
