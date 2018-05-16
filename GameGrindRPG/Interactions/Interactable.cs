using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//This is the basic interactable class that all actual interactions are derived from
public class Interactable : MonoBehaviour {
	[HideInInspector]
	public NavMeshAgent playerAgent;
	//keeps track of whether the interaction has happened or not
	private bool hasInteracted;
	//boolean to check if an object is an enemy
	bool isEnemy;

	//Moves the player to the interactable object. (This won't be needed in the final version.)
	public virtual void MoveToInteraction(NavMeshAgent playerAgent)
	{
		//checks to see if interactable is an enemy using the tag Enemy
		isEnemy = gameObject.tag == "Enemy";
		//sets the interaction tracker to false
		hasInteracted = false;
		//this. is used to refer to the instance of playerAgent that is currently running on the interactable object
		this.playerAgent = playerAgent;
		//stops the player before they get to the interactable object
		playerAgent.stoppingDistance = 2.5f;
		//sets the destination of the player to be the current transform position of this interactable object
		playerAgent.destination = this.transform.position;

		//Calls the Interact method. This is commented out to allow for it to be called in Update below
		//Interact ();
	}

	//Checks to see that the player has reached its destination before triggering the interaction
	void Update()
	{
		//if the playerAgent exists and also does not have a movement path pending
		if (!hasInteracted && playerAgent != null && !playerAgent.pathPending)
		{
			//remaining distance is the distance between the playerAgent and the destination
			//is this less than the stopping distance?
			if (playerAgent.remainingDistance <= playerAgent.stoppingDistance)
			{
				//if it is not an enenmy
				if (!isEnemy) 
					Interact ();
				EnsureLookDirection ();
				hasInteracted = true;
			}
		}
	}

	//makes sure the player is facing the object
	void EnsureLookDirection()
	{
		//disables auto rotation updating from navagent
		playerAgent.updateRotation = false;
		//draws a vector between the enemy and the player
		Vector3 lookDirection = new Vector3 (transform.position.x, playerAgent.transform.position.y, transform.position.z);
		//uses LookAt method to point the player in the direction of the vector3
		playerAgent.transform.LookAt (lookDirection);
		//re-enables the rotation updating
		playerAgent.updateRotation = true;
	}

	public virtual void Interact()
	{
		Debug.Log ("Interacting with base class");
	}



}
