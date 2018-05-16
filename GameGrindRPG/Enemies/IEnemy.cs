using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy 

{
	//method to allow the enemy to take damage
	void TakeDamage (int amount);
	//method to allow the enemy to attack
	void PerformAttack ();

}
