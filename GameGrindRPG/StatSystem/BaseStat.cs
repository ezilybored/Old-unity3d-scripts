using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is a base stat that can be adapted to give any stat value for any object in the game
public class BaseStat
{
	//assigns the variables for stat name description and value
	public List<StatBonus> BaseAdditives { get; set; }
	public int baseValue { get; set; }
	public string statName { get; set; }
	public string statDescription { get; set; }
	public int finalValue { get; set; }

	//assigns values for stat name, description and value in the inspector
	/*public BaseStat(int baseValue, string statName, string statDescription)
	{
		this.BaseAdditives = new List<StatBonus> ();
		this.baseValue = baseValue;
		this.statName = statName;
		this.statDescription = statDescription;
	}*/

	//assigns values for stat name, description and value from the Json file
	[Newtonsoft.Json.JsonConstructor]
	public BaseStat(int baseValue, string statName, string statDescription)
	{
		this.BaseAdditives = new List<StatBonus> ();
		this.baseValue = baseValue;
		this.statName = statName;
		this.statDescription = statDescription;
	}

	//provides the ability to add modifiers to any stats
	public void AddStatBonus(StatBonus statBonus)
	{
		this.BaseAdditives.Add(statBonus);
	}

	//removes any modifiers
	public void RemoveStatBonus(StatBonus statBonus)
	{
		this.BaseAdditives.Remove (BaseAdditives.Find(x=> x.BonusValue == statBonus.BonusValue));
	}

	//caluclates the final value of the stat
	public int GetCalculatedStatValue()
	{
		//resets finalValue to 0 on each call
		this.finalValue = 0;
		//adds up all bonuses attached to this stat (there may be more than one)
		this.BaseAdditives.ForEach(x => this.finalValue += x.BonusValue);
		finalValue += baseValue;
		return finalValue;
		//Debug.Log (this.finalValue);
	}
}
