using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SwitchSprite : MonoBehaviour {

    [SerializeField]
    Sprite[] Images;

    public void ChangeSprite(bool UsePlus)
    {
        if (UsePlus)
            GetComponent<Image>().sprite = Images[0];
        else
            GetComponent<Image>().sprite = Images[1];
        

        
    }
}
