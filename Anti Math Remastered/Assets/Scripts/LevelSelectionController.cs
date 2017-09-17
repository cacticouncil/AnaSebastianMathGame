using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class LevelSelectionController : MonoBehaviour {

    [SerializeField]
    List<GameObject> Levels;
    public Text LevelTexts;
    public Text Topic;
    public GameObject Cam;
    public Button SelectCountryButton;
    public Button ZoomOutButton;
    public Button StartGameButton;
    public Button BackToMainMenu;
    GameObject current;
    GameObject previous;
	// Use this for initialization
	void Start () {
        if (Levels.Count != 0)
        {
            
            previous = current = Levels[(int)InfoManager.instance.ID];
        }

        ZoomOutButton.transform.localScale = Vector3.zero;
        StartGameButton.transform.localScale = Vector3.zero;
        previousID = (int)InfoManager.instance.ID;
        LevelTexts.text = Levels[(int)InfoManager.instance.ID].ToString();
        Topic.text = Levels[(int)InfoManager.instance.ID].GetComponent<CityInfoController>().GetTopic();
    }


    private RaycastHit hit;
    int previousID;
    float ratio = 0;
    bool change = true;
    
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        //if I hit a country and ONLY a country
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0) 
            && !Cam.GetComponent<CamScript>().Move && !Cam.GetComponent<CamScript>().zoom && hit.collider.tag != "CurrentLevelButton")
        {
            InfoManager.instance.ID = (uint)hit.transform.gameObject.GetComponentInChildren<CityInfoController>().getCityID() - 1;
            current = Levels[(int)InfoManager.instance.ID];
            previous = Levels[previousID];
            previousID = (int)InfoManager.instance.ID;


            Cam.GetComponent<CamScript>().Move = true;
            Cam.GetComponent<CamScript>().t = 0f;
            Debug.Log(InfoManager.instance.ID);
            
        }
      // if (current == previous)
      //     return;
        if (!Cam.GetComponent<CamScript>().Move)
        {
            if (change)
            {
                ratio = 0;
                change = false;
            }
            if (!Cam.GetComponent<CamScript>().zoom)
            {
                ratio += Time.deltaTime * 2;
                LevelTexts.text = Levels[(int)InfoManager.instance.ID].ToString();
                Topic.text = Levels[(int)InfoManager.instance.ID].GetComponent<CityInfoController>().GetTopic();
                SelectCountryButton.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, ratio);

                if (ratio >= 2)
                {

                    ZoomOutButton.transform.localScale = Vector3.zero;
                StartGameButton.transform.localScale = Vector3.zero;
                    BackToMainMenu.transform.localScale = Vector3.one;
                }
                
                
            }
            else
            {
                SelectCountryButton.transform.localScale = Vector3.zero;
                BackToMainMenu.transform.localScale = Vector3.zero;
                ZoomOutButton.transform.localScale = Vector3.one;
                StartGameButton.transform.localScale = Vector3.one;
               
            }
            

        }
        else if (Cam.GetComponent<CamScript>().Move)
        {
            if (!change)
            {
                ratio = 0;
                change = true;
                
            }
            ratio += Time.deltaTime*4;
            LevelTexts.text = "Traveling..";
            Topic.text = "";
            SelectCountryButton.transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, ratio);

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
