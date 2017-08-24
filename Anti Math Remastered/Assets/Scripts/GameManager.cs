using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {

    #region Members
    //Singleton instence for this class
    public static GameManager instance;

    // pass the player
    public GameObject player;

    // the planet
    public GameObject planet;

    //What is the size of the radius, or, how far away from the origin will the player spawn?
    public uint planetRadius;

    // pass in the animal prefab
    public GameObject Animal;

    //How many animals in the level?
    public uint AnimalAmount;
    //where to display the amount?
    public Text DonkeyAmount;

    //Music stuff
    public AudioClip[] LevelsMusic;
    AudioClip MusicToPlay;
    AudioSource AS;

    //just cats for mow
    public Sprite[] cats;
   
    //Notification system to alert when a question happens
    public delegate void QuestionAction();

    public static event QuestionAction QuestionTime;

    //Timer to determine how long the player will take.
    float timer = 0;
    //Text for the timer
    public Text timerText;

    public bool pauseGame = false;
    #endregion


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

        planetRadius = InfoManager.instance.planetRadius;
        AnimalAmount = InfoManager.instance.AnimalAmount;
        AS = GetComponent<AudioSource>();
    }

    private void Start()
    {
        MusicToPlay = LevelsMusic[InfoManager.instance.ID];
        AS.clip = MusicToPlay;
        AS.Play();
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
        SceneManager.LoadScene("Main Menu");
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
            DonkeyAmount.text = "Targets remaining:" + AnimalController.AnimalCount;
            if (AnimalController.AnimalCount != 0)
                player.GetComponent<AudioSource>().Play();
            else
            {
                player.GetComponent<AudioSource>().clip = LevelsMusic[3];
                player.GetComponent<AudioSource>().Play();
            }
               
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
