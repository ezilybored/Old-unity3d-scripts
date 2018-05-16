using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCastProjectile : MonoBehaviour, IWeapon, IProjectileWeapon {

	public List<BaseStat> stats { get; set; }

	public Transform ProjectileSpawn { get; set; }

	public Transform FirePoint;

	//have created a type called fireball using the fireball script
	//This creates a variable of type FireBall called fireball
	public FireBall fireball;

	void Start()
	{
		//fireball = Resources.Load<FireBall> ("Weapons/Projectiles/FireBall");
	}

	public void PerformAttack()
	{

	}

	public void CastProjectile()
	{
		//Passes information to the spawned fireball and instantiates it
		FireBall fireballInstance;
		fireballInstance = (FireBall)Instantiate(fireball, FirePoint.position, FirePoint.rotation);
		fireballInstance.Direction = FirePoint.forward;
	}

}
