using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ReSharper disable once CheckNamespace
public class ThirdPersonCamera : MonoBehaviour {

    public float Damp = 1f;
    public int Freedom = 60;
    public float HeadHight = 0;
    public float Distance = 3f;


    void LateUpdate()
    {
        FW_Cursor.Instance.IsLocked = true;

        var rotation = Input.GetAxis("Mouse X") * FW_Cursor.Instance.Sesitivity;
        var pitch = Camera.main.transform.localEulerAngles.x + (Input.GetAxis("Mouse Y") * -FW_Cursor.Instance.Sesitivity);

        var halfRange = Freedom / 2.0f;

        if (180 < pitch && pitch < 360 - halfRange)
        {
           pitch = 360 - halfRange;
        }
        if (halfRange < pitch && pitch < 180)
        {
           pitch = halfRange;
        }

        Camera.main.transform.position = Vector3.Slerp(Camera.main.transform.position,
                                                       transform.TransformPoint(new Vector3(0, Distance + HeadHight, -Distance)),
                                                       Time.fixedDeltaTime * Damp);
        Camera.main.transform.localEulerAngles = new Vector3(pitch, transform.localEulerAngles.y , 0);
        transform.Rotate(new Vector3(0, rotation, 0));
    }
}
