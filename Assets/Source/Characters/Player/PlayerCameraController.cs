using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour {

    public PlayerController player;
    public float distance = 5;
	
	// Update is called once per frame
	void Update () {
        UpdatePosition();

    }

    void UpdatePosition()
    {
        var x = player.transform.position.x;
        var y = player.transform.position.y + distance;
        var z = player.transform.position.z - distance;
        transform.position = new Vector3(x, y, z);
    }
}
