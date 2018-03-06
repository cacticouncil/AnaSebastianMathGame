using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookMark : MonoBehaviour {

    Animator Daddy;
   
    Animation PG1Move;
    
    static bool isPlaying = false;
    private void Start()
    {
        Daddy = GetComponentInParent<Animator>();
        PG1Move = GetComponent<Animation>();
    }

    public void TurnPage(bool OpenOrClose, bool multiplepages = false)
    {
        if (!PG1Move.isPlaying)
        {
        Stuff(OpenOrClose);
        }
        //Daddy.SetBool("Turn Page", OpenOrClose);
        
    }

    void Stuff(bool OpenOrClose)
    {
      
            isPlaying = true;
            Daddy.SetBool("Turn Page", OpenOrClose);
            //StartCoroutine(Timer());
        
       
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        print("Shrek2");
        isPlaying = false;
    }
}
