using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Token : MonoBehaviour {
	public TokenView view = null;
	public Nation nation;

	public static Token selectedToken{get;set;}

	void Awake(){
		view = gameObject.GetComponent<TokenView>();
	}

	abstract public int GetValue();

	public void Die(){Destroy(gameObject);}
}
