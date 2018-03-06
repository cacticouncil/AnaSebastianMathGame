using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sliderMenu : MonoBehaviour {

    float ratio;
   public bool increment;
    public Image slide;

    [SerializeField]
    TutorialThingy tut;

    private void Start()
    {
        ratio = 0;
        increment = false;
        slide.transform.localScale = new Vector3(ratio, ratio);
    }
  //  private void OnTriggerEnter(Collider other)
  //  {
  //      if (other.tag == "Slider")
  //      {
  //          increment = true;
  //
  //      }
  //  }
  //
  //  private void OnTriggerExit(Collider other)
  //  {
  //      if (other.tag == "Slider")
  //      {
  //          increment = false;
  //
  //      }
  //  }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Slider")
        {
            increment = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Slider")
        {
            increment = false;

        }
    }
    
    private void Update()
    {
        if (increment)
        {
            if (ratio <= 1)
            {
            ratio += Time.deltaTime;

            }
        }
        else
        {
            if (ratio >= 0)
            {
                ratio -= Time.deltaTime;

            }
        }
        if (ratio >= 0.95f)
        {
            ratio = 0;
            tut.ReduceSpheres();
            if (tut.GetSpheresQuant() == 2)
            {
            tut.KillPic();
            }
            else if (tut.GetSpheresQuant() == 0)
            {
                tut.KillPic();
            }
            // Destroy(this.gameObject);
            StartCoroutine(playandkill());
        }
       slide.transform.localScale = new Vector3(ratio, ratio);
    }


    IEnumerator playandkill()
    {
        Vector3 oblivion = new Vector3(int.MaxValue, int.MaxValue);
        GetComponent<AudioSource>().Play();
        transform.position = oblivion;
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
