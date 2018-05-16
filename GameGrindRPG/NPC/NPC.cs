using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a class for NPC's derived from Interactable class that inherits its properties not from Monobehaviour
public class NPC : Interactable {
	//assigns dialogue for the NPC to use
	public string[] dialogue;
	//the name of the NPC
	public string NpcName;
	//This can override the Interact method found in the base Interactable base class
	public override void Interact()
	{
		//accesses the Instance of Dialogue system class
		//adds new dialogue to this instance
		//passes in the contents of the public string array that can be populated in the inspector
		//also passes in the name of the NPC
		DialogueSystem.Instance.AddNewDialogue(dialogue, NpcName);
		//Prints this message to the console when the class is interacting
		Debug.Log ("Interacting with NPC");
	}


}
