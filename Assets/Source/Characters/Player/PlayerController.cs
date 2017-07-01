using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float SpeedMultiplier = 1;
    public float Movement { get { return Input.GetAxis("Vertical") * SpeedMultiplier; } }


    public float RotationMultiplier = 5;
    public float Rotation{ get{ return Input.GetAxis("Horizontal") * RotationMultiplier; } }



    public void Update()
    {
        Move();
        Rotate();
    }
	private void Move () {
        gameObject.transform.Translate(0,0, Movement);
	}
    private void Rotate()
    {
        gameObject.transform.Rotate(0,Rotation,0);
    }

}
