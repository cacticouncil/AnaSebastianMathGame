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

    public Text animalstext;
    public Text planettext;

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

    public void addtoplanet()
    {
        planetRadius++;
        planettext.text = "Planet Radius: " + planetRadius.ToString();
    }

    public void addanimals()
    {
        AnimalAmount++;
        animalstext.text = "Total Animals: " + AnimalAmount.ToString();
    }

   public void subtracttoplanet()
    {
        if (planetRadius >= 20)
        {
        planetRadius--;

        }
        planettext.text = "Planet Radius: " + planetRadius.ToString();
    }

    public void subtractanimals()
    {
        if (AnimalAmount >= 2)
        {
        AnimalAmount--;

        }
        animalstext.text = "Total Animals: " + AnimalAmount.ToString();
    }

}
