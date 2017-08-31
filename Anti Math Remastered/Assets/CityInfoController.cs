using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityInfoController : MonoBehaviour {

    [SerializeField]
     string Name;

    [SerializeField]
    int cityID;
    public string getName()
    {
        return Name;
    }

    public int getCityID()
    {
        return cityID;
    }
}
