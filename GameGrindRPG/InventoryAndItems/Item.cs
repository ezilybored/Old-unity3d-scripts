using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is an object with a few properties. It does not need to inherit from monobehaviour
public class Item 
{
	//creates a list of BaseStats called stats (again)
	public List<BaseStat> stats { get; set; }
	//This will allow you to use the same art asset prefab but giving it different stats to be different items
	//in the game. This "ObjectSlug" is a definer for the object.
	//E.g. having a "sword" and a "great sword" and the model is the same but the stats are different
	public string objectslug { get; set; }
	//description for inventory
	public string Description { get; set; }
	//what you can do with the Item. Probably a button. Can be replicated to give multiple options
	public string ActionName { get; set; }
	//The name of the item
	public string ItemName { get; set; }
	//Does this item have a modifier that needs to access the player stats
	public bool ItemModifier { get; set; }



	//passes in the List of BaseStats called _stats this time
	public Item(List<BaseStat> _stats, string _objectslug)
	{
		this.stats = _stats;
		this.objectslug = _objectslug;
	}

	//Gets all of this information from the Json database file
	[Newtonsoft.Json.JsonConstructor]
	public Item(List<BaseStat> _stats, string _objectslug, string _description, string _actionName, string _itemName, bool _itemModifier)
	{
		this.stats = _stats;
		this.objectslug = _objectslug;
		this.Description = _description;
		this.ActionName = _actionName;
		this.ItemName = _itemName;
		this.ItemModifier = _itemModifier;
	}

}
