using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndingCanvas : MonoBehaviour {

    //canvas pieces
    [SerializeField]
    GameObject[] CanvasPieces;
   

    private void OnEnable()
    {
        NewGameManager.EndGame += MakeAppear;
    }
    private void OnDisable()
    {
        NewGameManager.EndGame -= MakeAppear;
    }

    public void MakeAppear()
    {
        StartCoroutine(MakeThemAppear());
    }
    IEnumerator MakeThemAppear()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSecondsRealtime(3f);
        for (int i = 0; i < CanvasPieces.Length; i++)
        {
            if (CanvasPieces[i].GetComponent<QuestionItemScript>() != null)
            {
                CanvasPieces[i].GetComponent<QuestionItemScript>().Appear();
            }
            else
            {
                CanvasPieces[i].GetComponent<TempFlagTrigger>().Appear();
            }

            yield return new WaitForSecondsRealtime(0.2f);
        }


    }

   
}
