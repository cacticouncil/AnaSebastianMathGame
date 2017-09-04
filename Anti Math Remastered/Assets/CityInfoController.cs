using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityInfoController : MonoBehaviour {

    [SerializeField]
     string Name;

    [SerializeField]
    int cityID;

    [SerializeField]
    string About;

    public string getName()
    {
        return Name;
    }

    public int getCityID()
    {
        return cityID;
    }

    public string getAboutCity()
    {
        return About;
    }
}
