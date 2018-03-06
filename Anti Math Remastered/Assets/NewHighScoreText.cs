using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewHighScoreText : MonoBehaviour {

    private void OnEnable()
    {
        NewGameManager.NewHighScore += NotifyScore;
    }
    private void OnDisable()
    {
        NewGameManager.NewHighScore -= NotifyScore;
    }

    void NotifyScore()
    {
        StartCoroutine(scorrr());
    }

    IEnumerator scorrr()
    {
        yield return new WaitForSeconds(3);
        GetComponent<AudioSource>().Play();
        GetComponent<Text>().text = "New high score!";
    }
}
