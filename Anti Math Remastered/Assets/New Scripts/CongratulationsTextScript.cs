using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CongratulationsTextScript : MonoBehaviour {

    Animator anim;
    Text t;
    [SerializeField]
    string[] thingstoSay;

    int lengt;
    private void OnEnable()
    {
        NewGameManager.QuestionCorrect += SetAnimation;
    }

    private void OnDisable()
    {
        NewGameManager.QuestionCorrect -= SetAnimation;
    }
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        t = GetComponent<Text>();
        lengt = thingstoSay.Length;
	}
	
	void SetAnimation()
    {
        GetComponentInChildren<Text>().text  = t.text = thingstoSay[Random.Range(0, lengt)];
        
        if (Random.Range(1,4) % 2 == 0)
        anim.SetTrigger("Correct");
       else
            anim.SetTrigger("Correct2");
    }
}
