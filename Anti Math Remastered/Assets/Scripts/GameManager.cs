using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {


    //Singleton instence for the class
    public static GameManager instance;
    
    // pass the player
    public GameObject player;
   
    // the planet
    public GameObject planet;

    //What is the size of the radius, or, how far away from the origin will the player spawn?
    public uint planetRadius = 5;

    // pass in the animal prefab
    public GameObject Animal;

    //How many animals in the level?
    public uint AnimalAmount = 5;
    //where to display the amount?
    public Text DonkeyAmount;

    //Notification system to alert when a question happens
    public delegate void QuestionAction();

    public static event QuestionAction QuestionTime;

    //Timer to determine how long the player will take.
    float timer = 0;
    //Text for the timer
    public Text timerText;

    private void Awake()
    {
        //30 fromaes per second
       // QualitySettings.vSyncCount = 0;
       // Application.targetFrameRate = 300;

        //Do I exist?
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        //turn gyroscope functionality
        Input.gyro.enabled = true;
        

    }


    #region Accessors and mutators

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

    #endregion

    private void Update()
    {
            timer += Time.deltaTime;
            timerText.text = Mathf.Floor(timer).ToString();     
    }


    public void ResetLevel()
    {
        timer = 0;
        SceneManager.LoadScene("3d camera behind kid");
    }

    public void CorrectAnswer()
    {
        if (QuestionTime != null)
        {
            QuestionTime();
            if (Animal != null)
                Animal.transform.position = new Vector3(9999, 9999, 9999);
                // Destroy(Animal);
            AnimalController.AnimalCount--;
            DonkeyAmount.text = "Donkeys remaining:" + AnimalController.AnimalCount;
            player.GetComponent<AudioSource>().Play();
           // Animal = null;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Animal")
        {
            if (QuestionTime != null)
            {
                QuestionTime();
                Animal = other.gameObject;
            }
                
        }
    }
}
