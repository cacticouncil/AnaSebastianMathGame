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

    // pass in the chidlren prefabs
    public GameObject Boy;
    public GameObject Girl;

    List<GameObject> Children = new List<GameObject>();
    public GameObject GetChild(int index)
    {
        if (index >= 0 && index < Children.Count)
        {
            return Children[index];
        }

        return null;
    }
    public int childrenAmount;
    //plants to populate
    public GameObject plant;

    //How many animals in the level?
    public uint AnimalAmount;


    //Music stuff
    AudioClip MusicToPlay;
    AudioSource AS;

    //Notification system to alert when a question happens
    public delegate void QuestionAsked();
    public delegate void QuestionAnsweredRight();

    public static event QuestionAsked QuestionTime;
    public static event QuestionAnsweredRight QuestionCorrect;
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
        
        GenerateGameEnvironment(100, LevelToLoad);
        
        
        
    }

    public void GenerateGameEnvironment(uint _radius = 100, ThingiesToLoad _levelToLoad = null, uint BoyAmount = 3, uint GirlAmount = 3)
    {
        
        //get the planet ready
        planetRadius =  _radius;
        planet.GetComponent<MeshRenderer>().material = Resources.Load<Material>(_levelToLoad.PlanetTexture1);
        planet.transform.localScale = new Vector3(planetRadius * 2,planetRadius * 2,planetRadius * 2);

        //get the children ready
        Boy.GetComponentInChildren<MeshRenderer>().material = Resources.Load<Material>(LevelToLoad.KidClothesBoy_);
        Girl.GetComponentInChildren<MeshRenderer>().material = Resources.Load<Material>(LevelToLoad.KidClothesGirl_);

        for (int i = 0; i < BoyAmount; i++)
        {
            GameObject tempB = Instantiate(Boy);
            tempB.GetComponent<KidScript>().SetupKid();
            Children.Add(tempB);
        }

        for (int i = 0; i < GirlAmount; i++)
        {
            GameObject tempG = Instantiate(Girl);
            tempG.GetComponent<KidScript>().SetupKid();
            Children.Add(tempG);
        }

        childrenAmount = Children.Count;
        //get the plants ready
        int tex = 0;
        for (int i = 0; i < 500; i++)
        {
            GameObject tempP = Instantiate(plant);
            switch (tex)
            {
                case 0:
                    tempP.GetComponent<PlantsScript>().SetupPlant(Resources.Load<Sprite>(LevelToLoad.GetPlantTexture(0)));
                    break;
                case 1:
                    tempP.GetComponent<PlantsScript>().SetupPlant(Resources.Load<Sprite>(LevelToLoad.GetPlantTexture(1)));
                    break;
                case 2:
                    tempP.GetComponent<PlantsScript>().SetupPlant(Resources.Load<Sprite>(LevelToLoad.GetPlantTexture(2)));
                    break;
            }
            tex++;
            if (tex >= 3)
            {
                tex = 0;
            }
        }
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
        if (QuestionCorrect != null)
        {
            QuestionCorrect();
        }
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Child")
        {
            
            if (QuestionTime != null)
            {
                QuestionTime();
            }

        }
    }
}
