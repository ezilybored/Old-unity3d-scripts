using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallThroughHole : MonoBehaviour {

	void OnTriggerStay(Collider other) {
		if (other.CompareTag("Hole"))
			this.GetComponent<Collider> ().enabled = false;

	}
}

	/*public bool collider;

	void Start ()
	{
		collider = true
	}
	

	void OnTriggerEnter (Collider other) 
	{	
		if (other.CompareTag ("Hole"))  
	
			{

				this.GetComponent<Collider> ().enabled = false;

			}
	}

}*/