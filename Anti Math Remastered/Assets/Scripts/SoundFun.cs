using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFun : MonoBehaviour {
    bool play = false;
    private void OnTriggerEnter(Collider other)
    {
        if (play)
        {
            GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
            play = false;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        play = true;
    }
}
