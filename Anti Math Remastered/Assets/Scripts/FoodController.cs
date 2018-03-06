using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FoodController : MonoBehaviour {

    bool pressed = false;
    AudioSource As;

    private void Start()
    {
        As = GetComponent<AudioSource>();
    }
    public void SwitchColor()
    {
        pressed = !pressed;
        As.Play();
        if (pressed)
            this.GetComponent<Image>().color = Color.red;
        else
            this.GetComponent<Image>().color = Color.white;
    }
}
