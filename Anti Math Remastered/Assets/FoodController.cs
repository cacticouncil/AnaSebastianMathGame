using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FoodController : MonoBehaviour {

    bool pressed = false;

    public void SwitchColor()
    {
        pressed = !pressed;

        if (pressed)
            this.GetComponent<Image>().color = Color.red;
        else
            this.GetComponent<Image>().color = Color.white;
    }
}
