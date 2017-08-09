using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour {

    public float speedMultiplier = 0.25f;
    public float lookMultiplier = 2.5f;

    private Rigidbody _rb;

    public void Start()
    {
        _rb = gameObject.GetComponentOrAdd<Rigidbody>();
        FW_Cursor.Instance.IsLocked = true;
    }

    public void FixedUpdate()
    {
        Move();
        Look();
    }

    private void Move()
    {
        var forward = transform.forward * Input.GetAxis("Vertical") * speedMultiplier;
        var strafe = transform.right * Input.GetAxis("Horizontal") * speedMultiplier;
        _rb.MovePosition(forward + strafe + transform.position);
    }

    private void Look()
    {
        var mouseX = Input.GetAxis("Mouse X") * lookMultiplier;
        transform.Rotate(new Vector3(0, mouseX, 0));

        var x = Camera.main.transform.localEulerAngles.x;

        x += Input.GetAxis("Mouse Y") * -lookMultiplier;

        if (x < 270 && x >= 180) { x = 270; }
        if (x > 90 && x <= 180) { x = 90; }

        Camera.main.transform.localEulerAngles = new Vector3(x, 0, 0);
    }
}
