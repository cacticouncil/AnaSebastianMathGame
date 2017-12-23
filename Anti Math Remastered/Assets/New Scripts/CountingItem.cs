using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountingItem : MonoBehaviour {


    Animator anim;
    bool pressed = false;
    private void Start()
    {
        anim = GetComponent<Animator>();
        transform.localScale = Vector3.zero;
        GetComponent<Image>().sprite = Resources.Load<Sprite>(NewInfoManager.instance.GetCurrentThingyToLoad().ItemtoCount);
    }
	 IEnumerator AppearCorr()
    {
        float ratio = 0;
        transform.localScale = Vector3.zero;
        anim.SetBool("Tapped", false);
        pressed = false;
        while (ratio <= 1.1f)
        {
            transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, ratio);
            ratio += 0.1f;
            yield return new WaitForSeconds(0.02f);
        }
    }

    IEnumerator DissappearCorr()
    {
        float ratio = 1;
        transform.localScale = Vector3.one;
        anim.SetBool("Tapped", false);
        pressed = false;
        while (ratio >= -0.1f)
        {
            transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, ratio);
            ratio -= 0.1f;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void OhBoyImTapped()
    {
        pressed = !pressed;
        anim.SetBool("Tapped", pressed);
    }
    public void SwitchColor()
    {
        pressed = !pressed;
        
        if (pressed)
            this.GetComponent<Image>().color = Color.red;
        else
            this.GetComponent<Image>().color = Color.white;
    }
    public void Appear()
    {
        StartCoroutine(AppearCorr());
    }

    public void Dissappear()
    {
        StartCoroutine(DissappearCorr());
    }


   // private void Update()
   // {
   //     if (Input.GetKeyDown(KeyCode.W))
   //     {
   //         Appear();
   //     }
   //     else if (Input.GetKeyDown(KeyCode.S))
   //     {
   //         Dissappear();
   //     }
   // }
}
