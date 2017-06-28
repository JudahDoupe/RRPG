using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {
	public static TurnManager Instance =  null;
	void Awake () {if(Instance == null) Instance = this;}

	private Nation currentNation = null;
	private int turn = 0;

	public Nation GetCurrentNation(){return currentNation;}

	void Start(){
		turn = -1;
		NextTurn();
	}

	public void NextTurn(){
		Nation[] nations = NationManager.Instance.nations.ToArray();
		if(isGameOver(nations)) return;
		turn = (turn+1)%nations.Length;
		currentNation = nations[turn];
	}
	private bool isGameOver(Nation[] nations){
		if(nations.Length == 1){
			EndGame(nations[0].name+" Wins!");
			return true;
		}else if (nations.Length == 0){
			EndGame("Tie!");
			return true;
		}else if(!isHumanPlayerLeft()){
			EndGame("No More Human Players");
			return true;
		}else return false;
	}
	private bool isHumanPlayerLeft(){
		return true;
	}
	private void EndGame(string message){
		currentNation = null;
		Debug.Log(message);
	}
}
