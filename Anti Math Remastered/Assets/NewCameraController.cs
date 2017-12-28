using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraController : MonoBehaviour {
    private void OnEnable()
    {
        NewGameManager.EndGame += TriggerEnd;
    }

    private void OnDisable()
    {
        NewGameManager.EndGame -= TriggerEnd;
    }

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void TriggerEnd()
    {
        anim.SetTrigger("Done");
    }
}
