using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Military : Token, IDamagable {
	public int size = 1;

	public void Attack(IDamagable enemy){
		int casualties = 0;

		for(int i=0; i<size;i++){
			int attack = Dice.Roll(5);
			int defend = Dice.Roll(3);
			if(attack > defend) casualties++;
		}

		enemy.Damage(casualties);
	}

	public void Damage(int amount){
		size -= amount;
		if(size <= 0) Die();
	}
	public void Reinforce(int amount){size += amount;}

	public override int GetValue(){return size;}
}
