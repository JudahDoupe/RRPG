using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : Token, IDamagable {
	public int workers = 1;

	public int Collect(){return workers * 5;}

	public void Damage(int amount){
		workers -= amount;
		if(workers <= 0) workers = 0;
	}
	public void Reinforce(int amount){workers += amount;}

	public override int GetValue(){return workers;}
}
