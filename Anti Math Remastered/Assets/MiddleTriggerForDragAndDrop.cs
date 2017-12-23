using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleTriggerForDragAndDrop : MonoBehaviour {
    Vector3 thicc;
    Vector3 nothicc;
	// Use this for initialization
	void Start () {
        nothicc = Vector3.one;
        thicc = Vector3.one * 1.5f;
	}

  

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.localScale = thicc;
    }
  

    private void OnCollisionExit2D(Collision2D collision)
    {
        transform.localScale = nothicc;
    }
}
