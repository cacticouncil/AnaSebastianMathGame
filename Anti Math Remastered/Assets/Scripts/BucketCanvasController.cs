using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BucketCanvasController : MonoBehaviour {

    public GameObject LowBucket1;
    Vector3 LowBucket1Pos;
    public GameObject LowBucket2;
    Vector3 LowBucket2Pos;

    public Button Answer1;
    public Button Answer2;
    public Button Answer3;
    bool move;
    

    float ratio;

    private void OnEnable()
    {
        GameManager.SetBasket += PleaseMove;
        GameManager.QuestionTime += PleaseDontMove;
    }

    private void OnDisable()
    {
        GameManager.SetBasket -= PleaseMove;
        GameManager.QuestionTime -= PleaseDontMove;
    }

    private void Start()
    {
        LowBucket1Pos = LowBucket1.transform.position;
        LowBucket2Pos = LowBucket2.transform.position;
    }
    void MoveToCenter()
    {
        LowBucket1.transform.position = Vector3.Lerp(LowBucket1Pos, new Vector3(100,540,0), ratio);
        LowBucket2.transform.position = Vector3.Lerp(LowBucket2Pos, new Vector3(1000, 540, 0), ratio);
        Answer1.GetComponentInChildren<Text>().text = (GameManager.instance.answer).ToString();
    }
    
    public void PleaseMove()
    {
        move = true;
    }
   public void PleaseDontMove()
    {
        move = false;
    }
    private void Update()
    {
        if (move)
        {
            MoveToCenter();
            ratio += Time.deltaTime*3;
            if (ratio >= 1)
                ratio = 1;
        }
        else
        {
            MoveToCenter();
            ratio -= Time.deltaTime * 3;
            if (ratio <= 0)
                ratio = 0;
        }
    }

}
