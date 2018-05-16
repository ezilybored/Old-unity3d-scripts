using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is placed on the player gameobject
public class ConsumableController : MonoBehaviour {

	CharacterStat stats;

	void Start()
	{
		//gets the character stats from the player gameobject
		stats = GetComponent<CharacterStat> ();
	}

	//method for consuming the Item. Passses the Item to consume into the method
	public void ConsumeItem(Item item)
	{
		//Spawns the consumable item by searching for it in the resources folder in the Consumables directory
		GameObject itemToSpawn = Instantiate(Resources.Load<GameObject>("Consumables/" + item.objectslug));
			//searches to see if there is an item modifier
			if(item.ItemModifier)
			{
				//searches for the IConsumable on the item
				//consumes and effects stats
				itemToSpawn.GetComponent<IConsumable>().Consume(stats);
			}
			else
				itemToSpawn.GetComponent<IConsumable>().Consume();
	}
}
