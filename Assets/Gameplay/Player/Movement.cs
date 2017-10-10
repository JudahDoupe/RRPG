using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ReSharper disable once CheckNamespace
public class Movement : MonoBehaviour
{
    public float SpeedMultiplier = 1.0f;
    public float JumpMultiplier = 8f;
    public float AirFriction = 0.9f;

    private Rigidbody _rb;
    private Vector3 _movementVector;
    public Vector3 MovementVector
    {
        get
        {
            if (!IsMovementLocked || IsGrounded)
                _movementVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized * SpeedMultiplier / 10;
            else
                _movementVector = _movementVector * AirFriction;

            return _movementVector = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up) * _movementVector; ;
        }
    }
    public bool IsMovementLocked { get; set; }
    public bool IsGrounded
    {
        get
        {
            return Physics.Raycast(transform.position + (Vector3.up * 0.01f), Vector3.down, 0.1f);
        }
    }



    public void Start()
    {
        _rb = gameObject.GetComponentOrAdd<Rigidbody>();
    }

    void FixedUpdate()
    {

        _rb.MovePosition( MovementVector + transform.position);

        transform.LookAt(MovementVector.normalized + transform.position);

        if (Input.GetButton("Jump") && IsGrounded)
            _rb.AddForce(new Vector3(0, 100 * JumpMultiplier, 0), ForceMode.Impulse);

        if (Input.GetButton("Crouch"))
            Debug.Log("Crouch Not Implimented");

        if (Input.GetButtonDown("Push") && !IsMovementLocked)
            Debug.Log("Push Not Implimented");

        if (Input.GetButtonDown("Dodge") && !IsMovementLocked)
            Debug.Log("Dodge Not Implimented");
    }
}