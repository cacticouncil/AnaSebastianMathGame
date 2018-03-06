using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour {

    int[] IDS = new int[3];

    [SerializeField]
    AnswerButton[] buttons;

    private void OnEnable()
    {
        if (NewInfoManager.instance != null)
        {


            if (NewInfoManager.instance.GetID() == 8)
            {
                NewGameManager.QuestionTime += imdesperate;

            }
            else
            {

                NewGameManager.QuestionTime += SwapButtonID;
            }
        }
    }
    private void OnDisable()
    {
        if (NewInfoManager.instance != null)
        {

            if (NewInfoManager.instance.GetID() == 8)
            {
                NewGameManager.QuestionTime -= imdesperate;

            }
            else
            {
                NewGameManager.QuestionTime -= SwapButtonID;

            }
        }
    }

    private void Awake()
    {
        for (int i = 0; i < IDS.Length; i++)
        {
            IDS[i] = i;
            buttons[i].SetID(i);
        }
    }

    void imdesperate()
    {
        StartCoroutine(WaitForaBitAndThenGo());
        
    }
    IEnumerator WaitForaBitAndThenGo()
    {
        yield return new WaitForSeconds(0.3f);
        SwapButtonID();
    
    }
   void  SwapButtonID()
    {
        
        for (int i = 0; i < 5; i++)
        {
            SwapElement(IDS, Random.Range(0, 2), Random.Range(0, 2));
        }
        int yomama = (int)NewInfoManager.instance.GetID();
        if (NewInfoManager.instance.GetID() != 3 && NewInfoManager.instance.GetID() != 8)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].SetID(IDS[i]);
            }
        }
        else
        {
            if (NewQuestionManager.instance.GetAnswer() == 1)
            {
                buttons[0].SetID(1);
                buttons[1].SetID(0);
                buttons[2].SetID(0);
            }
            if (NewQuestionManager.instance.GetAnswer() == 2)
            {
                buttons[0].SetID(0);
                buttons[1].SetID(1);
                buttons[2].SetID(0);
            }
            if (NewQuestionManager.instance.GetAnswer() == 3)
            {
                buttons[0].SetID(0);
                buttons[1].SetID(0);
                buttons[2].SetID(1);
            }
        }
    }

    void SwapElement(int[] vec, int indexa, int indexb)
    {
        int temp = vec[indexa];
        vec[indexa] = vec[indexb];
        vec[indexb] = temp;
    }
}
