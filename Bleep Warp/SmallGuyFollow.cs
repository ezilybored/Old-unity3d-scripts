using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallGuyFollow : MonoBehaviour {

	private float yAxis;

	public Vector3 playerPosition;

	private Rigidbody rb;

	public Vector3 endPoint;

	public float duration = 50.0f;



	void Start () 

	{

		playerPosition = gameObject.transform.position;

		rb = GetComponent <Rigidbody> ();

		endPoint = GameObject.Find("Hero").transform.position;

		yAxis = gameObject.transform.position.y;

		
	}
	

	void Update () {

		playerPosition = gameObject.transform.position;

		endPoint = GameObject.Find("Hero").transform.position;

		gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, endPoint, 1/(duration*(Vector3.Distance(gameObject.transform.position, endPoint))));
	
	}
}
