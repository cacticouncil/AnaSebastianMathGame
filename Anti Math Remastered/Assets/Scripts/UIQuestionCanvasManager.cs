using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIQuestionCanvasManager : MonoBehaviour {

    static public UIQuestionCanvasManager instance;

    bool setCanvas = true;
    public GameObject ButtonManager_;
    public RectTransform uitrans;
    public RectTransform EndGameUi;
    public RectTransform PauseUI;
    float scale = 0;
    float scale2 = 0;
    float scalepause = 0;
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
       // EndGameUi.GetComponentInChildren<Image>().sprite = GameManager.instance.cats[InfoManager.instance.ID];
    }

    private void Update()
    {
        //Question canvas actions
        if (setCanvas)
        {
            scale += Time.deltaTime;
            uitrans.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, Mathf.Clamp(scale, 0, 1));

        }
        else
        {
            uitrans.localScale = Vector3.zero;
            scale = 0;
        }
        //pause actions
        if (GameManager.instance.pauseGame)
        {
            scalepause += Time.unscaledDeltaTime;
           
            GetComponent<Canvas>().enabled = true;
            PauseUI.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, Mathf.Clamp(scalepause, 0, 1));
        }
        else
        {
            PauseUI.localScale = Vector3.zero;
            scalepause = 0;
        }
        //End game actions
       if (AnimalController.AnimalCount == 0)
       {
           scale2 += Time.deltaTime;
            GetComponent<Canvas>().enabled = true;
           EndGameUi.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, Mathf.Clamp(scale2, 0, 1));
       }
        else
        {
          
           EndGameUi.localScale = Vector3.zero;
         
           scale2 = 0;
        }
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
    
    
    Vector3 lerpvectors( Vector3 end, Vector3 start, float t)
    {
        float x = Mathf.Lerp(start.x, end.x, t);
        float y = Mathf.Lerp(start.y, end.y, t);
        float z = Mathf.Lerp(start.z, end.z, t);
        return new Vector3(x, y, z);
    }
}
