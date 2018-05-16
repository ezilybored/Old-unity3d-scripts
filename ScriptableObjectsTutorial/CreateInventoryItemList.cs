using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateInventoryItemList {
	//In this case this part isn't necessarily needed
	[MenuItem("Assets/Create/Inventory Item List")]
	public static InventoryItemList  Create()
	{
		InventoryItemList asset = ScriptableObject.CreateInstance<InventoryItemList>();

		AssetDatabase.CreateAsset(asset, "Assets/InventoryItemList.asset");
		AssetDatabase.SaveAssets();
		return asset;
	}
}
