using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obvlivion : MonoBehaviour {

	public void SenToOblivion()
    {
        GetComponent<RectTransform>().localPosition = new Vector3(int.MaxValue, int.MaxValue);
    }

    public void BringMeBack()
    {
        GetComponent<RectTransform>().localPosition = Vector3.zero;
    }

    public void LoadHighScores()
    {
        for (int i = 0; i < 10; i++)
        {
            NewInfoManager.instance.HighScores[i] = PlayerPrefs.GetInt("High Score " + i.ToString());
        }
    }

    public void ResetHighScores()
    {
        for (int i = 0; i < 10; i++)
        {
            PlayerPrefs.SetInt("High Score " + i.ToString(), 0);
        }

        LoadHighScores();
    }
}
