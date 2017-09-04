using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IOMenu : MonoBehaviour {

    public Text animalstext;
    public Text planettext;
    public Text LevelText;
   public LevelSelectionController Levels;
    private void Start()
    {
        animalstext.text = "Total Targets: " + InfoManager.instance.AnimalAmount.ToString();
        planettext.text = "Planet Radius: " + InfoManager.instance.planetRadius.ToString();
        // LevelText.text = "Level: " + (InfoManager.instance.ID + 1).ToString();
        LevelText.text = Levels.CurrentLevel().GetComponent<CityInfoController>().getName();
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
