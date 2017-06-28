using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NationFactory : MonoBehaviour {
	public static NationFactory Instance;
	void Awake () {if(Instance == null) Instance = this;}
	
	private int colorIndex = 0;
	public Color[] colors;
	
	public Nation Get(string name){
		var nation = new Nation();
		nation.name = name;
		nation.color = getNextColor();
		return nation;
	} 
	private Color getNextColor(){
		if(colors.Length > colorIndex)
			return colors[colorIndex++];
		return Color.black;
	}
}
