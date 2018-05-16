using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectileWeapon
{
	//references the projectile spawn point
	Transform ProjectileSpawn { get; set; }

	//method to spawn the projectile
	void CastProjectile();

}
