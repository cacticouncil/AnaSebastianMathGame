using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour {

    public LevelSelectionController Levels;
    public bool Move;
   public float t = 0;
    Vector3 look;

    private void Start()
    {
        look = Levels.GetLevel(0).transform.position;
        transform.LookAt(look);
    }


    private void LateUpdate()
    {
        if (Move)
        {
            look = Vector3.Lerp(Levels.GivePreviousLevel().transform.position, Levels.CurrentLevel().transform.position, t);
            t += Time.deltaTime;
            if (t > 1)
                Move = false;
            transform.LookAt(look);
        }
        else
        {
            t = 0;
        }
      
    }
}
