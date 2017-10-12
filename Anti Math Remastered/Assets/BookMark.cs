using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookMark : MonoBehaviour {

    Animator Daddy;

    private void Start()
    {
        Daddy = GetComponentInParent<Animator>();
    }

    public void TurnPage(bool OpenOrClose)
    {
        Daddy.SetBool("Turn Page", OpenOrClose);
    }
}
