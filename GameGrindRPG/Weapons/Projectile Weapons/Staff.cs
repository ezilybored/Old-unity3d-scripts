using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is adapted from sword.cs
//C# can only inherit from one class but can inherit from as many interfaces as you like
public class Staff : MonoBehaviour, IWeapon, IProjectileWeapon {

	//references the Hand animator script
	private Animator animator;

	public List<BaseStat> stats { get; set; }

	public Transform ProjectileSpawn { get; set; }

	//have created a type called fireball using the fireball script
	//This creates a variable of type FireBall called fireball
	//FireBall fireball;

	void Start()
	{
		//fireball = Resources.Load<FireBall> ("Weapons/Projectiles/FireBall");
		animator = GetComponentInParent<Animator>();
	}

	//Can create separate methods for different attack types.
	//just use this method again with a new name and link to key press/condition in PlayerWeaponController script
	public void PerformAttack()
	{
		//BaseProjectileAttack is the name of the tranistion in the animator
		animator.SetTrigger("BaseProjectileAttack");
		//animator.SetTrigger("ProjectileAttack");
	}

	public void CastProjectile()
	{
		//Passes information to the spawned fireball and instantiates it
		//FireBall fireballInstance = (FireBall)Instantiate(fireball, ProjectileSpawn.position, ProjectileSpawn.rotation);
		//fireballInstance.direction = ProjectileSpawn.forward;
	}
}
