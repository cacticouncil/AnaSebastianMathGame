using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CurrentTimeText : MonoBehaviour {

    Text t;
    [SerializeField]
    bool kidText;

    [SerializeField]
    string StartText;
	// Use this for initialization
	void Start () {
        t = GetComponent<Text>();
      //  StartText = t.text;
	}
	
	// Update is called once per frame
	void Update () {
        if (kidText)
        {

            t.text = StartText + NewGameManager.instance.getTotalChildren().ToString();
        }
        else
        {
            t.text = StartText+ NewGameManager.instance.GetTimerI().ToString();
            if (NewGameManager.instance.GetTimerI() <= 5)
            {
                t.color = Color.red;
            }
            else
            {
               t.color = Color.black;
            }
        }
	}
}
