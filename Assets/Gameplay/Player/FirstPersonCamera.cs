using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour {

    public float LookMultiplier = 2.5f;

    void Update () {
	    FW_Cursor.Instance.IsLocked = true;

	    var rotation = Input.GetAxis("Mouse X") * LookMultiplier;
	    var pitch = Camera.main.transform.localEulerAngles.x + (Input.GetAxis("Mouse Y") * -LookMultiplier);

	    if (pitch >= 180 && pitch < 270) { pitch = 270; }
	    if (pitch > 90 && pitch <= 180) { pitch = 90; }

	    Camera.main.transform.localPosition = Vector3.zero;
	    Camera.main.transform.localEulerAngles = new Vector3(pitch, 0, 0);
	    transform.Rotate(new Vector3(0, rotation, 0));
    }
}
