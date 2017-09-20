using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InfoManager : MonoBehaviour {

    //Singleton instence for the class
    public static InfoManager instance;

    //What is the size of the radius, or, how far away from the origin will the player spawn?
    
    public  uint planetRadius;

    //How many animals in the level?
    
    public  uint AnimalAmount;

    public uint ID;

    public bool Sound = true;

    public Language English;

    public Dictionary<int,string> GameTexts = new Dictionary<int,string>();
    public List<string> GameTextsList = new List<string>();
    private void Awake()
    {
        //Do I exist?
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
    }

   

}
