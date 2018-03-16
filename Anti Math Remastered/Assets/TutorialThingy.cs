using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TutorialThingy : MonoBehaviour {

    
    //please forgive me beforehand...
    Text TheText;
    [SerializeField]
    Slider Slide;

    [SerializeField]
    GameObject arrow;
    [SerializeField]
    GameObject Child;
    static int Spheres;

    [SerializeField]
    GameObject[] temp;
    Queue<GameObject> CanvasThingies = new Queue<GameObject>();

    [SerializeField]
    Slider SlideSteer;

    
    bool starttimer;
    float ratioT;
    float gyroValu;
    float steerValue;

    private void OnEnable()
    {
        NewGameManager.QuestionTime += KillPic;
    }
    private void OnDisable()
    {
        NewGameManager.QuestionTime -= KillPic;
    }
    private void Start()
    {
        arrow.SetActive(false);
        //TheText = GetComponentInChildren<Text>();
        ratioT = 0.0f;
        Spheres = 5;
        gyroValu = Input.acceleration.z;

        for (int i = 0; i < temp.Length; i++)
        {
            temp[i].SetActive(false);
            CanvasThingies.Enqueue(temp[i]);
        }

        CanvasThingies.Peek().SetActive(true);
    }

    private void Update()
    {
        gyroValu = Input.acceleration.z;
        steerValue = Input.acceleration.x;
        CalibrateAcceleration();

        if (starttimer)
            ratioT += Time.deltaTime;
        if (ratioT >= 10)
        {
            KillPic();
            ratioT = -int.MaxValue;
            starttimer = false;
            //NewGameManager.instance.getBoy(0).GetComponent<KidScript>().SetupKidTutorial();
            NewGameManager.instance.SpawnKid();
            arrow.SetActive(true);
        }
        if (Spheres <= 0 && !starttimer)
        {
           // KillPic();
            starttimer = true;

        }
        
    }
    //accelerometer first
    bool CalibrateAcceleration()
    {
       // TheText.text = steerValue.ToString();
        Slide.value = gyroValu;
        SlideSteer.value = steerValue;
        return false;
    }

    //direction then
    bool CalibrateSteering()
    {
        return false;
    }

    //find a child. activate arrow
    bool FoundChild()
    {
        return false;
    }

    //fire a question
    bool TriggerQuestion()
    {
        return false;
    }

    public int GetSpheresQuant()
    {
        return Spheres;
    }
    public void ReduceSpheres()
    {
        Spheres--;
        
    }
    public void KillPic()
    {
        if(CanvasThingies.Count == 1)
        {
            //CanvasThingies.Peek().SetActive(false);
            StartCoroutine(Shrink(CanvasThingies.Peek()));
            CanvasThingies.Dequeue();
        }
        else
        {
            //CanvasThingies.Peek().SetActive(false);
            StartCoroutine(Shrink(CanvasThingies.Peek()));
            CanvasThingies.Dequeue();

        }
        
        if (CanvasThingies.Count > 0)
        {

        CanvasThingies.Peek().SetActive(true);
        }
        //else if (CanvasThingies.Count == 0)
        //{
        //    starttimer = true;
        //}
    }

    public void LoadScene()
    {
        NewInfoManager.instance.Basquet = false;
        PlayerPrefs.SetInt("BasquetInt", 0);
        SceneManager.LoadScene("Loading");
    }
    IEnumerator Shrink(GameObject toShrink)
    {
        float ratio = 0;

        while (ratio <= 1)
        {
            toShrink.transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, ratio);
            ratio += Time.deltaTime;
            yield return null;
        }
        toShrink.SetActive(false);
    }

   
}
