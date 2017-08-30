using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectionController : MonoBehaviour {

    [SerializeField]
    List<GameObject> Levels;

    public GameObject Cam;

    GameObject current;
    GameObject previous;
	// Use this for initialization
	void Start () {
        if (Levels.Count != 0)
        {
            
            current = Levels[(int)InfoManager.instance.ID];
        }
	}
	
    public void NextLevel()
    {
        if (InfoManager.instance.ID < Levels.Count-1)
                InfoManager.instance.ID++;
        
        else
            InfoManager.instance.ID = 0;

        current = Levels[(int)InfoManager.instance.ID];

        if (InfoManager.instance.ID == 0)
        {
            previous= Levels[Levels.Count - 1];
        }
        else
        previous= Levels[(int)InfoManager.instance.ID - 1];

        Cam.GetComponent<CamScript>().Move = true;
        Cam.GetComponent<CamScript>().t = 0f;
        Debug.Log(InfoManager.instance.ID);
    }

    public void PreviousLevel()
    {
        if (InfoManager.instance.ID > 0)
            InfoManager.instance.ID--;

        else
            InfoManager.instance.ID = (uint)Levels.Count - 1;

        current = Levels[(int)InfoManager.instance.ID];
        if (InfoManager.instance.ID == Levels.Count - 1)
        {
            previous = Levels[0];
        }
        else
        previous = Levels[(int)InfoManager.instance.ID + 1];
        Cam.GetComponent<CamScript>().Move = true;
        Debug.Log(InfoManager.instance.ID);
    }

    public GameObject CurrentLevel()
    {
        return current;
    }

    public GameObject GivePreviousLevel()
    {
        return previous;
    }
	
    public GameObject GetLevel(int index)
    {
        return Levels[index];
    }
  
}
