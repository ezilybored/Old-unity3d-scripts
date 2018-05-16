using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	//Need to have a reference to the item that the NPC/GameObject is trying to give to the player
	//Could take this from the collider data or from a trigger
	//Have a public variable reference to the item on the NPC/GameObject called itemPresenting maybe

	//This is a reference to the players inventory. This needs to be assigned in the inspector.
	//created using InventoryItemEditor button
	public InventoryItemList inventoryItemList;
	//Starts the list at count 1
	private int viewIndex = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Use this to add items to the players inventory
	void AddItem () 
	{
		//Creates a new inventoryItem using the data from the NPC inventory
		inventoryItem = //Here is where the reference to the item is added
		//Adds the item to the inventory
		inventoryItemList.itemList.Add (inventoryItem);
		//Increases the count of the inventory
		viewIndex = inventoryItemList.itemList.Count;
	}
}
