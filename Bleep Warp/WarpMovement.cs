using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
	{
		public float xMin, xMax, zMin, zMax; //Calls public values for clamping the ship
	}

public class WarpMovement : MonoBehaviour 

{
	//flag to check if the user has tapped / clicked. 
	//Set to true on click. Reset to false on reaching destination
	private bool flag = false;
	//destination point
	private Vector3 endPoint;
	//alter this to change the speed of the movement of player / gameobject
	public float duration = 50.0f;
	//vertical position of the gameobject
	private float yAxis;

	public Vector3 playerPosition;

	public Boundary boundary;

	//Here I need to set a public float to keep hold the value for warp power


	void Start()

		{
			//save the y axis value of gameobject
			yAxis = gameObject.transform.position.y;

			playerPosition = gameObject.transform.position;

		//Here I need to assign a start value for the warp power


		}

	// Update is called once per frame
	void Update () 

		{

			playerPosition = gameObject.transform.position; //gets the player position at the start of each update

			
		if((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || (Input.GetMouseButtonDown(0))) //check if the screen is touched / clicked   

			//Here I also need to compare to see if the warp power is bigger than 0
			
				{
					
					RaycastHit hit; //declare a variable of RaycastHit struct
					
					Ray ray; //Create a Ray on the tapped / clicked position
					
					#if UNITY_EDITOR //for unity editor
					ray = Camera.main.ScreenPointToRay(Input.mousePosition); //sends a ray out from the main camera towards the game view

					//for touch device
					#elif (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8) //as above but for touch screen
					ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
					#endif

					
			if (Physics.Raycast (ray, out hit)) //sends a ray out from ray
			
						{
				if(hit.collider.tag == "Floor")

								{
									//set a flag to indicate to move the gameobject
									flag = true;
									//save the click / tap position
									endPoint = hit.point;
									//as we do not want to change the y axis value based on touch position, reset it to original y axis value
									endPoint.y = yAxis;
									
								}
						}

						

				}

			//check if the flag for movement is true and the current gameobject position is not same as the clicked / tapped position
			if(flag && !Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude))
		
				{ //&& !(V3Equal(transform.position, endPoint))){
			
					//move the gameobject to the desired position
					gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, endPoint, 1/(duration*(Vector3.Distance(gameObject.transform.position, endPoint))) );
					//sets the position           as lerp between       start position       and target   sets smooth transition
		
					gameObject.transform.position = new Vector3 (
					Mathf.Clamp (gameObject.transform.position.x, boundary.xMin, boundary.xMax), //this clamps the position between the float set boundaries
					0.0f,
					Mathf.Clamp (gameObject.transform.position.z, boundary.zMin, boundary.zMax));
				}

			//set the movement indicator flag to false if the endPoint and current gameobject position are equal
			else if(flag && Mathf.Approximately(gameObject.transform.position.magnitude, endPoint.magnitude)) 
		
				{
					flag = false;

			//Also add a line to reduce the value for warp power by 10

				}
			//Here code is needed for when player is within the collider for the recharger then it increases warp power at a rate of 10 per second

		}
}








