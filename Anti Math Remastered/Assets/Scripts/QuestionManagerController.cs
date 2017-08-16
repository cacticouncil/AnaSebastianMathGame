
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

   
    //More readability
    enum Difficulty
    {
        easy = 0, normal, hard
    }
    //This is for addition
    int[] Easy = new int[25];
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
                if (i % 2 == 0)
                {
                    Easy[index] = i;
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

    public void GenerateQuestion()
    {
        int difficulty = 0;
        int a = 0;
        int b = 0;
        switch (difficulty)
        {
            case (int)Difficulty.easy:
                 a = Easy[(int)Random.Range(0, 24)];
                 b = Easy[(int)Random.Range(0, 24)];
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
        QuestionText.GetComponent<Text>().text = a.ToString() + "\n + " + b.ToString() + ": ?";
        answer = a + b;
    }

    

    public void CompareResults(int userSub)
    {
        if (userSub == answer)
            GameManager.instance.CorrectAnswer();
        else
            GenerateQuestion();



    }
    
}
