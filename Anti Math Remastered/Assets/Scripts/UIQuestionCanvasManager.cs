using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIQuestionCanvasManager : MonoBehaviour {

    static public UIQuestionCanvasManager instance;

    bool setCanvas = true;
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

        SetQuestionCanvasState();
       
    }
    private void OnEnable()
    {
        GameManager.QuestionTime += SetQuestionCanvasState;
    }

    private void OnDisable()
    {
        GameManager.QuestionTime -= SetQuestionCanvasState;
    }
    public void SetQuestionCanvasState()
    {
        setCanvas = !setCanvas;
        GetComponent<Canvas>().enabled = setCanvas;
    }
}
