using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewInfoManager : MonoBehaviour {

    //Singleton instence for the class
    public static NewInfoManager instance;

    //What is the size of the radius, or, how far away from the origin will the player spawn?
    [SerializeField]
    public uint planetRadius;

    //How many animals in the level?
    [SerializeField]
    public uint AnimalAmount;

    //Are we on time atack?
    [SerializeField]
    public bool timeAttack;

    //What level are we on?
    [SerializeField]
    private uint ID;

    public uint GetID()
    {
        return ID;
    }
    public void SetID(uint _NewID)
    {
        ID = _NewID;
    }


    //Is sound on?
    [SerializeField]
    public volatile bool Sound;
    int SoundInt;

    //Basquet mode?
    [SerializeField]
    public volatile bool Basquet;
    int BasquetInt;

    //Gyroscope on?
    [SerializeField]
    public volatile bool Gyroscope;
    int GyroscopeInt;

    //Saved High scores
    [SerializeField]
    public int[] HighScores = new int[5];

    //Loading Elements
    [SerializeField]
    private ThingiesToLoad[] LevelElements = new ThingiesToLoad[10];

    public ThingiesToLoad GetCurrentThingyToLoad(int _index)
    {
        if (_index >= 0 && _index < LevelElements.Length)
        {
            return LevelElements[_index];
        }

        return null;
    }
    public ThingiesToLoad GetCurrentThingyToLoad()
    {
         return LevelElements[ID];
       
    }

    //to be implemented in the future
    // public Language English;
    // public Dictionary<int, string> GameTexts = new Dictionary<int, string>();
    // public List<string> GameTextsList = new List<string>();

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
        //lock to 30 frames
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


 
    
}

[System.Serializable]
public class ThingiesToLoad
{
    [SerializeField]
    private string PlanetTexture;

    [SerializeField]
    private string kidClothesBoy;

    [SerializeField]
    private string kidClothesGirl;

    [SerializeField]
    private string[] PlantTextures = new string[3];

    [HideInInspector]
    public string PlanetTexture1
    {
        get
        {
            return PlanetTexture;
        }

        set
        {
            PlanetTexture = value;
        }
    }

    [HideInInspector]
    public string KidClothesBoy_
    {
        get
        {
            return kidClothesBoy;
        }

        set
        {
            kidClothesBoy = value;
        }
    }

    [HideInInspector]
    public string KidClothesGirl_
    {
        get
        {
            return kidClothesGirl;
        }

        set
        {
            kidClothesGirl = value;
        }
    }

    [HideInInspector]
    public string GetPlantTexture(int Index)
    {
        if (Index >= 0 && Index < PlantTextures.Length)
        {
            return PlantTextures[Index];
        }
        return null;
    }


}
