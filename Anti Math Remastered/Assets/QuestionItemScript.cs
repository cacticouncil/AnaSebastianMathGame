using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionItemScript : MonoBehaviour {

    private void Start()
    {
        transform.localScale = Vector3.zero;
    }
    IEnumerator AppearCorr()
    {
        float ratio = 0;
        transform.localScale = Vector3.zero;
      
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
        
        while (ratio >= -0.1f)
        {
            transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, ratio);
            ratio -= 0.1f;
            yield return new WaitForSeconds(0.01f);
        }
    }

   
   
    public void Appear()
    {
        StartCoroutine(AppearCorr());
    }

    public void Dissappear()
    {
        StartCoroutine(DissappearCorr());
    }
}
