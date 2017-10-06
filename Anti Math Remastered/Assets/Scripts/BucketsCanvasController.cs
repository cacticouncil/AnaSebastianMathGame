using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BucketsCanvasController : MonoBehaviour {

    public GameObject QuestionManager;

    public List<GameObject> Buckets = new List<GameObject>();
    List<Vector3> BucketsPos = new List<Vector3>();

    int min = 0;
    int max = 1;

    public List<Button> Buttons = new List<Button>();
    List<Vector3> ButtonsPos = new List<Vector3>();

    // List<Image> Signs = new List<Image>();
    public Image Sign;
    Vector3 SignPos;
    public Image Sign2;
    
    //List<Vector3> SignsPos = new List<Vector3>();
    bool move;

    bool swapOrder = true;

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
        if (InfoManager.instance.Basquet)
            gameObject.SetActive(true);
        
        else
            gameObject.SetActive(false);
        
        SignPos = Sign.transform.position;
        //is it the comparisson levels?
        if (InfoManager.instance.ID == 3 || InfoManager.instance.ID == 8)
        {
            for (int i = 0; i < Buttons.Count; i++)
            {
                Buttons[i].GetComponent<Image>().sprite = GameManager.instance.Symbols[i + 2];

            }           
           
        }

        if (InfoManager.instance.ID == 4 || InfoManager.instance.ID == 9)
        {
            Buckets[0].gameObject.SetActive(false);
            Buckets[1].gameObject.SetActive(false);
            Buckets[2].gameObject.SetActive(true);
            Buckets[3].gameObject.SetActive(true);
            Buckets[4].gameObject.SetActive(true);
            min = 2;
            max = 4;
            Sign.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            Sign2.transform.localScale = new Vector3(0.5f, 0.5f, 1);

        }
        else
        {
            Buckets[0].gameObject.SetActive(true);
            Buckets[1].gameObject.SetActive(true);
            Buckets[2].gameObject.SetActive(false);
            Buckets[3].gameObject.SetActive(false);
            Buckets[4].gameObject.SetActive(false);
        }
            for (int i = 0; i < 3; i++)
        {
            ButtonsPos.Add(Buttons[i].transform.position);
        }

        for (int i = min; i <= max; i++)
        {
            BucketsPos.Add(Buttons[min].transform.position);
        }
       

        for (int i = 0; i < 5; i++)
        {
            SwapArrayElement(ButtonsPos, Random.Range(0, 3), Random.Range(0, 3));
        }
    }
    float ratio = 0;
    private void Update()
    {
        if (InfoManager.instance.ID == 3 || InfoManager.instance.ID == 8)
             Sign.sprite = GameManager.instance.Symbols[5];
        else
            Sign.sprite = GameManager.instance.Symbols[QuestionManager.GetComponent<QuestionManagerController>().SymbolType];


        if (move)
        {
            MoveToCenter();
            ratio += Time.deltaTime * 3;
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

    void MoveToCenter()
    {
        if (swapOrder)
        {
            for (int i = 0; i < 5; i++)
            {
                if (InfoManager.instance.ID == 4 || InfoManager.instance.ID == 9)
                    SwapArrayElement(BucketsPos, Random.Range(0, 3), Random.Range(0, 3));
                else
                    SwapArrayElement(BucketsPos, Random.Range(0, 2), Random.Range(0, 2));

                swapOrder = false;
            }
        }

       // Buckets[0].transform.position = Vector3.Lerp(BucketsPos[0], new Vector3(Screen.width / 22, 540, 0), ratio);
       // Buckets[1].transform.position = Vector3.Lerp(BucketsPos[1], new Vector3(Screen.width / 20 * 10.5f, 540, 0), ratio);
       if (InfoManager.instance.ID == 4 || InfoManager.instance.ID == 9)
        {
            Sign.transform.position = Vector3.Lerp(SignPos, new Vector3(Screen.width / 3, Screen.height/2, 0), ratio);
            Sign2.transform.position = Vector3.Lerp(SignPos, new Vector3(Screen.width / 3*2, Screen.height / 2, 0), ratio);

        }
        else
            Sign.transform.position = Vector3.Lerp(SignPos, new Vector3(Screen.width / 2, Screen.height / 2, 0), ratio);

        for (int i = 0; i < Buttons.Count; i++)
        {
            Buttons[i].transform.position = Vector3.Lerp(ButtonsPos[i], new Vector3(ButtonsPos[i].x, Screen.height/5, 0), ratio);
        }

    }

    void SwapArrayElement(List<Vector3> vec, int indexa, int indexb)
    {
        Vector3 temp = vec[indexa];
        vec[indexa] = vec[indexb];
        vec[indexb] = temp;
        int tempA = Random.Range(1, 10);
        int tempB = Random.Range(1, 5);
        if (tempA == tempB)
            tempA++;

        if (InfoManager.instance.ID == 3 || InfoManager.instance.ID == 8)
        {
            Buttons[0].GetComponent<Image>().sprite = GameManager.instance.Symbols[QuestionManager.GetComponent<QuestionManagerController>().SymbolType];
            switch (QuestionManager.GetComponent<QuestionManagerController>().SymbolType)
            {
                case 2:
                    Buttons[1].GetComponent<Image>().sprite = GameManager.instance.Symbols[3];
                    Buttons[2].GetComponent<Image>().sprite = GameManager.instance.Symbols[4];
                    break;
                case 3:
                    Buttons[1].GetComponent<Image>().sprite = GameManager.instance.Symbols[2];
                    Buttons[2].GetComponent<Image>().sprite = GameManager.instance.Symbols[4];
                    break;
                case 4:
                    Buttons[1].GetComponent<Image>().sprite = GameManager.instance.Symbols[2];
                    Buttons[2].GetComponent<Image>().sprite = GameManager.instance.Symbols[3];
                    break;
            }

        }
        else
        {
            Buttons[0].GetComponentInChildren<Text>().text = (GameManager.instance.answer).ToString();
            Buttons[1].GetComponentInChildren<Text>().text = (GameManager.instance.answer + tempA).ToString();
            Buttons[2].GetComponentInChildren<Text>().text = (GameManager.instance.answer + tempB).ToString();
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

}
