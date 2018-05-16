﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : Interactable {

	//This can override the Interact method found in the base Interactable base class
	public override void Interact()
	{
		//Prints this message to the console when the class is interacting
		//This also overrides the Interact method found in the ActionableItem class
		Debug.Log ("Performing action with Crate");
	}
}
