using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
public class InfoManager : MonoBehaviour {

    //Singleton instence for the class
    public static InfoManager instance;

    //What is the size of the radius, or, how far away from the origin will the player spawn?
    
    public  uint planetRadius;

    //How many animals in the level?
    
    public  uint AnimalAmount;

    public bool timeAttack;

    public uint ID;

    public volatile bool Sound;
     int SoundInt;

    public volatile bool Basquet;
     int BasquetInt;

    public volatile bool Gyroscope;
    int GyroscopeInt;

    public int[] HighScores = new int[5];

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

        SoundInt = PlayerPrefs.GetInt("SoundInt", 1);
        Sound = (SoundInt == 1) ? true : false;

        BasquetInt = PlayerPrefs.GetInt("BasquetInt", 1);
        Basquet = (BasquetInt == 1) ? true : false;

        GyroscopeInt = PlayerPrefs.GetInt("GyroscopeInt", 1);
        Gyroscope = (GyroscopeInt == 1) ? true : false;

        for (int i = 0; i < 5; i++)
        {
            HighScores[i] = PlayerPrefs.GetInt("High Score " + i.ToString(), 0);
        }
        QualitySettings.vSyncCount = 2;
    }

   public void Save()
    {

        SoundInt = (Sound == true) ? 1 : 0;
        PlayerPrefs.SetInt("SoundInt", SoundInt);

        BasquetInt = (Basquet == true) ? 1 : 0;
        PlayerPrefs.SetInt("BasquetInt", BasquetInt);

        GyroscopeInt = (Gyroscope == true) ? 1 : 0;
        PlayerPrefs.SetInt("GyroscopeInt", GyroscopeInt);

        for (int i = 0; i < 5; i++)
        {
             PlayerPrefs.SetInt("High Score " + i.ToString(), HighScores[i]);
        }

    }

    public void LoadLoadScene()
    {
        SceneManager.LoadScene("Loading");
    }

}


