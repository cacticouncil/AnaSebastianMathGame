using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BucketCanvasController : MonoBehaviour {

    public GameObject QuestionManager;

    public GameObject LowBucket1;
    Vector3 LowBucket1Pos;
    public GameObject LowBucket2;
    Vector3 LowBucket2Pos;
    public Image sign;
    Vector3 SignPos;
    public Button Answer1;
    Vector3 Answer1Pos;
    public Button Answer2;
    Vector3 Answer2Pos;
    public Button Answer3;
    Vector3 Answer3Pos;
    bool move;

    bool swapOrder = true;

    Vector3[] Positions = new Vector3[3];
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
        if (InfoManager.instance.ID == 3)
        {
            Answer1.GetComponent<Image>().sprite = GameManager.instance.Symbols[QuestionManager.GetComponent<QuestionManagerController>().SymbolType];
            Answer2.GetComponent<Image>().sprite = GameManager.instance.Symbols[QuestionManager.GetComponent<QuestionManagerController>().SymbolType];
            Answer3.GetComponent<Image>().sprite = GameManager.instance.Symbols[QuestionManager.GetComponent<QuestionManagerController>().SymbolType];
        }
        
        LowBucket2Pos = LowBucket2.transform.position;
        SignPos = sign.transform.position;
        Answer1Pos = Answer1.transform.position;
        Positions[0] = Answer1Pos;
        Answer2Pos = Answer2.transform.position;
        Positions[1] = Answer2Pos;
        Answer3Pos = Answer3.transform.position;
        Positions[2] = Answer3Pos;

        for (int i = 0; i < 5; i++)
        {
            SwapArrayElement(Positions,Random.Range(0,3), Random.Range(0, 3));
        }
    }
    void MoveToCenter()
    {
        if (swapOrder)
        {
            for (int i = 0; i < 5; i++)
            {
                SwapArrayElement(Positions, Random.Range(0, 3), Random.Range(0, 3));
                swapOrder = false;
            }
        }
        LowBucket1.transform.position = Vector3.Lerp(LowBucket1Pos, new Vector3(100,540,0), ratio);
        LowBucket2.transform.position = Vector3.Lerp(LowBucket2Pos, new Vector3(1000, 540, 0), ratio);
        sign.transform.position = Vector3.Lerp(SignPos, new Vector3(950,500,0), ratio);
        Answer1.transform.position = Vector3.Lerp(Positions[0], new Vector3(Positions[0].x, 120, 0), ratio);
      //  Answer1.GetComponentInChildren<Text>().text = (GameManager.instance.answer).ToString();
        Answer2.transform.position = Vector3.Lerp(Positions[1], new Vector3(Positions[1].x, 120, 0), ratio);
      //  Answer2.GetComponentInChildren<Text>().text = (GameManager.instance.answer+1).ToString();
        Answer3.transform.position = Vector3.Lerp(Positions[2], new Vector3(Positions[2].x, 120, 0), ratio);
      //  Answer3.GetComponentInChildren<Text>().text = (GameManager.instance.answer -1).ToString();
        
    }

    void SwapArrayElement(Vector3[] vec, int indexa, int indexb)
    {
        Vector3 temp = vec[indexa];
        vec[indexa] = vec[indexb];
        vec[indexb] = temp;
        int tempA = Random.Range(1, 10);
        int tempB = Random.Range(1, 5);
        if (tempA == tempB)
            tempA++;

        if (InfoManager.instance.ID == 3)
        {
                    Answer1.GetComponent<Image>().sprite = GameManager.instance.Symbols[QuestionManager.GetComponent<QuestionManagerController>().SymbolType];
            switch (QuestionManager.GetComponent<QuestionManagerController>().SymbolType)
            {
                case 2:
                    Answer2.GetComponent<Image>().sprite = GameManager.instance.Symbols[3];
                    Answer3.GetComponent<Image>().sprite = GameManager.instance.Symbols[4];
                    break;
                case 3:
                    Answer2.GetComponent<Image>().sprite = GameManager.instance.Symbols[2];
                    Answer3.GetComponent<Image>().sprite = GameManager.instance.Symbols[4];
                    break;
                case 4:
                    Answer2.GetComponent<Image>().sprite = GameManager.instance.Symbols[2];
                    Answer3.GetComponent<Image>().sprite = GameManager.instance.Symbols[3];
                    break;
            }
            
        }
        else
        {
        Answer1.GetComponentInChildren<Text>().text = (GameManager.instance.answer).ToString();
        Answer2.GetComponentInChildren<Text>().text = (GameManager.instance.answer +tempA ).ToString();
        Answer3.GetComponentInChildren<Text>().text = (GameManager.instance.answer + tempB).ToString();
        }


    }

    public void PleaseMove()
    {
        move = true;
        swapOrder = true;
    }
   public void PleaseDontMove()
    {
        move = false;
    }
    private void Update()
    {
        if (InfoManager.instance.ID == 3)
            sign.sprite = GameManager.instance.Symbols[5];
        else
            sign.sprite = GameManager.instance.Symbols[QuestionManager.GetComponent<QuestionManagerController>().SymbolType];


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
