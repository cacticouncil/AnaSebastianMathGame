using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class IOMenu : MonoBehaviour {

    public Text animalstext;
    public Text planettext;
    public Text LevelText;
    public TextAsset Keyss;
   public LevelSelectionController Levels;

    public Text IOText;
    TextAsset testt = new TextAsset();
    string readPath;
    List<string> Keys = new List<string>();

    string message;
    string loadmessage = "It works";
    string data;
    FileInfo f;

    private void Start()
    {
    #if UNITY_EDITOR
     //  testt = Resources.Load<TextAsset>(Application.dataPath+ "PokemonNames.txt");      
     //   readPath = Application.dataPath + "/PokemonNames.txt";
     //   IOText.text = Keyss.text;
        f = new FileInfo(Application.dataPath + "\\" + "PokemonNames.txt");
       // Save();
        ReadStuff(readPath);
#elif UNITY_ANDROID
        //testt = Resources.Load<TextAsset>("PokemonNames.txt");
        readPath = Application.persistentDataPath + "/PokemonNames.txt";
        f = new FileInfo(Application.persistentDataPath + "\\" + "PokemonNames.txt");
       // Save();

        //IOText.text = testt.text;
       ReadStuff(readPath);
        
#endif
        animalstext.text = "Total Targets: " + InfoManager.instance.AnimalAmount.ToString();
        planettext.text = "Planet Radius: " + InfoManager.instance.planetRadius.ToString();
        // LevelText.text = "Level: " + (InfoManager.instance.ID + 1).ToString();
        LevelText.text = Levels.CurrentLevel().GetComponent<CityInfoController>().getName();
    }

    void ReadStuff(string path)
    {
        //StreamReader reader = new StreamReader(path);
#if UNITY_EDITOR
        StreamReader reader = File.OpenText(Application.dataPath + "\\" + "PokemonNames.txt");
#elif UNITY_ANDROID
        StreamReader reader = File.OpenText(Application.persistentDataPath + "\\" + "PokemonNames.txt");

#endif
        while (!reader.EndOfStream)
        {
            IOText.text += (reader.ReadLine() + '\n') ;
        }
        reader.Close();
    }

    void Save()
    {
        StreamWriter w;
        if (!f.Exists)
        {
            w = f.CreateText();
        }
        else
        {
            f.Delete();
            w = f.CreateText();
        }
        w.WriteLine(loadmessage);
        w.Close();
    }
    //planet
    public void addtoplanet()
    {
        InfoManager.instance.planetRadius+= 5;
        planettext.text = "Planet Radius: " + InfoManager.instance.planetRadius.ToString();
    }

    public void subtracttoplanet()
    {
        if (InfoManager.instance.planetRadius >= 20)
        {
            InfoManager.instance.planetRadius-= 5;

        }
        planettext.text = "Planet Radius: " + InfoManager.instance.planetRadius.ToString();
    }

//target
    public void addanimals()
    {
        if (InfoManager.instance.AnimalAmount < 15)
        {
        InfoManager.instance.AnimalAmount++;

        }
        animalstext.text = "Total Targets: " + InfoManager.instance.AnimalAmount.ToString();
    }

    public void subtractanimals()
    {
        if (InfoManager.instance.AnimalAmount >= 2)
        {
            InfoManager.instance.AnimalAmount--;

        }
        animalstext.text = "Total Targets: " + InfoManager.instance.AnimalAmount.ToString();
    }

 //level
    public void addLevel()
    {
        Levels.NextLevel();
        //LevelText.text = "Level: " + (InfoManager.instance.ID+1).ToString();
        LevelText.text = Levels.CurrentLevel().GetComponent<CityInfoController>().getName();
    }

    
    public void subtractLevel()
    {
        Levels.PreviousLevel();
        // LevelText.text = "Level: " + (InfoManager.instance.ID + 1).ToString();
        LevelText.text = Levels.CurrentLevel().GetComponent<CityInfoController>().getName();
    }
}
