using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionLog : MonoBehaviour, IConsumable 
{
	//Method for consuming the item inherited from IConsumable
	public void Consume()
	{
		Debug.Log("You drank the potion");
		Destroy (gameObject);
	}

	//method for consuming and effecting player stats. Inherited from IConsumable
	public void Consume(CharacterStat stats)
	{
		Debug.Log("You drank the potion. It gave you a buff");
	}

}
