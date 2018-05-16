using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//C# can only inherit from one class but can inherit from as many interfaces as you like
public class Sword : MonoBehaviour, IWeapon {

	//references the animator script
	private Animator animator;

	public List<BaseStat> stats { get; set; }

	void Start()
	{
		//gets the animator component
		animator = GetComponentInParent<Animator>();
	}

	//Can create separate methods for different attack types.
	//just use this method again with a new name and link to key press/condition in PlayerWeaponController script
	public void PerformAttack()
	{
		//Debug.Log ("Sword attack");
		//BaseMeleeAttack is the name of the tranistion in the animator
		animator.SetTrigger("BaseMeleeAttack");

	}
	//special weapon attack
	//public void PerformSpecialAttack()
	//{
	//animator.SetTrigger("SpecialMeleeAttack");

	//}

	//method to check to see whether the sword has entered another collider
	//This can be used for my interaction system later on for when the player enters an objects area of infuence
	//Just checks on entering
	void OnTriggerEnter(Collider col)
	{
		//Debug.Log ("Hit: " + col.name);

		if(col.tag == "Enemy")
		{
			//gets the component IEnemy from whatever object the sword collided with that is tagged with "Enemy"
			//The performs TakeDamage method using the value from GetCalculatedStatsValue found in PlayerWeaponController
			col.GetComponent<IEnemy>().TakeDamage(stats[0].GetCalculatedStatValue());
		}
	}



}
