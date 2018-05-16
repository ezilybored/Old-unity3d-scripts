using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//added so lists can be used


//allows the use of the UI namespace
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {
	public static DialogueSystem Instance { get; set; }
	//public Gameobject link to the UI elements of the dialoguePanel
	public GameObject dialoguePanel;
	//name of the NPC
	public string NpcName;
	//public list of strings called dialgoueLines
	public List<string> dialogueLines = new List<string>();

	Button continueButton;
	Text dialogueText, nameText;
	int dialogueIndex;

	void Awake()
	{
		//Finds the Continue button by looking for the name (FindChild) of the button as it is a child
		//of the dialoguePanel that was passed into this script in the inspector
		continueButton = dialoguePanel.transform.Find ("ContinueButton").GetComponent<Button> ();

		//Finds the Text by looking for the name (FindChild) of the Text as it is a child
		//of the dialoguePanel that was passed into this script in the inspector
		dialogueText = dialoguePanel.transform.Find ("Text").GetComponent<Text> ();

		//Finds the Name Text by looking for the name (FindChild) of the Name as it is a child
		//of the dialoguePanel that was passed into this script in the inspector.
		//It then looks for the Text as this is a child of the Name and gets that component
		nameText = dialoguePanel.transform.Find ("NPCnamePanel").GetChild (0).GetComponent<Text> ();

		//onClick is a listener for the button click event. This can be done in the event system as well
		//as in code
		//not sure what the delegate bit is about to be honest
		//this essentially makes the contnue button work in the dialogue window
		continueButton.onClick.AddListener(delegate { ContinueDialogue(); });

		//sets the start state of the dialogue panel to be switched off
		dialoguePanel.SetActive (false);
		
		//If an instance exists that is not this instance. Looks for other running dialogue system instances
		if (Instance != null && Instance != this) 
		{
			//destroy that gameobject that is running the instance of the dialogue system
			Destroy (gameObject);
		} 
		else 
		{
			//this is the instance of dialogue system to use
			Instance = this;
		}
	}

	//New method to add new dialogue. Takes a string called lines as an arguement
	public void AddNewDialogue(string[] lines, string NpcName)
	{
		//THIS COULD BE WHERE TO ADD AN IF STATEMENT TO LOOK FOR CERTAIN CONDITIONS
		//TO SET WHICH BRANCH OF A CONVERSATION TREE TO FOLLOW
		//MAYBE SET THE DIALOGUE INDEX DEPENDING ON WHAT TREE YOU ARE AT

		//ALTERNATIVELY CREATE NEW VERSIONS OF EACH NPC WITH DIFFERENT DIALOGUE AFTER EACH BRANCH IS EXHAUSTED

		//ALTERNATIVELY AGAIN USE THE DIALOGUE AND ITEM SYSTEM FROM THE UNITY TUTORIAL


		//sets the dialogue index to 0 so it starts at line 1
		dialogueIndex = 0;
		//creates a new empty list each time this is called
		dialogueLines = new List<string> (lines.Length);
		dialogueLines.AddRange (lines);
		//adds
		//foreach (string line in lines) 
		//{
		//	dialogueLines.Add (line);
		//}
		//the name of the NPC in this instance
		this.NpcName = NpcName;

		CreateDialogue ();

	}

	//enables and assigns text values to the UI dialogue panel
	public void CreateDialogue()
	{
		//sets the text as the first entry in the Lines array
		dialogueText.text = dialogueLines [dialogueIndex];
		//sets the NPC name in the dialogue UI panel
		nameText.text = NpcName;
		//activates the dialogue UI panel
		dialoguePanel.SetActive(true);
	}

	public void ContinueDialogue()
	{
		if (dialogueIndex < dialogueLines.Count - 1) {
			//progresses the dialogue index
			dialogueIndex++;
			//sets the new dialogue text to corespond to the new index
			dialogueText.text = dialogueLines [dialogueIndex];

		} 
		else 
		{
			//if it is the last bit of dialogue set it to false
			dialoguePanel.SetActive(false);
		}
	}


}
