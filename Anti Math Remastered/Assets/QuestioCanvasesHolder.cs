using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestioCanvasesHolder : MonoBehaviour {

    [SerializeField]
    GameObject[] Canvases;

    GameObject currentCanvas;
    private void Awake()
    {
        int Survive = (int)NewInfoManager.instance.GetID();

        if (Survive >= 5)
        {
            Survive -= 5;
        }
        currentCanvas = Canvases[Survive];
        int i = 0;
       // if (Survive == 2 || Survive == 7)
       // 
       //     i = 2;
           
        

        while (i < Canvases.Length)
        {
            if (i != Survive)
                Destroy(Canvases[i].gameObject);
            i++;
        }

      
    }

    public void SwitchCanvasStates(bool turnoOnAdditionKillSbutraction)
    {
        currentCanvas.GetComponentInChildren<SwitchSprite>().ChangeSprite(turnoOnAdditionKillSbutraction);
    }
}
