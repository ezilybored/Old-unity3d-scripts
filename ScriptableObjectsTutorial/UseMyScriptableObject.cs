using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//This script does need to be added to a GameObject

public class UseMyScriptableObject : MonoBehaviour {
	
	//Public reference to the scriptable object is included here

	public MyScriptableObjectClass myScriptableObject;
	//make a private List of Light
	private List<Light> myLights;

	// Use this for initialization
	void Start () 
	{
		//make a new list
		myLights = new List<Light>();

		//For each spawn in myScriptableObject.spawnPoints
		foreach (Vector3 spawn in myScriptableObject.spawnPoints) 
		{
			//Create a GameObject
			GameObject myLight = new GameObject("Light");
			//Add a component Light
			myLight.AddComponent<Light>();
			//sets the transform position using the data about the spawn that comes from the scriptable object
			myLight.transform.position = spawn;
			//sets the Light to false
			myLight.GetComponent<Light>().enabled = false;
			//Checks the scriptable object to see if the boolean is set to random
			if (myScriptableObject.colorIsRandom) 
			{
				//Chooses a random colour for the light
				myLight.GetComponent<Light>().color = new Color (Random.Range (0.0f, 1.0f), Random.Range (0.0f, 1.0f), Random.Range (0.0f, 1.0f));
			} 
			//otherwise
			else 
			{
				//uses the light colour set in the scriptable object
				myLight.GetComponent<Light>().color = myScriptableObject.thisColor;
			}
			//Adds to the list of Light
			myLights.Add (myLight.GetComponent<Light>());
		}
	}

	//This whole process has essentially created a bunch of gameobjects and a list of them from the data in the S.O.

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) 
		{
			foreach (Light light in myLights) 
			{
				light.enabled = !light.enabled;
			}
		}
		if (Input.GetButtonDown("Fire2"))
		{
			UpdateLights();
		}

	}

	void UpdateLights () 
	{
		foreach (var myLight in myLights)
		{
			myLight.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
		}
	}
}