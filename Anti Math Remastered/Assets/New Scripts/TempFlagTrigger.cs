using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TempFlagTrigger : MonoBehaviour {

    [SerializeField]
    GameObject[] ItemTocount;

    [SerializeField]
    int ID;

    [SerializeField]
    bool NumberNotFlag = false;

    IEnumerator ShowThemUP()
    {
        int length;

        if (ID == 1)
         length = NewQuestionManager.instance.GetA();
          
        else if (ID == 2)
         length = NewQuestionManager.instance.GetB();

        
        else
         length = NewQuestionManager.instance.GetC();
        

        if (NumberNotFlag)
        {
         GetComponentInChildren<Text>().text = length.ToString();
            length = 1;
        }
        
        for (int i = 0; i < length; i++)
        {
            if (ItemTocount[i].transform.localScale.x < 0.9f)
            {
                if(NumberNotFlag)
                    ItemTocount[i].GetComponent<QuestionItemScript>().Appear();
                else
                ItemTocount[i].GetComponent<CountingItem>().Appear();
                yield return new WaitForSeconds(0.2f);
            }
        }
    }

    IEnumerator HideThemAll()
    {
        for (int i = 0; i < ItemTocount.Length; i++)
        {
            if (ItemTocount[i].transform.localScale.x > 0.1f)
            {
                if (NumberNotFlag)
                    ItemTocount[i].GetComponent<QuestionItemScript>().Dissappear();
                else
                ItemTocount[i].GetComponent<CountingItem>().Dissappear();
            yield return new WaitForSeconds(0.2f);

            }
        }
    }

    void HideStuf()
    {
        for (int i = 0; i < ItemTocount.Length; i++)
        {
            if (ItemTocount[i].transform.localScale.x > 0.1f)
            {
                if (NumberNotFlag)
                    ItemTocount[i].GetComponent<QuestionItemScript>().Dissappear();
                else
                    ItemTocount[i].GetComponent<CountingItem>().Dissappear();

            }
        }
    }
    public void Appear()
    {
        StartCoroutine(ShowThemUP());
    }

    public void Dissappear()
    {
        StartCoroutine(HideThemAll());
        //HideStuf();
    }
  //  private void Update()
  //  {
  //      if (Input.GetKeyDown(KeyCode.L))
  //      {
  //      StartCoroutine(ShowThemUP());
  //
  //      }
  //
  //      if (Input.GetKeyDown(KeyCode.K))
  //      {
  //          StartCoroutine(HideThemAll());
  //      }
  //  }

}
