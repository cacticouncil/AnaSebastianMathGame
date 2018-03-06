using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {

    public void PlaySoundEffect()
    {
        GetComponent<AudioSource>().Play();
    }
}
