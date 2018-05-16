using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is dropped on the InventoryUI parent GameObject

public class InventoryUI : MonoBehaviour {

	//references the ItemsParent parent object
	public Transform itemsParent;

	//references the whole Inventory UI. Assigned in the inspector
	public GameObject inventoryUI;

	//references the inventory. Assigned in the inspector.
	Inventory inventory;

	//creates an array of InventorySlot called slot
	InventorySlot[] slots;

	void Start () 
	{
		inventory = Inventory.instance;	
		//When the inventory item has been added or removed this is called which then calls UpdateUI
		inventory.onItemChangedCallback += UpdateUI;

		//sets the array equal to the children of ItemsParent that are of type InventorySlot
		//This only works with a static number of slots.
		//Further work required to have a dynamic inventory
		slots = itemsParent.GetComponentsInChildren<InventorySlot> ();
	}
	

	void Update () 
	{
		//If the button to activate the inventory is pressed
		if (Input.GetButtonDown ("Inventory")) 
		{
			//reverses the SetActive property of the inventoryUI
			inventoryUI.SetActive (!inventoryUI.activeSelf);
		}
	}

	void UpdateUI()
	{
		//Search for all inventory slots. This is easy as they are all children of ItemsParent
		//all children can be found by referencing ItemsParent

		//a for loop to loop through the slots
		for (int i = 0; i < slots.Length; i++) 
		{
			//If there is an available slot
			if (i < inventory.items.Count) 
			{
				slots [i].AddItem (inventory.items [i]);
			} 
			else 
			{
				slots [i].ClearSlot ();
			}
		}

	}
}
