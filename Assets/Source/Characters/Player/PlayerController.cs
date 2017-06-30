using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public void Update()
    {
        Move();
    }

	private void Move () {
        gameObject.transform.Translate(GetMovementVector());
	}

    private Vector3 GetMovementVector()
    {
        return new Vector3 {x = Input.GetAxis("Horizontal"), z = Input.GetAxis("Vertical") };
    }
}
