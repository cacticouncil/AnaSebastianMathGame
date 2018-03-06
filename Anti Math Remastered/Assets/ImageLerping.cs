using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageLerping : MonoBehaviour {

    [SerializeField]
    bool appear;
    private void Update()
    {
        if (appear)
        {
            Color c = GetComponent<Image>().color;
            c.a = Mathf.Lerp(0, 255, Time.deltaTime);
            GetComponent<Image>().color = c;
        }
        else
        {
            Color c = GetComponent<Image>().color;
            c.a = Mathf.Lerp(255, 0, Time.deltaTime);
            GetComponent<Image>().color = c;
        }
    }
    public void FadeIn()
    {
       
       
    }

    
   
}
