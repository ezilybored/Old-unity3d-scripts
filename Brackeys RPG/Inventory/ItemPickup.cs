using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script is dropped on each item in the game

//Dervies from Interactable script
public class ItemPickup : Interactable {

	//This is a public reference to the scriptable object of the same name.
	//This is assigned in the inspector
	public Item item;

	//This references the Interact panel UI so that it can be closed when the item is picked up
	//This needs to be dragged and dropped onto the item in the inspector
	public GameObject interactPanelUI;

	//set up a reference to the name text box from the interactPanelUI
	//This needs to be assigned in the inspector
	//Now assigned in PlayerMovementController
	//public Text interactName; 

	//set up a reference to the interaction message from the interactPanelUI
	//This needs to be assigned in the inspector
	//Now assigned in PlayerMovementController
	//public Text interactMessage;

	void Start()
	{

	}

	public override void Interact()
	{
		base.Interact ();

		PickUp ();
	}

	void PickUp()
	{
		Debug.Log ("Picking up " + item.name);

		//checks to see if item was added. true if yes, false if no
		bool wasPickedUp = Inventory.instance.Add(item);

		if (wasPickedUp) 
		{
			Destroy (gameObject);
			//closes the interact panel UI
			interactPanelUI.SetActive(false);
		}
	}

	//When the player enters another GameObject collider. The other object must have a collider
	//The player GameObject collider must be set to trigger the same for the other GameObject
	//All moved to PlayerMovementController script now
	/*void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") 
		{
			//Change the Interact text using the item description text from the item scriptable object
			interactName.text =  item.name;
			interactMessage.text = item.description;
		}
	}*/

}
