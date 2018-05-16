using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConsumable
{
	//Method for consuming the item
	void Consume();

	//method for consuming and effecting player stats
	void Consume(CharacterStat stats);
}
