using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuCanvas : MonoBehaviour {

    //canvas pieces
    [SerializeField]
    GameObject[] CanvasPieces;

    private void OnEnable()
    {
        NewGameManager.Paused += MakeAppear;
        NewGameManager.UnPaused += MakeDissappear;
    }
    private void OnDisable()
    {
        NewGameManager.Paused -= MakeAppear;
        NewGameManager.UnPaused -= MakeDissappear;
    }

    public void MakeAppear()
    {
        StartCoroutine(MakeThemAppear());
    }

   public void MakeDissappear()
    {
        StartCoroutine(MakeThemDissapear());
    }
    IEnumerator MakeThemAppear()
    {
      
        yield return new WaitForSecondsRealtime(0.2f);
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

    IEnumerator MakeThemDissapear()
    {

        for (int i = 0; i < CanvasPieces.Length; i++)
        {
            if (CanvasPieces[i].GetComponent<QuestionItemScript>() != null)
            {
                CanvasPieces[i].GetComponent<QuestionItemScript>().Dissappear();
            }
            else
            {
                CanvasPieces[i].GetComponent<TempFlagTrigger>().Dissappear();
            }

            yield return new WaitForSeconds(0.01f);
        }
    }


}
