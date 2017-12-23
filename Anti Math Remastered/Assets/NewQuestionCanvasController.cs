using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewQuestionCanvasController : MonoBehaviour {


    
    //canvas pieces
    [SerializeField]
    GameObject[] CanvasPieces;

    public bool UseMe = true;

  private void OnEnable()
  {
      NewGameManager.QuestionTime += MakeAppear;
      NewGameManager.QuestionCorrect += MakeDissappear;
  }
    private void OnDisable()
    {
        NewGameManager.QuestionTime -= MakeAppear;
        NewGameManager.QuestionCorrect -= MakeDissappear;
    }

   
    void MakeAppear()
    {
        StartCoroutine(MakeThemAppear());
    }

    void MakeDissappear()
    {
        StartCoroutine(MakeThemDissapear());
    }
    IEnumerator MakeThemAppear()
    {

        yield return new WaitForSeconds(0.2f);
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

            yield return new WaitForSeconds(0.2f);
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
