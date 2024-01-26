using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
    bool Climbing = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider col)
    {
        // If we touch the ladder, disable character controls
        // so they can move up and down the Y axis.
        if (col.gameObject.CompareTag("Ladder"))
        {
            Climbing = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        // We exited the ladder, give back player controls
        // to move along the X axis.
        if (col.gameObject.CompareTag("Ladder"))
        {
            Climbing = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.CheckSphere(CeilingCheck.position, Controller.radius, GroundMask)) yVel = Mathf.Min(0f, yVel);
        if (Physics.CheckSphere(GroundCheck.position, Controller.radius, GroundMask) || Climbing)
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

        if (Game.Player.HeldItem)
        {
            if (Game.Player.HeldItem.size == Pickup.Size.Large)
            {
                MoveAxis *= 0.6f;
            }
        }

        Controller.Move(Speed * Time.deltaTime * MoveAxis);

        if (Climbing) Controller.Move(Input.GetAxis("Vertical") * Speed * Time.deltaTime * Vector3.up);
        else Controller.Move(yVel * Time.deltaTime * Vector3.up);
    }
}
