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

    //joystic
    public GameObject Joystic;
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

    //skylines for each city
    public Sprite[] Skylines;

    //plants
    public Sprite[] Plants;

    //Add? Subtract? you choose
    public Sprite[] Symbols;

    public Material[] SkyBoxes;
    //Notification system to alert when a question happens
    public delegate void QuestionAction();

    public delegate void FillBasket();

    public static event QuestionAction QuestionTime;

    public static event FillBasket SetBasket;
    //Timer to determine how long the player will take.
   public  float timer;
    //Text for the timer
    public Text timerText;

    public bool pauseGame = false;

    public int a;
    public int b;
    public int c;
    public bool Agtb;
    public bool Bgta;
    public bool Equal;
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
                planetRadius = InfoManager.instance.planetRadius = 100;
                AnimalAmount = InfoManager.instance.AnimalAmount = 2;
                InfoManager.instance.timeAttack = false;

                break;
            case 1:
                planetRadius = InfoManager.instance.planetRadius = 100;
                AnimalAmount = InfoManager.instance.AnimalAmount = 3;
                InfoManager.instance.timeAttack = false;

                break;
            case 2:
                planetRadius = InfoManager.instance.planetRadius = 100;
                AnimalAmount = InfoManager.instance.AnimalAmount = 5;
                InfoManager.instance.timeAttack = false;

                break;
            case 3:
                planetRadius = InfoManager.instance.planetRadius = 100;
                AnimalAmount = InfoManager.instance.AnimalAmount = 5;
                InfoManager.instance.timeAttack = false;

                break;
            case 4:
                planetRadius = InfoManager.instance.planetRadius = 100;
                AnimalAmount = InfoManager.instance.AnimalAmount = 5;
                InfoManager.instance.timeAttack = false;

                break;
            case 5:
                planetRadius = InfoManager.instance.planetRadius = 100;
                AnimalAmount = InfoManager.instance.AnimalAmount = 1;
                InfoManager.instance.timeAttack = true;
                break;
            case 6:
                planetRadius = InfoManager.instance.planetRadius = 100;
                AnimalAmount = InfoManager.instance.AnimalAmount = 1;
                InfoManager.instance.timeAttack = true;
                break;
            case 7:
                planetRadius = InfoManager.instance.planetRadius = 100;
                AnimalAmount = InfoManager.instance.AnimalAmount = 1;
                InfoManager.instance.timeAttack = true;
                break;
            case 8:
                planetRadius = InfoManager.instance.planetRadius = 100;
                AnimalAmount = InfoManager.instance.AnimalAmount = 1;
                InfoManager.instance.timeAttack = true;
                break;
            case 9:
                planetRadius = InfoManager.instance.planetRadius = 100;
                AnimalAmount = InfoManager.instance.AnimalAmount = 1;
                InfoManager.instance.timeAttack = true;
                break;
        }
        //Uncomment this and comment the switch case above to re enable custom sizes
        //planetRadius = InfoManager.instance.planetRadius;
        //AnimalAmount = InfoManager.instance.AnimalAmount;

        if (InfoManager.instance.timeAttack)
            timer = 30;
        else
            timer = 0;

        if (InfoManager.instance.Gyroscope)
            Joystic.SetActive(false);
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
        if(InfoManager.instance.timeAttack)
        DonkeyAmount.text = "Kids Found:" + (AnimalController.AnimalCount -1);
        else
         DonkeyAmount.text = "Kids Remaining: " + AnimalController.AnimalCount;


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
        if (InfoManager.instance.timeAttack && timer >= 0)
            timer -= Time.deltaTime;
        else
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
        if (!InfoManager.instance.Gyroscope)
            Joystic.SetActive(true);
        if (QuestionTime != null)
        {
            QuestionTime();
            if (Animal != null)
                Animal.transform.position = new Vector3(9999, 9999, 9999);
            // Destroy(Animal);

            if (InfoManager.instance.timeAttack)
            {
                AnimalController.AnimalCount++;
                timer += 5;
                DonkeyAmount.text = "Kids Found:" + (AnimalController.AnimalCount -1);
                Animal.GetComponent<AnimalController>().SetupAnimals(1);
                Animal.transform.LookAt(Vector3.zero);
                Animal.transform.Rotate(-90, 0, 0);
                if ( timer >= 0)
                player.GetComponent<AudioSource>().Play();
                else
                {
                    player.GetComponent<AudioSource>().clip = LevelsMusic[10];
                    player.GetComponent<AudioSource>().Play();
                }

            }
            else
            {
                AnimalController.AnimalCount--;
                DonkeyAmount.text = "Kids remaining:" + AnimalController.AnimalCount;
                if (AnimalController.AnimalCount != 0)
                    player.GetComponent<AudioSource>().Play();


                else
                {
                    player.GetComponent<AudioSource>().clip = LevelsMusic[10];
                    player.GetComponent<AudioSource>().Play();
                }
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
            if (!InfoManager.instance.Gyroscope)
            {
                Joystic.GetComponentInChildren<WheelController>().ResetJoystickPos();
                Joystic.gameObject.SetActive(false);
            }
            if (QuestionTime != null)
            {
                QuestionTime();
                if (SetBasket != null)
                 SetBasket();
                

                Animal = other.gameObject;
            }
                
        }
    }
}
