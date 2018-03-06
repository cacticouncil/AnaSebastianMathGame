using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddingTimeScript : MonoBehaviour {

    Animator anim;
    private void OnEnable()
    {
        NewGameManager.QuestionCorrect += DispayAnim;
    }
    private void OnDisable()
    {
        NewGameManager.QuestionCorrect -= DispayAnim;
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void DispayAnim()
    {
        anim.SetTrigger("AddTime");
    }
}
