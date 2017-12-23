using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour {


    Text ButtonText;

    [SerializeField]
    int ID;

    public void SetID(int newID)
    {
        ID = newID;
    }
    public int GetID()
    {
        return ID;
    }
    private void OnEnable()
    {
        NewGameManager.QuestionTime += setNewValue;
    }
    private void OnDisable()
    {
        NewGameManager.QuestionTime -= setNewValue;
    }

    private void Start()
    {
        ButtonText = GetComponentInChildren<Text>();
    }

    void setNewValue()
    {
        StartCoroutine(setNewValueCor());
    }

    IEnumerator setNewValueCor()
    {
        yield return new WaitForSeconds(0.2f);
        if (ButtonText == null)
            yield break;

        if (ID == 1)
            ButtonText.text = NewQuestionManager.instance.GetAnswer().ToString();

        else if(ID == 0)
         ButtonText.text = (NewQuestionManager.instance.GetAnswer() + 1).ToString();
        
        else
          ButtonText.text = (NewQuestionManager.instance.GetAnswer() - 1).ToString();
        
       

    }

    public void CheckForAnswer()
    {
        if (ID == 1)
            NewGameManager.instance.CorrectAnswer();
    }
}
