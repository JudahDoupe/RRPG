using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool IsFirstPerson = true;
    public float LookMultiplier = 2.5f;
    public float SpeedMultiplier = 0.5f;
    public float JumpMultiplier = 2f;
    public float AirFriction = 1f;

    private Rigidbody _rb;

    private float momentum = 0f;
    private float strafe = 0f;
    private bool isMovementLocked = false;
    public bool isGrounded{ get{ return Physics.Raycast(transform.position + (Vector3.up * 0.01f), Vector3.down, 0.1f); } }
    private Vector3 MovementDirection
    {
        get
        {
            if (!isMovementLocked && isGrounded)
            {
                momentum = Input.GetAxis("Vertical") * SpeedMultiplier;
                strafe = Input.GetAxis("Horizontal") * SpeedMultiplier;
            }

            momentum = momentum * AirFriction;
            strafe = strafe * AirFriction; 

            return new Vector3(strafe, 0f, momentum);
        }
    }

    public void Start()
    {
        _rb = gameObject.GetComponentOrAdd<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (IsFirstPerson)
            FirstPersonLook();
        else
            ThirdPersonLook();

        _rb.MovePosition(transform.TransformDirection(MovementDirection) + transform.position);

        if (Input.GetButton("Jump") && isGrounded)
            _rb.AddForce(new Vector3(0, 100 * JumpMultiplier, 0), ForceMode.Impulse);

        if (Input.GetButtonDown("Interact"))
            FW_Cursor.Instance.HoverObject.SendMessage("Interact",SendMessageOptions.DontRequireReceiver);

        if (Input.GetButton("Crouch"))
            Debug.Log("Crouch Not Implimented");

        if (Input.GetButtonDown("Push") && !isMovementLocked)
            Debug.Log("Push Not Implimented");

        if (Input.GetButtonDown("Dodge") && !isMovementLocked)
            Debug.Log("Dodge Not Implimented");
    }

    void FirstPersonLook()
    {
        FW_Cursor.Instance.IsLocked = true;

        var rotation = Input.GetAxis("Mouse X") * LookMultiplier;
        var pitch = Camera.main.transform.localEulerAngles.x + (Input.GetAxis("Mouse Y") * -LookMultiplier);

        if (pitch >= 180 && pitch < 270) { pitch = 270; }
        if (pitch > 90 && pitch <= 180) { pitch = 90; }

        Camera.main.transform.localPosition = Vector3.zero;
        Camera.main.transform.localEulerAngles = new Vector3(pitch, 0, 0);
        transform.Rotate(new Vector3(0, rotation, 0));
    }
    void ThirdPersonLook()
    {
        Debug.Log("Third Person Not Implimented");
    }
}