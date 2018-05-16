using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//allows the use of the JSON file
using Newtonsoft.Json;

public class ItemDatabase : MonoBehaviour {

	public static ItemDatabase Instance { get; set; }
	private List<Item> Items { get; set; }

	void Start()
	{
		//Sets up this Instance as a singleton
		if (Instance != null && Instance != this)
			Destroy (gameObject);
		else
			Instance = this;

		BuildDatabase ();
	}

	private void BuildDatabase()
	{
		//Converts the Json database to a list of string format
		//This is then passed through the Deserialisation object and makes a list of items
		Items = JsonConvert.DeserializeObject<List<Item>>(Resources.Load<TextAsset>("JSON/items").ToString());
		Debug.Log(Items[0].stats[1].statName + " level is " + Items[0].stats[1].GetCalculatedStatValue());
		Debug.Log (Items [0].ItemName);
	}

	public Item GetItem(string itemSlug)
	{
		//searches through the Items (type) in the list Items and returns an Item called item
		foreach(Item item in Items)
			{
				if (item.objectslug == itemSlug)
					return item;
			}
		Debug.LogWarning ("Couldn't find item" + itemSlug);
		return null;
	}

}
