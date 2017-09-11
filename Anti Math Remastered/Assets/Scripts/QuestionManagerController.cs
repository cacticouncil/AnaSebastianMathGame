
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;

public class QuestionManagerController : MonoBehaviour {

    [SerializeField]
    GameObject QuestionText;
    [SerializeField]
    GameObject kid;
    [SerializeField]
    int hardness;

    int b = 0;
    int a = 0;

    //More readability
    enum Difficulty
    {
        easy = 0, normal, hard
    }
    enum Equation
    {
        Addition = 0, Subtraction
    }
    //This is for addition
    int[] Easy = new int[20];
    int[] Normal = new int[50];
    int[] Hard = new int[100];

    //The answer to the generated question
    int answer = 0;
    
    void Start()
    {
        //Fill in the 3 Arrays
        int index = 0;
        for (int i = 0; i < 100; i++)
        {
            if (i < 50)
            {
                if (i % 2 == 0 && index < 10)
                {
                    Easy[index] = index+1;
                    index++;
                }

                Normal[i] = i;
            }

            Hard[i] = i;
           
        }

        GenerateQuestion();
    }

    private void OnEnable()
    {
        GameManager.QuestionTime += GenerateQuestion;
    }

    private void OnDisable()
    {
        GameManager.QuestionTime -= GenerateQuestion;
    }
    int type = 0;
    public void GenerateQuestion()
    {
        int difficulty = 0;
        int Equationtype = (int)InfoManager.instance.ID;

        switch (difficulty)
        {
            case (int)Difficulty.easy:
                 a = Easy[(int)Random.Range(0, 10)];
                 b = Easy[(int)Random.Range(0, 10)];
                break;
            case (int)Difficulty.normal:
                a = Normal[(int)Random.Range(0, 49)];
                b = Normal[(int)Random.Range(0, 49)];
                break;
            case (int)Difficulty.hard:
                a = Hard[(int)Random.Range(0, 99)];
                b = Hard[(int)Random.Range(0, 99)];
                break;
        }

      
        switch (Equationtype)
        {
            case (int)Equation.Addition:
                if (a >= b)
                    QuestionText.GetComponent<Text>().text = a.ToString() + "\n+" + b.ToString() + "\n----";
                else
                    QuestionText.GetComponent<Text>().text = b.ToString() + "\n+" + a.ToString() + "\n----";
                answer = a + b;
                break;
            case (int)Equation.Subtraction:
                if (a >= b || a == b)
                {
                    QuestionText.GetComponent<Text>().text = (a+1).ToString() + "\n-" + b.ToString() + "\n----";
                    a++;
                    answer = a - b;
                }
                else
                {
                    int temp = a;
                    a = b;
                    b = temp;

                    QuestionText.GetComponent<Text>().text = a.ToString() + "\n-" + b.ToString() + "\n----";
                    answer = a - b;
                }
                break;
            case 2:
                type+= Random.Range(0,4);
                if (type % 2 == 0)
                {
                    if (a >= b)
                        QuestionText.GetComponent<Text>().text = a.ToString() + "\n+" + b.ToString() + "\n----";
                    else
                    {
                        int temp = a;
                        a = b;
                        b = temp;
                        QuestionText.GetComponent<Text>().text = a.ToString() + "\n+" + b.ToString() + "\n----";
                    }
                    answer = a + b;
                }
                else
                {
                    if (a >= b || a == b)
                    {
                        QuestionText.GetComponent<Text>().text = (a + 1).ToString() + "\n-" + b.ToString() + "\n----";
                        a++;
                        answer =a - b;
                    }
                    else
                    {
                        int temp = a;
                        a = b;
                        b = temp;
                        QuestionText.GetComponent<Text>().text = a.ToString() + "\n-" + b.ToString() + "\n----";
                        answer = a - b;
                    }
                }
                break;
        }
        GameManager.instance.a = a;
        GameManager.instance.b = b;
        GameManager.instance.answer = answer;
        
    }

    

    public void CompareResults(int userSub)
    {
        if (userSub == answer)
            GameManager.instance.CorrectAnswer();
        else
            GameManager.instance.WrongAnswer();// GenerateQuestion();



    }
    
}
