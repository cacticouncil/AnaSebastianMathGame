using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadScenes : MonoBehaviour {

    public Image pic;
    public Button mainButt;
    public Button CreditsButton;
    public Button OptionsButton;
    public Button BackToMainButton;

    public void load(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    bool doit;
    float ratio;

    private void Start()
    {
        Time.timeScale = 1;
        mainButt.enabled = true;
        ratio = 0;
        doit = false;
    }
    public void Dissappear()
    {
        
        doit = true;
        mainButt.enabled = false;
        CreditsButton.enabled = false;
        OptionsButton.enabled = false;
       mainButt.transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, ratio);
       //CreditsButton.transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, ratio);
        Color col = new Color();
        
        col = pic.color;
       
        col.a = Mathf.Lerp(1, 0, ratio);
        pic.color = col;

        ratio += Time.deltaTime;
        if (ratio >= 0.95f)
        {
            pic.enabled = false;
            CreditsButton.transform.localScale = Vector3.zero;
            OptionsButton.transform.localScale = Vector3.zero;
             doit = false;
            ratio = 0;
        }
        
    }

    public void BackToMain()
    {
        doit = false;
        mainButt.enabled = true;
        CreditsButton.enabled = true;
        OptionsButton.enabled = true;
        mainButt.transform.localScale = new Vector3(10,20);//Vector3.Lerp(transform.localScale, Vector3.zero, ratio);
        //CreditsButton.transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, ratio);
        Color col = new Color();

        col = pic.color;

        col.a = Mathf.Lerp(1, 0, ratio);
        pic.color = col;

        ratio -= Time.deltaTime;
        if (ratio <= 0.95f)
        {
            pic.enabled = true;
            CreditsButton.transform.localScale = Vector3.one;
            OptionsButton.transform.localScale = Vector3.one;
            
            ratio = 0;
        }
    }
    private void Update()
    {
        if(ratio > 0.5f)
        Debug.Log(ratio);
        if (doit)
            Dissappear();
    }

}
