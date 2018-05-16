using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldInteraction : MonoBehaviour {

	NavMeshAgent playerAgent;

	void Start()
	{
		//Sets the playerAgent variable using the component from the NavMeshAgent
		playerAgent = GetComponent<NavMeshAgent>();
	}

	void Update()
	{
		//When mouse button is pressed
		// And also if the mouse is not pointing at any UI element
		if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
			GetInteraction ();
	}

	void GetInteraction()
	{
		//sends a Ray called interactionRay from the main camera to wherever the mouse has clicked
		Ray interactionRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		//Creates a store for the information recieved from the ray
		RaycastHit interactionInfo;
		if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
		{
			//Stores the object hit by the raycast by working backwards through the object, it's collider, then it's name
			//stores this as a new GameObject called interactedObject
			GameObject interactedObject = interactionInfo.collider.gameObject;

			//sets the move and interaction for enemy objects
			if(interactedObject.tag == "Enemy")
			{
				Debug.Log ("Move to enemy");
				interactedObject.GetComponent<Interactable> ().MoveToInteraction (playerAgent);
			}

			//if the GameObject hit has the tag Interactable Object
			if (interactedObject.tag == "Interactable Object")
			{
				//Grabe the Interactable instance from the interactedObject. 
				//Lets the player know what interactions are allowed with this interactableObject
				//Moves the player to the interactable object
				interactedObject.GetComponent<Interactable>().MoveToInteraction(playerAgent);
			}
			else
			{
				//Creates a path to the object the ray is pointing to. (If the object is not interactable)
				//This will move them along the NavMesh to the GameObject
				playerAgent.stoppingDistance = 0f;
				playerAgent.destination = interactionInfo.point;
			}
		}
	}


}
