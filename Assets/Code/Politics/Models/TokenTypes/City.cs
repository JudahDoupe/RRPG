using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : Token, IDamagable {
	public int health = 20;
	public int maxHealth = 20;

	public void Damage(int amount){
		health -= amount;
		if(health <= 0) Die();
	}
	public void Reinforce(int amount){
		health += amount;
		if(health > maxHealth) health = maxHealth;
	}

	public override int GetValue(){return health;}
}
