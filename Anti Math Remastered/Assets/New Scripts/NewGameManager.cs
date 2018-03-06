using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewGameManager : MonoBehaviour {

    #region Members
    [SerializeField]
    bool tutorial = false;
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
    GameObject currentKid;

   // //Music stuff
   // AudioClip MusicToPlay;
   // AudioSource AS;

    //Notification system to alert when a question happens
    public delegate void QuestionAsked();
    public delegate void QuestionAnsweredRight();
    public delegate void PausedTriggered();
    public delegate void GameDone();

    public static event QuestionAsked QuestionTime;
    public static event QuestionAnsweredRight QuestionCorrect;

    public static event PausedTriggered Paused;
    public static event PausedTriggered UnPaused;

    public static event GameDone EndGame;
    public static event GameDone NewHighScore;
    //Timer to determine how long the player will take.
    public float timer;

    public bool pauseGame = false;
    bool StoTimeThereIsAQuestion = false;
    bool gameOver = false;

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

        if (!tutorial)
        {
        LevelToLoad = NewInfoManager.instance.GetCurrentThingyToLoad();
            GenerateGameEnvironment(100, LevelToLoad);

        }
        else
        {
            childrenAmount = 1;
            GameObject boi = Instantiate(Boy);
            boi.transform.position = Vector3.zero;
            Children.Add(boi);
            if (NewInfoManager.instance.Sound)
                Camera.main.GetComponent<AudioSource>().Play();
        }
        
        
        
    }

    public void GenerateGameEnvironment(uint _radius = 100, ThingiesToLoad _levelToLoad = null, uint BoyAmount = 3, uint GirlAmount = 3)
    {
        GetComponent<AudioSource>().clip = Resources.Load<AudioClip>(LevelToLoad.getSong());
        if(NewInfoManager.instance.Sound)
             GetComponent<AudioSource>().Play();
        //get the planet ready
        planetRadius =  _radius;
        planet.GetComponent<MeshRenderer>().material = Resources.Load<Material>(_levelToLoad.PlanetTexture1);
        planet.transform.localScale = new Vector3(planetRadius * 2,planetRadius * 2,planetRadius * 2);

        //get the children ready
        Boy.GetComponentInChildren<MeshRenderer>().material = Resources.Load<Material>(LevelToLoad.KidClothesBoy_);
        Girl.GetComponentInChildren<MeshRenderer>().material = Resources.Load<Material>(LevelToLoad.KidClothesGirl_);

        //all of this was before time attack
        //for (int i = 0; i < BoyAmount; i++)
        //{
        //    GameObject tempB = Instantiate(Boy);
        //    tempB.GetComponent<KidScript>().SetupKid();
        //    Children.Add(tempB);
        //}

        //for (int i = 0; i < GirlAmount; i++)
        //{
        //    GameObject tempG = Instantiate(Girl);
        //    tempG.GetComponent<KidScript>().SetupKid();
        //    Children.Add(tempG);
        //}
        //childrenAmount = Children.Count;

        SpawnKid();
        childrenAmount = 0;
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

    public void SpawnKid()
    {
        Vector3 KidPos = -transform.position;
        if (Random.Range(0,10) % 2 == 0)
        {
            KidPos = Vector3.Cross(KidPos, transform.up);
            if (Random.Range(0,10) % 2 == 0)
            {
                KidPos = -KidPos;
            }
        }
        KidPos.Normalize();
        KidPos *= planetRadius;
        int Gender = Random.Range(0, 10);
        if (Gender % 2 == 0)
        {
             GameObject b= Instantiate(Boy);
            b.GetComponent<KidScript>().SetupKid(KidPos);
            currentKid = b;
        }
        else
        {
            GameObject b = Instantiate(Girl);
            b.GetComponent<KidScript>().SetupKid(KidPos);
            currentKid = b;
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

    public GameObject getBoy(int i)
    {
        return Children[i];
    }

    public GameObject getGirl()
    {
        return Girl;
    }
    public GameObject GetCurrentChild()
    {
        return currentKid;
    }
    public int getTotalChildren()
    {
        return childrenAmount;
    }

    public float GetTimerF()
    {
        return timer;
    }
    public int GetTimerI()
    {
        return (int)timer;
    }
    public GameObject getPlanet()
    {
        return planet;
    }

    #endregion

    private void Update()
    {
        if (gameOver)
            return;

        if(!StoTimeThereIsAQuestion && !pauseGame && !gameOver)
        {
            if (!tutorial)
            {

        timer -= Time.deltaTime;
            }
        }

        if (timer <= 0) // if (childrenAmount <= 0)
        {
            if (EndGame != null)
            {
            EndGame();
                gameOver = true;
                if (tutorial)
                    return;
                if (NewInfoManager.instance != null)
                if (childrenAmount > NewInfoManager.instance.HighScores[NewInfoManager.instance.GetID()])
                {
                    PlayerPrefs.SetInt("High Score " + NewInfoManager.instance.GetID().ToString(), childrenAmount);
                   NewHighScore();
                }
            }
        }

        
    }

    public void PauseGame(bool _pause)
    {
        if (_pause)
        {
            Time.timeScale = 0;
            pauseGame = true;
            GetComponent<AudioSource>().volume = 0.2f;
            if (Paused != null)
             Paused();
            //the timescale set to 0 is done in the pausemenucanvas script, since they 
            //need to be aniamted prior to stopping time to pause.
        }
        else
        {
            Time.timeScale = 1;
            pauseGame = false;
            GetComponent<AudioSource>().volume = 1f;
            if (UnPaused != null)
                UnPaused();

        }
    }

   
    public void ChangeScene(string scene)
    {
        if (NewInfoManager.instance != null)
            if (childrenAmount > NewInfoManager.instance.HighScores[NewInfoManager.instance.GetID()])
        {
            PlayerPrefs.SetInt("High Score " + NewInfoManager.instance.GetID().ToString(), childrenAmount);
            NewInfoManager.instance.LoadHighScores();
        }
        SceneManager.LoadScene(scene);
    }

    public void CorrectAnswer()
    {
        if (QuestionCorrect != null)
        {
            if (tutorial)
            {
                timer = 0;
                QuestionCorrect();
                StoTimeThereIsAQuestion = false;
                return;
            }
            timer += 3f;
            QuestionCorrect();
            StoTimeThereIsAQuestion = false;
            childrenAmount++;
            SpawnKid();

            
        }
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Child")
        {
            
            if (QuestionTime != null)
            {
                QuestionTime();
                StoTimeThereIsAQuestion = true;
            }

        }
    }
}
