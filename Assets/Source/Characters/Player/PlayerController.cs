using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float SpeedMultiplier = 0.25f;
    public float Movement { get { return Input.GetAxis("Vertical") * SpeedMultiplier; } }
    public float RotationMultiplier = 2.5f;
    public float Rotation{ get{ return Input.GetAxis("Horizontal") * RotationMultiplier; } }

    private Rigidbody _rb;

    public void Start()
    {
        _rb = gameObject.GetComponentOrAdd<Rigidbody>();
    }

    public void FixedUpdate()
    {
        Move();
        Rotate();
    }
	private void Move () {
        _rb.MovePosition(transform.position + transform.forward * Movement);
    }
    private void Rotate()
    {
        gameObject.transform.Rotate(0,Rotation,0);
    }

}
