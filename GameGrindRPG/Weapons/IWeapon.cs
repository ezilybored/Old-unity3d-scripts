using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This will be an interface not a class
public interface IWeapon

{
	//uses the public list BaseStat from CharacterStat script as it is already defined 
	//and also has the stat bonuses added and can add bonuses from different weapons
	List<BaseStat> stats { get; set; }

	void PerformAttack ();
	//to add special attacks
	//void PerformSpecialAttack ();


}
