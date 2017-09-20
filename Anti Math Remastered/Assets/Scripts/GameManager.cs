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

    //Add? Subtract? you choose
    public Sprite[] Symbols;

    public Material[] SkyBoxes;
    //Notification system to alert when a question happens
    public delegate void QuestionAction();

    public delegate void FillBasket();

    public static event QuestionAction QuestionTime;

    public static event FillBasket SetBasket;
    //Timer to determine how long the player will take.
    float timer = 0;
    //Text for the timer
    public Text timerText;

    public bool pauseGame = false;

    public int a;
    public int b;
    public int answer;
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
        switch (InfoManager.instance.ID)
        {
            case 0:
                planetRadius = InfoManager.instance.planetRadius = 50;
                AnimalAmount = InfoManager.instance.AnimalAmount = 2;

                break;
            case 1:
                planetRadius = InfoManager.instance.planetRadius = 100;
                AnimalAmount = InfoManager.instance.AnimalAmount = 3;
                break;
            case 2:
                planetRadius = InfoManager.instance.planetRadius = 150;
                AnimalAmount = InfoManager.instance.AnimalAmount = 5;
                break;
        }
        //Uncomment this and comment the switch case above to re enable custom sizes
        //planetRadius = InfoManager.instance.planetRadius;
        //AnimalAmount = InfoManager.instance.AnimalAmount;

        //set audio source
        AS = GetComponent<AudioSource>();

        //set skybox
        RenderSettings.skybox = SkyBoxes[InfoManager.instance.ID];

        pauseGame = false;
        Time.timeScale = 1;
    }

    private void Start()
    {
        MusicToPlay = LevelsMusic[InfoManager.instance.ID];
        AS.clip = MusicToPlay;
        if (InfoManager.instance.Sound)
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

    public void WrongAnswer()
    {
       // if (QuestionTime != null)
       // {
       //     //QuestionTime();
       //     SetBasket();
       // }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Animal")
        {
            if (QuestionTime != null)
            {
                QuestionTime();
                SetBasket();
                Animal = other.gameObject;
            }
                
        }
    }
}
