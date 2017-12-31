using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OperandNumber : MonoBehaviour {

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
            GetComponentInChildren<Text>().text = length.ToString();

        for (int i = 0; i < length; i++)
        {
            if (ItemTocount[i].transform.localScale.x < 0.9f)
            {
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
                ItemTocount[i].GetComponent<CountingItem>().Dissappear();
                yield return new WaitForSeconds(0.2f);

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
    }
}
