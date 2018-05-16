using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour {

	public GameObject playerHand;
	public GameObject EquippedWeapon { get; set; }

	Vector3 pos = new Vector3(-0.1f, 0.7f, 0f);

	public Transform spawnProjectile;

	//an IWeapon called weaponEquipped
	IWeapon weaponEquipped;

	//creates a variable of type CharacterStat called characterStats
	CharacterStat characterStats;

	void Start()
	{
		//sets the spawnProjectile point by using FindChild t0 find the name of the object
		//Projectile Spawn is the name of the empty gameobject that is a chile of Player
		spawnProjectile = transform.Find("ProjectileSpawn");
		//Creates a new instance of characterStats getting the information from the CharacterStat list
		characterStats = GetComponent<CharacterStat> ();
	}

	//public method for equipping weapons. Can be copied and editted easily to equip other things such as armour
	//passes in an item called itemToEquip
	public void EquipWeapon(Item itemToEquip)
	{
		//check if there is an item already equipped
		if (EquippedWeapon != null)
		{
			//removes any stats from previously assigned weapons
			//passes in the list of stats to remove using the IWeapon interface
			characterStats.RemoveStatBonus(EquippedWeapon.GetComponent<IWeapon>().stats);
			//destroy the item in the players hand
			Destroy(playerHand.transform.GetChild(0).gameObject);
		}

		//equip the weapon
		//sets the equipped weapon as a game object instantiated from the 
		//resources folder (where weapon prefabs were saved)
		//Loads the weapon from the weapon folder using the name found in itemToEquip
		//instantiates it in the players hand and gets the position from the transform of the player hand object
		EquippedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Weapons/" + itemToEquip.objectslug), 
			playerHand.transform.position + pos, playerHand.transform.rotation);

		weaponEquipped = EquippedWeapon.GetComponent<IWeapon>();

		//checks to see if the weapon is a projectile weapon
		//future versions of this will use item type
		if(EquippedWeapon.GetComponent<IProjectileWeapon>() != null)
		{
			//tells the equipped weapon that it has a projectile spawn
			EquippedWeapon.GetComponent<IProjectileWeapon> ().ProjectileSpawn = spawnProjectile;
		}

		//copies the stats list to the equipped weapon
		//this is so the stats can be removed again when the weapon is unequipped
		weaponEquipped.stats = itemToEquip.stats;
		//sets the transform of the sword as a child of the playerHand
		EquippedWeapon.transform.SetParent(playerHand.transform);
		//passes the stats of the itemToEquip to the characterStats to Add the stat bonus
		characterStats.AddStatBonus(itemToEquip.stats);

		//to check that the weapon is equipped in the console log
		Debug.Log(weaponEquipped.stats[0].GetCalculatedStatValue());

	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.X))
			PerformWeaponAttack();

		//this is for a special attack is needed
		//if (Input.GetKeyDown (KeyCode.Z))
			//PerformSpecialWeaponAttack();
	}


	//perform this method whenever the attack key is pressed
	public void PerformWeaponAttack()
	{
		//PerformAttack is a method found on the actual weapon that has been equipped
		//look at the sword script for an example
		weaponEquipped.PerformAttack();
	}

	//also for the special weapon attack
	//public void PerformSpecialWeaponAttack()
	//{
		//weaponEquipped.PerformSpecialAttack();
	//}
}
