using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	public static UIManager Instance =  null;
	void Awake () {if(Instance == null) Instance = this;}

	public Text goldText;
	public string selectedButton = "";

	void Update(){
		updateGoldForCurrentNation();
	}

	public void ToggleReinforce(){Toggle("Reinforce");}
	public void ToggleMilitary(){Toggle("Military");}
	public void ToggleCity(){Toggle("City");}
	public void ToggleResource(){Toggle("Resource");}
	
	private void Toggle(string button){
		if(selectedButton != button)selectedButton = button;
		else ResetButtons();
	}

	public void ResetButtons(){selectedButton = "";}
	public string GetSelectedButton(){return selectedButton;}

	private void updateGoldForCurrentNation(){
		goldText.text = "Gold:"+0;
	}
}
