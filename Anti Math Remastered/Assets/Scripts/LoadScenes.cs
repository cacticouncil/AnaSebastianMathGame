using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadScenes : MonoBehaviour {

    public Image pic;
    public Button mainButt;
    public void load(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    bool doit;
    float ratio;
    public void Dissappear()
    {
        
        doit = true;
        mainButt.enabled = false;
        mainButt.gameObject.SetActive(false);
        Color col = new Color();
        
        col = pic.color;
       
        col.a = Mathf.Lerp(1, 0, ratio);
        pic.color = col;

        ratio += Time.deltaTime;
        if (ratio >= 0.95)
        {
            pic.enabled = false;
           
            doit = false;
        }
        
    }

    private void Update()
    {
        if (doit)
            Dissappear();
    }

}
