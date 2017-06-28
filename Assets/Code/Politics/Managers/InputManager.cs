using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	public Camera detectionCamera;
	
	public bool debug = false;
	
	public LayerMask rightClickLayerMask;
	public LayerMask leftClickLayerMask;
	
	void Start(){if(detectionCamera != null) detectionCamera = Camera.main;}
	
	void Update (){	
		if(Input.GetMouseButtonDown(0)){
			CheckClick("left");
		}else if(Input.GetMouseButtonDown(1)){
			CheckClick("right");
		}
	}


	private void RightClick(Transform trans, Vector3 loc){

	}
	private void LeftClick(Transform trans, Vector3 loc){

	}

	private void CheckClick(string side){
		RaycastHit hit = new RaycastHit();
		Ray ray = detectionCamera.ScreenPointToRay(Input.mousePosition); 

		LayerMask mask;
		switch(side){
			case "left":
				mask = leftClickLayerMask;
				break;
			case "right":
				mask = rightClickLayerMask;
				break;
			default:
				return;
		}
		
		if(Physics.Raycast (ray, out hit, Mathf.Infinity,mask)){
			if(debug) Debug.Log("You "+side+" clicked " + hit.collider.gameObject.name,hit.collider.gameObject);	

			switch(side){
				case "left":
					LeftClick(hit.transform,hit.point);
					break;
				case "right":
					RightClick(hit.transform,hit.point);
					break;
				default:
					return;
			}
		}
	}
}
