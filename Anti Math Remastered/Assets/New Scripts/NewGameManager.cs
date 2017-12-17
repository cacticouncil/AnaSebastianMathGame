using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewGameManager : MonoBehaviour {

    #region Members
    //Singleton instence for this class
    public static NewGameManager instance;

    // pass the player
    public GameObject player;

    //joystic
    public GameObject Joystic;
    // the planet
    public GameObject planet;

    //What is the size of the radius, or, how far away from the origin will the player spawn?
    public uint planetRadius;

    // pass in the animal prefab
    public GameObject Boy;
    public GameObject Girl;

    //How many animals in the level?
    public uint AnimalAmount;
    

    //Music stuff
    AudioClip MusicToPlay;
    AudioSource AS;

    //Notification system to alert when a question happens
    public delegate void QuestionAsked();   

    public static event QuestionAsked QuestionTime;

    //Timer to determine how long the player will take.
    public float timer;

    public bool pauseGame = false;

    ThingiesToLoad LevelToLoad;
   

   
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

        LevelToLoad = NewInfoManager.instance.GetCurrentThingyToLoad();
        GenerateGameEnvironment(NewInfoManager.instance.planetRadius, NewInfoManager.instance.AnimalAmount,LevelToLoad);
        
    }

    public void GenerateGameEnvironment(uint _radius = 100, uint _animalTotal = 5, ThingiesToLoad _levelToLoad = null)
    {
        AnimalAmount = _animalTotal;

        planetRadius =  _radius;
        planet.GetComponent<MeshRenderer>().material = Resources.Load<Material>(_levelToLoad.PlanetTexture1);
        planet.transform.localScale += new Vector3(planetRadius * 2,planetRadius * 2,planetRadius * 2);

        Boy.GetComponentInChildren<MeshRenderer>().material = Resources.Load<Material>(LevelToLoad.KidClothesBoy_);
        Girl.GetComponentInChildren<MeshRenderer>().material = Resources.Load<Material>(LevelToLoad.KidClothesGirl_);
    }

    //public void GenerateGame(int _radius, int _animalAmount, bool _useGyroscope, bool _timeAttack)
    //{
    //    planetRadius = (uint)_radius;
    //    AnimalAmount = (uint)_animalAmount;
    //    Gyroscope = _useGyroscope;
    //    timeAttack = _timeAttack;
    //}

    private void Start()
    {
      
    //    AS.clip = MusicToPlay;
    //    if (InfoManager.instance.Sound)
    //        AS.Play();
     
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

    public GameObject getBoy()
    {
        return Boy;
    }

    public GameObject getPlanet()
    {
        return planet;
    }

    #endregion

    private void Update()
    {
      //  if (InfoManager.instance.timeAttack && timer >= 0)
      //      timer -= Time.deltaTime;
      //  else
      //      timer += Time.deltaTime;
        
    }


    public void ResetLevel()
    {
        timer = 0;
        SceneManager.LoadScene("Main Menu Book");
    }

    public void CorrectAnswer()
    {
        if (!InfoManager.instance.Gyroscope)
            Joystic.SetActive(true);
        if (QuestionTime != null)
        {
            QuestionTime();
            if (Boy != null)
                Boy.transform.position = new Vector3(9999, 9999, 9999);
            // Destroy(Animal);

            if (InfoManager.instance.timeAttack)
            {
                AnimalController.AnimalCount++;
                timer += 5;
                
                Boy.GetComponent<AnimalController>().SetupAnimals(1);
                Boy.transform.LookAt(Vector3.zero);
                Boy.transform.Rotate(-90, 0, 0);
                if (timer >= 0)
                    player.GetComponent<AudioSource>().Play();
                else
                {
                   
                    player.GetComponent<AudioSource>().Play();
                }

            }
            else
            {
                AnimalController.AnimalCount--;
               
                if (AnimalController.AnimalCount != 0)
                    player.GetComponent<AudioSource>().Play();


                else
                {
                    
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
              


                Boy = other.gameObject;
            }

        }
    }
}
