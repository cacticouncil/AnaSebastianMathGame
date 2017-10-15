using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityInfoController : MonoBehaviour {

    [SerializeField]
     string Name;

    [SerializeField]
    string Topic;

    [SerializeField]
    int cityID;

    [SerializeField]
    string About;

    public string Summary;

    public string getName()
    {
        return Name;
    }

    public string GetTopic()
    {
        return Topic;
    }

    public int getCityID()
    {
        return cityID;
    }

    public string getAboutCity()
    {
        return About;
    }

    public string getSummary()
    {
        return Summary;
    }
}
