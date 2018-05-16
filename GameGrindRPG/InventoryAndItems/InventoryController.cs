using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This will eventually be the controller for the inventory
public class InventoryController : MonoBehaviour {

	//This is a singleton. Where only one instance of an object is allowed to be created
	public static InventoryController Instance { get; set; }

	//refereces the player weapon controller. Assigned in the inspector.
	public PlayerWeaponController playerWeaponController;
	//refereces the player consumable controller. Assigned in the inspector.
	public ConsumableController consumableController;

	//Not needed any more. Commented out for now in case I need it again.
	/*
	public Item sword;
	public Item potionLog;
	*/

	void Start()
	{
		//if instance is not null and also not this instance. Essentially another Instance of InventoryController
		if (Instance != null && Instance != this)
			//destroy the other gameobject
			Destroy (gameObject);
		else
			//set the instance to this instance of the InventoryController
			Instance = this;

		//assigns the player weapon controller from the class PlayerWeaponController
		playerWeaponController = GetComponent<PlayerWeaponController>();
		//assigns a consumable controller from the class ConsumableController
		consumableController = GetComponent<ConsumableController>();

		//This is all from the testing stages
		/*
		//Creates a list called swordStats from the BaseStat list
		List<BaseStat> swordStats = new List<BaseStat> ();
		//Creates a new sword stat called Power of value 6. Assigned as in CharacterStat class
		swordStats.Add (new BaseStat (6, "Power", "Your power level"));
		//Creates a new sword Item using the stats from swordStats and gives it the name sword
		//This is a variation on it for now with sword changed to Staff
		sword = new Item (swordStats, "Staff");
		//Creates a new item called potionLog
		potionLog = new Item (new List<BaseStat>(), "PotionLog", "Drink this to Log something", "Drink", "Log Potion", false);
		*/
	}








	//This was all from the original testing stages of the Inventory controller and set up of the weapon system
	/*void Update()
	{
		//when the v key is pressed
		if (Input.GetKeyDown (KeyCode.V)) 
		{
			//the playerWeaponController is assigned the sword
			playerWeaponController.EquipWeapon (sword);
			//consumes the item assigned using the v key (currently assigned to be the PotionLog by default)
			consumableController.ConsumeItem(potionLog);
		}
	}*/

}
