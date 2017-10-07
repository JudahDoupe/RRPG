using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ReSharper disable once CheckNamespace
public class Movement : MonoBehaviour
{
    public float SpeedMultiplier = 1.0f;
    public float JumpMultiplier = 8f;
    public float AirFriction = 1f;

    private Rigidbody _rb;

    private float _momentum = 0f;
    private float _strafe = 0f;

    public bool IsMovementLocked { get; set; }
    public bool IsGrounded
    {
        get
        {
            return Physics.Raycast(transform.position + (Vector3.up * 0.01f), Vector3.down, 0.1f);
        }
    }
    private Vector3 MovementDirection
    {
        get
        {
            if (!IsMovementLocked && IsGrounded)
            {
                _momentum = Input.GetAxis("Vertical") * SpeedMultiplier/10;
                _strafe = Input.GetAxis("Horizontal") * SpeedMultiplier/10;
            }

            _momentum = _momentum * AirFriction;
            _strafe = _strafe * AirFriction; 

            return new Vector3(_strafe, 0f, _momentum);
        }
    }

    public void Start()
    {
        _rb = gameObject.GetComponentOrAdd<Rigidbody>();
    }

    void FixedUpdate()
    {

        _rb.MovePosition(transform.TransformDirection(MovementDirection) + transform.position);

        if (Input.GetButton("Jump") && IsGrounded)
            _rb.AddForce(new Vector3(0, 100 * JumpMultiplier, 0), ForceMode.Impulse);

        if (Input.GetButtonDown("Interact"))
            FW_Cursor.Instance.HoverObject.SendMessage("Interact",SendMessageOptions.DontRequireReceiver);

        if (Input.GetButton("Crouch"))
            Debug.Log("Crouch Not Implimented");

        if (Input.GetButtonDown("Push") && !IsMovementLocked)
            Debug.Log("Push Not Implimented");

        if (Input.GetButtonDown("Dodge") && !IsMovementLocked)
            Debug.Log("Dodge Not Implimented");
    }
}