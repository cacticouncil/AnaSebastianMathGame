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


    private RaycastHit hit;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
        {
            InfoManager.instance.ID = (uint)hit.transform.gameObject.GetComponentInChildren<CityInfoController>().getCityID() - 1;
            current = Levels[(int)InfoManager.instance.ID];
            if (InfoManager.instance.ID == 0)
            {
                previous = Levels[Levels.Count - 1];
            }
            else
                previous = Levels[(int)InfoManager.instance.ID - 1];

            Cam.GetComponent<CamScript>().Move = true;
            Cam.GetComponent<CamScript>().t = 0f;
            Debug.Log(InfoManager.instance.ID);
        }
           
        //    if (hit.transform.tag == "Colombia")
        //  else if (hit.transform.tag == "Ecuador")
        //      Debug.Log("Whomstve");
        //  else if (hit.transform.tag == "Venezuela")
        //      Debug.Log("T H I C C");


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
