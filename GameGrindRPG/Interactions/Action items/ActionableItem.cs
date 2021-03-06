﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionableItem : Interactable {

	public string[] dialogue;

	public string itemName;

	//This can override the Interact method found in the base Interactable base class
	public override void Interact()
	{
		DialogueSystem.Instance.AddNewDialogue (dialogue, itemName);
		//Prints this message to the console when the class is interacting
		Debug.Log ("Performing action with Item");
	}
		
}
