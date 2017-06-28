using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenFactory: MonoBehaviour{
	public static TokenFactory Instance;
	void Awake () {if(Instance == null) Instance = this;}
	
	public GameObject cityToken;
	public GameObject militaryToken;
	public GameObject resourceToken;
	
	public Token GetNew<T>(Nation nation, Vector3 location) where T : Token {
		var tokenObj = GameObject.Instantiate(getTokenObject<T>());
		tokenObj.transform.position = location;
		var token = tokenObj.GetComponent<T>();
		token.nation = nation;

		return token;
	} 
	private GameObject getTokenObject<T>() where T : Token{
		System.Type type = typeof(T);
		switch(type.ToString()){
			case "City":
				return cityToken;
			case "Military":
				return militaryToken;
			case "Resource":
				return resourceToken;
			default:
				return new GameObject();
		}
	}

}
