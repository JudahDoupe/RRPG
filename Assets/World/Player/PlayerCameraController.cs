using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour {

    public PlayerController player;
    public float distance = 9;
    public float camerMoveSpeed = 5;

    void FixedUpdate () {
        UpdatePosition();
        UpdateRotation();
    }

    void UpdatePosition()
    {
        var localTarget = new Vector3(0, distance / 2f, -distance);
        var worldTarget = player.transform.TransformPoint(localTarget);
        transform.position =  Vector3.Lerp(transform.position,worldTarget, camerMoveSpeed * Time.deltaTime);
    }
    void UpdateRotation()
    {
        var lookTarget = player.transform.position;
        lookTarget.y += distance/1.8f;

        var targetRotation = Quaternion.LookRotation(lookTarget - transform.position);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, camerMoveSpeed * 1.5f * Time.deltaTime);
    }
}
