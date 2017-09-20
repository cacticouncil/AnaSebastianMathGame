using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadJsonStuff : MonoBehaviour {
    TextAsset tasset;
    string JsonTextEnglish;
	// Use this for initialization
	void Start () {

        tasset = Resources.Load<TextAsset>(/*Application.dataPath +*/ "English");
        JsonTextEnglish = tasset.text;
        Debug.Log(JsonTextEnglish);
        //JsonUtility.FromJson(JsonTextEnglish);
	}
	
    public static string LoadJsonFile(string path)
    {
        string filepath = path.Replace(".json", "");
        TextAsset ass = Resources.Load<TextAsset>(filepath);
        return ass.text;
    }

}

