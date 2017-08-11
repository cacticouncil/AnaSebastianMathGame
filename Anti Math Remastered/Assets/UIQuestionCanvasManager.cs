using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIQuestionCanvasManager : MonoBehaviour {

    static public UIQuestionCanvasManager instance;
    private void Awake()
    {
        //Do I exist?
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        SetCanvasState(false);
       
    }

    public void SetCanvasState(bool set)
    {
        GetComponent<Canvas>().enabled = set;
        GameManager.instance.GetComponent<QuestionManagerController>().GenerateQuestion(0);
    }
}
