using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : MonoBehaviour {

	//assigns the type of stats the character has
	public List<BaseStat> stats = new List<BaseStat> ();

	//on start, adds the stats
	void Start()
	{
		//adds a stat of 4, called Power, with a description 
		stats.Add(new BaseStat(4, "Power", "Your power level"));
		//adds a stat of 2, called Vitality, with a description 
		stats.Add(new BaseStat(2, "Vitality", "Your vitality level"));


		//creates any bonuses to add
		//Examples: this one adds 21 to the power level
		//stats[0].AddStatBonus(new StatBonus(21));
		//this one adds a second power bonus removing 8
		//stats[0].AddStatBonus(new StatBonus(-8));

		//prints the overall power level to the console
		//Debug.Log(stats[0].GetCalculatedStatValue());
		//Debug.Log(stats[1].GetCalculatedStatValue());
	}

	//adds any StatBonus from equpping a weapon
	//passes in a list of BaseStats called statBonus
	public void AddStatBonus(List<BaseStat> statBonuses)
	{
		//looks through statBonuses for all of the StatBonus types called statBonus
		foreach (BaseStat statBonus in statBonuses) 
		{
			//find the stat to add that matches the stat bonus from the weapon or item
			stats.Find(x=> x.statName == statBonus.statName).AddStatBonus(new StatBonus(statBonus.baseValue));
		}
	}

	//Removes any StatBonus from de-equpping a weapon
	//passes in a list of BaseStats called statBonus
	public void RemoveStatBonus(List<BaseStat> statBonuses)
	{
		//looks through statBonuses for all of the StatBonus types called statBonus
		foreach (BaseStat statBonus in statBonuses) 
		{
			//find the stat to add that matches the stat bonus from the weapon or item
			stats.Find(x=> x.statName == statBonus.statName).RemoveStatBonus(new StatBonus(statBonus.baseValue));
		}
	}
}
