using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BookAnimations : MonoBehaviour {

    public Animator DefaultPage;
    public Animator[] PagesThatMatter;
    public GameObject[] Countries;
    public Animator CamAnim;
    public Animator SoundAnim;
    public Animator BasquetAnim;
    public Animator[] Options;
    public GameObject CurrentLocationPoint;
    public Text CountryText;
    public Text HighScoreText;
    public SpriteRenderer CountrySprite;
    public Text AcceptButtonText;
    public GameObject SideUI;
    public GameObject AreYouSureCanvas;
    RaycastHit hit;
    Sprite original;
    int ID = -1;
    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
         CurrentLocationPoint.SetActive(false);
        CountrySprite.sprite = null;
        original =  null;//CountrySprite.sprite;

        SoundAnim.SetTrigger("Change");
        SoundAnim.SetBool("Decide", NewInfoManager.instance.Sound);
        BasquetAnim.SetTrigger("Change");
        BasquetAnim.SetBool("Decide", NewInfoManager.instance.Basquet);
    }
    GameObject cur;
    GameObject prev;
	// Update is called once per frame
	void Update () {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
        {
            //Check for countries
            if (hit.collider.gameObject.tag == "Country")
            {
                cur = hit.collider.gameObject;
                if (cur == prev)
                    return;
                //enable pointer for place
                CurrentLocationPoint.SetActive(true);
                CurrentLocationPoint.transform.position = hit.collider.gameObject.GetComponentInChildren<CityInfoController>().gameObject.transform.position;
                //fill in the current country information
                hit.collider.gameObject.GetComponent<AudioSource>().Play();
                CountryText.text = hit.collider.gameObject.GetComponentInChildren<CityInfoController>().getName() + '\n' + '\n';
                CountryText.text += hit.collider.gameObject.GetComponentInChildren<CityInfoController>().GetTopic() + '\n' + '\n';
                CountrySprite.sprite = hit.collider.gameObject.GetComponentInChildren<CityInfoController>().getCityPicture();
                CountrySprite.transform.localScale = new Vector3(3, 3, 1);
                //update the infomanager
                NewInfoManager.instance.SetID(((uint)hit.collider.gameObject.GetComponentInChildren<CityInfoController>().getCityID() - 1));
                HighScoreText.text = "High score: " + NewInfoManager.instance.HighScores[NewInfoManager.instance.GetID()].ToString();
                AcceptButtonText.text = " Tap here to go!";
                ID = 1;
                prev = cur;
            }
            else if (hit.collider.gameObject.tag == "SoundToggle")
            {
                hit.collider.gameObject.GetComponent<AudioSource>().Play();
                NewInfoManager.instance.Sound = !NewInfoManager.instance.Sound;
                SoundAnim.SetBool("Decide", NewInfoManager.instance.Sound);
            }
           else if (hit.collider.gameObject.tag == "BasquetToggle")
            {
                hit.collider.gameObject.GetComponent<AudioSource>().Play();
                NewInfoManager.instance.Basquet = !NewInfoManager.instance.Basquet;
                BasquetAnim.SetBool("Decide", NewInfoManager.instance.Basquet);
            }
           else if (hit.collider.gameObject.tag == "ControlsToggle")
            {
                hit.collider.gameObject.GetComponent<AudioSource>().Play();
                AreYouSureCanvas.GetComponent<Obvlivion>().BringMeBack();

            }
            //check to proceed to play
            else if (hit.collider.gameObject.tag == "Accept" && ID != -1)
            {
                hit.collider.gameObject.GetComponent<AudioSource>().Play();
                CamAnim.SetTrigger("StartPlaying");
                SideUI.SetActive(false);
                //  InfoManager.instance.LoadLoadScene();
            }
        }

    }

    public void OpenBook()
    {
        DefaultPage.SetBool("Turn Page", true);
       
    }

   
    public void ChangePage(int CurrentID, int newID)
    {
        prev = null;
        cur = null;
        ID = -1;
        AcceptButtonText.text = string.Empty;
        HighScoreText.text = string.Empty;
        GetComponent<AudioSource>().Play();
        CountrySprite.transform.localScale = Vector3.one;
        CountrySprite.sprite = null; // original;
        CurrentLocationPoint.SetActive(false);
        CountryText.text = "Tap any country on the map to know what it holds for you!";// \n You can zoom in by tapping the sea!";
        NewInfoManager.instance.Save();
        if (newID == 3)
        {
            for (int i = CurrentID-1; i >=0; i--)
            {
                PagesThatMatter[i].SetBool("Turn Page", false);
            }
            DefaultPage.SetBool("Turn Page", false);
            return;
        }
        if (CurrentID > newID)
        {
            for (int i = CurrentID-1; i >= newID; i--)
            {
                PagesThatMatter[i].SetBool("Turn Page", false);
            }
        }
        else
        {
            for (int i = CurrentID; i < newID /*PagesThatMatter.Length*/; i++)
            {
                PagesThatMatter[i].SetBool("Turn Page", true);
            }
        }
    }
}
