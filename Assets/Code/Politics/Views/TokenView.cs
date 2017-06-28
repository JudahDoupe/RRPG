using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenView : MonoBehaviour {
	private SpriteRenderer sprite = null;
	public TextMesh number = null;
	private Token token = null;

	void Start(){
		token = gameObject.GetComponent<Token>();
		if(token == null){
			Debug.Log("A TokenView must exist on the same GameObject as a Token.");
			Destroy(this);
		}
		sprite = gameObject.GetComponent<SpriteRenderer>();
		if(sprite == null){
			Debug.Log("A TokenView must exist on the same GameObject as a SpriteRenderer.");
			Destroy(this);
		}
		if(number == null){
			Debug.Log("A TokenView must have a TextMesh.");
			Destroy(this);
		}
		number.gameObject.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("TextMesh");
	}

	void Update(){
		UpdateColor();
		UpdateNumber();
	}
	private void UpdateColor(){
		if(Token.selectedToken == token){
			sprite.color = Color.white;
			number.color = Color.black;
		}
		else{
			sprite.color = token.nation.color;
			number.color = Color.white;
		}
	}
	private void UpdateNumber(){
		number.text = "";
		number.text += token.GetValue();
	}
}
