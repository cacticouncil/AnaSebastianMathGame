using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextAdder : MonoBehaviour {

    string ItemText;
    public int ID;

    private void Awake()
    {
        ItemText = GetComponent<Text>().text;

        InfoManager.instance.GameTexts.Add(ID, ItemText);
    }
}
