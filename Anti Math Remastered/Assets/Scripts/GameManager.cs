using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    //Singleton instence for the class
    public static GameManager instance;

    // the planet
    public GameObject planet;

    //What is the size of the radius, or, how far away from the origin will the player spawn?
    public uint planetRadius = 5;

    //How many animals in the level?
    public uint AnimalAmount = 5;

    // pass in the animal prefab
    public GameObject Animal;

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

        //use the gyroscope
        Input.gyro.enabled = true;
    }

    public uint getPlanetRadius()
    {
        return planetRadius;
    }

    public uint getAnimalAmount()
    {
        return AnimalAmount;
    }

    public GameObject getAnimal()
    {
        return Animal;
    }

    public GameObject getPlanet()
    {
        return planet;
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene("3d camera behind kid");
    }
}
