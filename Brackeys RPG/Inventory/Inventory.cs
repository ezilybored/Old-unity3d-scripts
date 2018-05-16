using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is placed on the GameManager GameObject

public class Inventory : MonoBehaviour {

	//Uses a singleton to create the inventory
	//Not sure if this what I want again. Surely scriptabel object inventory is better

	#region Singleton
	public static Inventory instance;

	void Awake()
	{
		if (instance != null) 
		{
			Debug.LogWarning ("There is more than one instance of Inventory");
			return;
		}
		//sets the instance of the inventory equal to this instance. Ensure there is only one copy
		//You will always be able to access the inventory by typing Inventory.instance
		instance = this;
	}

	#endregion

	//Create a delegate type. These allow multiple methods to be called when they are triggered
	public delegate void onItemChanged();
	//The onItemChangedCallback is the event that is to be triggered
	public onItemChanged onItemChangedCallback;


	//sets the size of the inventory
	public int space = 20;

	//Creates a new list of Items called items
	public List<Item> items = new List<Item> ();

	//returns false of no item to pick up, true if there is
	public bool Add (Item item)
	{
		//if the item is not a default item
		if(!item.isDefaultItem)
		{
			//checks if there is enough room in the inventory
			if (items.Count >= space) 
			{
				Debug.Log ("Not enough room");
				return false;
			}

			//Adds item to the list of items
			items.Add (item);

			//When anything changes on the inventory the onItemChangedCallback event is triggered

			if (onItemChangedCallback != null) 
				//This triggers the delegate event
				onItemChangedCallback.Invoke ();
		}

		return true;
	}

	//Removes items
	public void Remove (Item item)
	{
		//Removes item from the list of items
		items.Remove (item);

		if (onItemChangedCallback != null) 
			//This also triggers the delegate event
			onItemChangedCallback.Invoke ();
	}
}
