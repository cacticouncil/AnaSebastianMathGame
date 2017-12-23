using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour {

    int[] IDS = new int[3];

    [SerializeField]
    AnswerButton[] buttons;

    private void OnEnable()
    {
        NewGameManager.QuestionTime += SwapButtonID;
    }
    private void OnDisable()
    {
       NewGameManager.QuestionTime -= SwapButtonID;
    }

    private void Awake()
    {
        for (int i = 0; i < IDS.Length; i++)
        {
            IDS[i] = i;
            buttons[i].SetID(i);
        }
    }

   void  SwapButtonID()
    {
        for (int i = 0; i < 5; i++)
        {
        SwapElement(IDS, Random.Range(0, 2), Random.Range(0, 2));
        }

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetID(IDS[i]);
        }
    }

    void SwapElement(int[] vec, int indexa, int indexb)
    {
        int temp = vec[indexa];
        vec[indexa] = vec[indexb];
        vec[indexb] = temp;
    }
}
