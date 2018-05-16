using UnityEngine;
using System.Collections;
using UnityEditor;

//This is another way of making scriptable objects (Considered the old way)

public class MakeScriptableObject {
	[MenuItem("Assets/Create/My Scriptable Object")]
	public static void CreateMyAsset()
	{
		//Creates an instance of the scriptable object
		MyScriptableObjectClass asset = ScriptableObject.CreateInstance<MyScriptableObjectClass>();

		//Creates and Asset in the AssetDatabase
		AssetDatabase.CreateAsset(asset, "Assets/NewScripableObject.asset");
		//Saves the Asset Database
		AssetDatabase.SaveAssets();

		//Focuses in on the project window
		EditorUtility.FocusProjectWindow();

		//Focuses on the new asset in the project window
		Selection.activeObject = asset;
	}
}

//This is now redundant
//This is all now done under the hood using the Attribute [CreateAssetMenu()] at the start of the S.O. class
