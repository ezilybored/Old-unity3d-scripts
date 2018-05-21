using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.EventSystems;

//This script needs to be dropped onto the player GameObject in the inspector

public class PlayerMovementController : MonoBehaviour
{
	//public Interactable class called focus
	public Interactable focus;

	//Used for facing the target
	//public Vector3 target;

	//reference to the main camera
	Camera cam;

	//This references the Interact panel UI
	public GameObject interactPanelUI;

	public GameObject inventoryUI;
	
	//set up a reference to the name text box from the interactPanelUI
	//This needs to be assigned in the inspector
	//Only needs to be assigned once if set up here
	public Text interactName; 

	//set up a reference to the interaction message from the interactPanelUI
	//This needs to be assigned in the inspector
	//Only needs to be assigned once if set up here
	public Text interactMessage;

	//sets the goal for the NavMeshAgent
	private Vector3 goal;
	//Calls the NavMeshAgent
	private NavMeshAgent agent;

	void Start()
	{
		//Cursor.visible = false;

		//Sets the goal as the transform.position of the player
		goal = transform.position;
		//gets the NavMeshComponent for the player
		agent = GetComponent<NavMeshAgent> ();
	}

	void Update ()
	{
		//freezes the player when the inventory is open
		//This will need to be added to all NPC and enemies etc
		if (inventoryUI.activeSelf == true) 
		{
			return;
		}
			
		//sets the goal for the NavMesh using the WASD keys
		goal = transform.position
		+ Vector3.right * Input.GetAxis ("Horizontal")
		+ Vector3.forward * Input.GetAxis ("Vertical");

		agent.destination = goal;
								
	}

	void OnTriggerEnter(Collider col)
	{
		//checks for the Interactable tag on the the object who's collider we just entered
		if (col.tag == "Interactable")
		{
			//Stores the interactable that has been entered as a new Interactable instance
			Interactable interactable = col.GetComponent<Interactable> ();
			//Debug.Log ("This object is: " + col.gameObject.name);
			
			//Want to get the scriptable object data from the collider enetered
			Item item = col.GetComponent<Item> ();
			Debug.Log ("This object is: " + col.gameObject.name);
			
			//Sets these two values from the Scriptable Object attached to the Item that the player has entered the collider of
			interactName.text =  item.name;
			interactMessage.text = item.description;

			//used to set the transfrom Vector3 of the target collider
			//target = col.transform.position;

			//If we have hit an interactable, set it as the focus of the player
			if (interactable != null) 
			{
				//brings up the interact panel UI
				interactPanelUI.SetActive(true);

				SetFocus (interactable);
				//FaceTarget ();
			}


		}
	}

	void OnTriggerExit(Collider col)
	{
		{
			//closes the interact panel UI
			interactPanelUI.SetActive(false);

			RemoveFocus ();
		}
	}

	//Sets the focus of the Player as a new Interactable called newFocus
	//Maybe use this to trigger a UI event where a screen pops up and asks if the player wants to interact with the
	//object
	void SetFocus (Interactable newFocus)
	{
		//if the newFocus is not the focus
		if (newFocus != focus) 
		{
			if(focus != null)
			//then calls onDefocus from Interactable
				focus.OnDefocused ();
			
			//and sets the correct focus
			focus = newFocus;

		}

		focus = newFocus;
		//Calls OnFocused from Interactable
		newFocus.OnFocused (transform);

	}

	//Removes the focus of the player from the object
	void RemoveFocus ()
	{
		if (focus != null)
		//Calls OnDefocused from Interactable
			focus.OnDefocused();
		focus = null;
	}

	//Sets the player to face the interactable target
	//Only set this when the interaction button has been pressed
	//set target to be the interacting object at some point
	/*void FaceTarget()
	{
		Vector3 direction = (target - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation (new Vector3(direction.x, 0f, direction.z));
		transform.rotation = Quaternion.Slerp (transform.rotation, lookRotation, Time.deltaTime * 5f);
	}*/

}
	
