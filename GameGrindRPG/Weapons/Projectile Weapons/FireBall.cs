using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {
	public Vector3 Direction { get; set; }
	public float Range { get; set; }
	public int Damage { get; set; }

	Vector3 spawnPosition;

	void Start()
	{
		//sets the value of the range of the fireball
		Range = 20f;
		//sets the damage value of the fireball
		Damage = 4;
		//gives the spawn position of each fireball
		spawnPosition = transform.position;
		//adds the force to the rigidbody
		GetComponent<Rigidbody>().AddForce(Direction * 50f);
	}

	void Update()
	{
		if(Vector3.Distance(spawnPosition, transform.position) >= Range)
		{
			//calls extinguish fnction when the fireball exceeds the distance of Range
			extinguish();
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if(col.transform.tag == "Enemy")
		{
			//gets the information about the enemy by getting the IEnemy component from the collision tagged object
			//Then accesses the TakeDamage method and uses the variable Damage to assign how much damage is done
			col.transform.GetComponent<IEnemy> ().TakeDamage (Damage);
		}
		//extinguishes the fireball whether it hits an enemy or not
		extinguish();
	}

	void extinguish()
	{
		//can add a sound effect or animation here
		Destroy (gameObject);
	}


}
