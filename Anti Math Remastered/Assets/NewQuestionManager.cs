using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewQuestionManager : MonoBehaviour {

    private void OnEnable()
    {
        NewGameManager.QuestionTime += QuestionRequested;
    }

    private void OnDisable()
    {
        NewGameManager.QuestionTime -= QuestionRequested;
    }

    public static NewQuestionManager instance;
    
    int a = 0;
    int b = 0;
    int c = 0;
    int answer = 0;
    //for the comparissons part, an answer of 1 will mean that the ">" should be used.
    // An answer of 2 means that the "<" symbol must be used. 
    // An answer of 3 emans that the "=" symbol must be used.
    public int GetA() { return a; }
    public int GetB() { return b; }
    public int GetC() { return c; }
    public int GetAnswer() { return answer; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void QuestionRequested()
    {
        int ID = (int)NewInfoManager.instance.GetID();
        if (ID == 0 || ID == 5)
            GenerateAddition();
        else if (ID == 1 || ID == 6)
            GenerateSubtraction();
        else if (ID == 2 || ID == 7)
        {
            if (Random.Range(1, 10) % 2 == 0)
                GenerateAddition();
            else
                GenerateSubtraction();
        }
        else if (ID == 3 || ID == 8)
            GenerateBigEquation();
        else
            GenerateComparisson();



    }

    void RollTheDice(bool threeNumbers)
    {
        a = (int)Random.Range(1, 10);
        b = (int)Random.Range(1, 10);
        if (threeNumbers)
            c = (int)Random.Range(1, 10);
    }

    void GenerateAddition() {
        RollTheDice(false);
        answer = a + b;
    }

    void GenerateSubtraction()
    {
        RollTheDice(false);
        if (a >= b)
            answer = a - b;
        else
        {
            //swap variables
            int temp = a;
            a = b;
            b = temp;
            answer = a - b;
        }
        
    }

   void GenerateBigEquation()
    {
        while ((a + b) <= c)
           RollTheDice(true);

        answer = a + b -c;
    }

    void GenerateComparisson()
    {
        RollTheDice(false);

        if (a > b)
            answer = 1;
        else if (a < b)
            answer = 2;
        else
            answer = 3;
    }
}
