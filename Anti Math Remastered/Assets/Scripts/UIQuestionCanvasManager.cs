using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIQuestionCanvasManager : MonoBehaviour {

    static public UIQuestionCanvasManager instance;

    bool setCanvas = true;

    public RectTransform uitrans;
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

    private void Update()
    {
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
    }
    private void OnEnable()
    {
        GameManager.QuestionTime += SetQuestionCanvasState;
    }

    private void OnDisable()
    {
        GameManager.QuestionTime -= SetQuestionCanvasState;
    }
    float scale = 0;
    public void SetQuestionCanvasState()
    {
        setCanvas = !setCanvas;
        GetComponent<Canvas>().enabled = setCanvas;
       // if (setCanvas)
       // {
       //     scale += Time.deltaTime;
       //     uitrans.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, Mathf.Clamp(scale,0,1));
       //     
       // }
       // else
       // {
       //     uitrans.localScale = Vector3.zero;
       //     scale = 0;
       // }
    }
    
    
    Vector3 lerpvectors( Vector3 end, Vector3 start, float t)
    {
        float x = Mathf.Lerp(start.x, end.x, t);
        float y = Mathf.Lerp(start.y, end.y, t);
        float z = Mathf.Lerp(start.z, end.z, t);
        return new Vector3(x, y, z);
    }
}
