using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NationManager : MonoBehaviour {
	public static NationManager Instance =  null;
	void Awake () {if(Instance == null) Instance = this;}

	public List<Nation> nations = new List<Nation>();

	public Nation[] GetAllNations(){return nations.ToArray();}
	public Nation GetNationByName(string name){
		foreach(Nation n in nations){
			if(n.name == name){
				return n;
			}
		}
		return null;
	}
}
