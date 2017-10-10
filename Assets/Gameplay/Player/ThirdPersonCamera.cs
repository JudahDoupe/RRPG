using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ReSharper disable once CheckNamespace
public class ThirdPersonCamera : MonoBehaviour {

    public float Damp = 1f;
    public int Freedom = 60;
    public float HeadHight = 0;
    public float Distance = 3f;

    private Vector3 _offsetDirection = Vector3.back;
    public Vector3 OffsetDirection
    {
        get
        {
            return _offsetDirection = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * FW_Cursor.Instance.Sesitivity, Vector3.up) * _offsetDirection;
        }   
    }
    public Vector3 LookDirection
    {
        get
        {
            _pitch = _pitch + Input.GetAxis("Mouse Y") * -FW_Cursor.Instance.Sesitivity;

            var halfRange = Freedom / 2.0f;
            _pitch = Mathf.Clamp(_pitch, -halfRange, halfRange);

            return Quaternion.AngleAxis(_pitch, _camera.transform.right) * -OffsetDirection;
        }
    }

    private float _pitch;
    private Vector3 _verticalOffset;
    private Camera _camera;

    void Start()
    {
        FW_Cursor.Instance.IsLocked = true;
        _verticalOffset = new Vector3(0, Distance + HeadHight, 0);
        _camera = Camera.main;
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Interact"))
            FW_Cursor.Instance.HoverObject.SendMessage("Interact", SendMessageOptions.DontRequireReceiver);

        _camera.transform.position = Vector3.Slerp(_camera.transform.position,
                                                   (OffsetDirection * Distance) + _verticalOffset + transform.position,
                                                   Time.fixedDeltaTime * Damp);
        _camera.transform.LookAt(_camera.transform.position + LookDirection);
    }
}
