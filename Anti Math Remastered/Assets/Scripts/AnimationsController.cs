using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class AnimationsController : MonoBehaviour {


   public BookMark[] Bookmarks;
    public GameObject[] Countries;
    public Animator CamAnim;
    public Animator ControlsAnim;
    public Animator BasquetAnim;
    public Animator SoundAnim;
    public Animator HandAnim;
    public GameObject ParticleSys;
    public Text CountryText;
   RaycastHit hit;
    int ID = -1;
    int CurrentPage = -1;
    bool zoom = false;
    bool Zleft;
    bool Zright;

    private void Start()
    {
        Time.timeScale = 1;
        ParticleSys.SetActive(false);
       ControlsAnim.SetBool("Decide", InfoManager.instance.Gyroscope);
        ControlsAnim.SetTrigger("Change");
        BasquetAnim.SetBool("Decide", InfoManager.instance.Basquet);
        BasquetAnim.SetTrigger("Change");
        SoundAnim.SetBool("Decide", InfoManager.instance.Sound);
        SoundAnim.SetTrigger("Change");

    }
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       //if (EventSystem.current.IsPointerOverGameObject())
       //     return;
       //if (CamAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !CamAnim.IsInTransition(0))
       //    return;
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
        {
            
            CamAnim.SetBool("OpenPage", true);
            HandAnim.SetBool("OpenedBook", true);
            if (zoom)
            {
                //zoom out from the right page
                if (hit.collider.gameObject.tag == "TopCollider" && Zright)
                {
                    zoom =Zright = false;
                    CamAnim.SetBool("ZoomIntoLeftPage", false);
                    CamAnim.SetBool("ZoomIntoPage", false);
                    CamAnim.SetBool("ZoomIntoPage", zoom);
                }

                else if (hit.collider.gameObject.tag == "TopCollider" && !Zright)
                {
                    CamAnim.SetBool("ZoomIntoLeftPage", true);
                    CamAnim.SetBool("ZoomIntoPage", true);
                    CamAnim.SetTrigger("MoveToPage");
                    //CamAnim.SetBool("ZoomIntoLeftPage", false);
                    Zleft = false;
                    Zright = true;
                }

                //zoom in from the left page
                if (hit.collider.gameObject.tag == "BottomCollider" && Zleft)
                {
                    zoom = Zleft = false;
                    CamAnim.SetBool("ZoomIntoLeftPage", false);
                    CamAnim.SetBool("ZoomIntoPage", false);
                    CamAnim.SetBool("ZoomIntoLeftPage", zoom);
                }

                else if (hit.collider.gameObject.tag == "BottomCollider" && !Zleft)
                {
                    CamAnim.SetBool("ZoomIntoPage", true);
                    CamAnim.SetBool("ZoomIntoLeftPage", true);
                    CamAnim.SetTrigger("MoveToPage");
                  //  CamAnim.SetBool("ZoomIntoPage", false);
                    Zright = false;
                    Zleft = true;
                }
            }
            else
            {
                //check to change page
                if (hit.collider.gameObject.tag == "TopCollider")
                {
                    zoom = Zright = true;
                    CamAnim.SetBool("ZoomIntoPage", zoom);

                }


                //check where to zoom
                if (hit.collider.gameObject.tag == "BottomCollider")
                {
                    zoom = Zleft = true;
                    CamAnim.SetBool("ZoomIntoLeftPage", zoom);

                }

                AnimateTheBook(hit);

            }


            //Check for countries
            if (hit.collider.gameObject.tag == "Country")
            {
                ParticleSys.SetActive(true);
                ParticleSys.transform.position = hit.collider.gameObject.GetComponentInChildren<CityInfoController>().gameObject.transform.position;
                CountryText.text = hit.collider.gameObject.GetComponentInChildren<CityInfoController>().getName()+ '\n'+'\n';
                CountryText.text +=  hit.collider.gameObject.GetComponentInChildren<CityInfoController>().GetTopic() + '\n' + '\n';
                CountryText.text += hit.collider.gameObject.GetComponentInChildren<CityInfoController>().getAboutCity();
               InfoManager.instance.ID = ((uint)hit.collider.gameObject.GetComponentInChildren<CityInfoController>().getCityID()-1);
                ID = 1;
            }
            else if(hit.collider.gameObject.tag == "BookMark")
            {
                ParticleSys.SetActive(false);
                CountryText.text = "Tap any country on the map to know what it holds for you! \n You can zoom in by tapping the sea!";
                InfoManager.instance.Save();
                ID = -1;
                HandAnim.SetBool("TouchedBookMark", true);
            }

            //check for options
            if (hit.collider.gameObject.tag == "ControlsToggle")
            {
                InfoManager.instance.Gyroscope = !InfoManager.instance.Gyroscope;
                ControlsAnim.SetBool("Decide", InfoManager.instance.Gyroscope);
            }
            if (hit.collider.gameObject.tag == "BasquetToggle")
            {
                InfoManager.instance.Basquet = !InfoManager.instance.Basquet;
                BasquetAnim.SetBool("Decide", InfoManager.instance.Basquet);
            }
            if (hit.collider.gameObject.tag == "SoundToggle")
            {
                InfoManager.instance.Sound = !InfoManager.instance.Sound;
                SoundAnim.SetBool("Decide", InfoManager.instance.Sound);
            }
            //check to proceed to play
            if (hit.collider.gameObject.tag == "Accept" && ID != -1)
            {
                CamAnim.SetTrigger("StartPlaying");

              //  InfoManager.instance.LoadLoadScene();
            }
            

            
        }
    }


    void AnimateTheBook(RaycastHit _hit)
    {
        int ThatOne = -1;
        for (int i = 0; i < Bookmarks.Length; i++)
        {
            if (_hit.collider.gameObject == Bookmarks[i].gameObject)
            {
                ThatOne = i;
                break;
            }
        }

        if (ThatOne <= CurrentPage && CurrentPage != -1 && ThatOne > 0)
        {

            for (int i = CurrentPage; i >= 0; i--)
            {
                Bookmarks[i].TurnPage(false);
            }

            for (int i = ThatOne - 1; i >= 0; i--)
            {
                Bookmarks[i].TurnPage(true);
            }

        }
        else
        {
            if (ThatOne >= 0 && ThatOne < Bookmarks.Length - 1)
                for (int i = ThatOne; i >= 0; i--)
                {
                    Bookmarks[i].TurnPage(true);
                }
            else if (ThatOne == (Bookmarks.Length - 1))
            {
                for (int i = ThatOne; i >= 0; i--)
                {
                    Bookmarks[i].TurnPage(false);
                }
                CamAnim.SetBool("OpenPage", false);
                CurrentPage = -1;
            }
        }


        if (ThatOne == CurrentPage || CurrentPage == Bookmarks.Length - 1)
            CurrentPage = -1;
        else
            CurrentPage = ThatOne;
    }
}
