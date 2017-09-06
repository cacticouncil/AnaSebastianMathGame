using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Credits : MonoBehaviour {

   public Image Creditsimage;
   public Button BackToMenuButton;

    public Image OptionsImage;
    public Button OptionsButton;

    float ratio;
    float ratio2;
    bool ShowCredits;
    bool ShowOptions;
    private void Start()
    {
        ShowCredits = false;
        ShowOptions = false;
        Creditsimage.transform.localScale = Vector3.zero;
        BackToMenuButton.transform.localScale = Vector3.zero;
        OptionsImage.transform.localScale = Vector3.zero;
        OptionsButton.transform.localScale = Vector3.zero;
        ratio = 0;
    }
   public void ToggleCredits()
    {
        ShowCredits = !ShowCredits;
    }

    public void ToggleOptions()
    {
        ShowOptions = !ShowOptions;
    }
    private void Update()
    {
        if (ShowCredits)
        {
            Creditsimage.transform.localScale = Vector3.Lerp(Vector3.zero, new Vector3(10, 5, 1) , ratio);
            //BackToMenuButton.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, ratio);
           ratio += Time.deltaTime;
            if (ratio >= 1)
            {
                BackToMenuButton.transform.localScale = Vector3.one;
               ratio = 1;
            }
        }
        else
        {
            Creditsimage.transform.localScale = Vector3.Lerp(Vector3.zero, new Vector3(10, 5, 1), ratio);
            // BackToMenuButton.transform.localScale = Vector3.Lerp( Vector3.zero, Vector3.one, ratio);
            BackToMenuButton.transform.localScale = Vector3.zero;
            ratio -= Time.deltaTime;
            if (ratio <= 0)
            {
                ratio = 0;
            }
        }

        if (ShowOptions)
        {
            OptionsImage.transform.localScale = Vector3.Lerp(Vector3.zero, new Vector3(10, 5, 1), ratio2);
            //BackToMenuButton.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, ratio);
            ratio2 += Time.deltaTime;
            if (ratio2 >= 1)
            {
                OptionsButton.transform.localScale = Vector3.one;
                ratio2 = 1;
            }
        }
        else
        {
            OptionsImage.transform.localScale = Vector3.Lerp(Vector3.zero, new Vector3(10, 5, 1), ratio2);
            // BackToMenuButton.transform.localScale = Vector3.Lerp( Vector3.zero, Vector3.one, ratio);
            OptionsButton.transform.localScale = Vector3.zero;
            ratio2 -= Time.deltaTime;
            if (ratio2 <= 0)
            {
                ratio2 = 0;
            }
        }
    }

}
