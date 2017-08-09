using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //Singleton instence for the class
    public static GameManager instance;

    //What is the size of the radius, or, how far away from the origin will the player spawn?
    public int planetRadius;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public int getPlanetRadius()
    {
        return planetRadius;
    }

}
