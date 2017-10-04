using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsController : MonoBehaviour {
    public Animator Cover;
    bool MoveCover;
    public Animator PG1;
    public bool MovePG1 = false;
    public Animator PG2;
    public bool MovePG2 = false;
    public Animator PG3;
    public bool MovePG3 = false;
    public Animator PG4;
    public bool MovePG4 = false;

    int toggle = -1;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            MoveCover = !MoveCover;
            Cover.SetBool("Turn Page", MoveCover);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            MovePG1 = !MovePG1;
            PG1.SetBool("Turn Page", MovePG1);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            MovePG2 = !MovePG2;
            PG2.SetBool("Turn Page", MovePG2);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            MovePG3 = !MovePG3;
            PG3.SetBool("Turn Page", MovePG3);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            MovePG4 = !MovePG4;
            PG4.SetBool("Turn Page", MovePG4);
        }
    }
}
