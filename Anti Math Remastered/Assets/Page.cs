using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page : MonoBehaviour {

    Animator Daddy;

    private void Start()
    {
        Daddy = GetComponentInParent<Animator>();
    }

    public void TurnPage(bool OpenOrClose)
    {
        Daddy.SetBool("ZoomIntoPage", OpenOrClose);
    }
}
