using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour, IEnemy {

	public float maxHealth, power, toughness;
	public float currentHealth;

	void Start ()
	{
		currentHealth = maxHealth;
	}

	public void PerformAttack()
	{

	}

	public void TakeDamage(int amount)
	{
		currentHealth -= amount;
		if (currentHealth <= 0) 
			Die();
	}

	void Die()
	{
		//can add an animation in here for the enemy to die
		Destroy (gameObject);
	}
}
