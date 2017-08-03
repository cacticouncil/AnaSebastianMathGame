using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidController : MonoBehaviour {
    [SerializeField]
    float timer = 1f;
    [SerializeField]
    bool moveF = false;
    [SerializeField]
    bool moveB = false;
    [SerializeField]
    bool decreasetimer = false;

    bool play = true;

    public void MoveFoward()
    {
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, transform.position.x + 1, Time.deltaTime), transform.position.y);
       
        moveF = true;
        decreasetimer = true;
    }

    public void MoveBackwards()
    {
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, transform.position.x - 1, Time.deltaTime), transform.position.y);
       
        moveB = true;
        decreasetimer = true;
    }

    private void Update()
    {
        if (!play)
            return;
        if (decreasetimer)
            timer -= Time.deltaTime;
        
        if (timer <= 0f)
        {
            moveF = false;
            moveB = false;
            timer = 1f;
            decreasetimer = false;
        }
        if (moveF && !moveB)
            MoveFoward();
        else if (moveB && !moveF)
            MoveBackwards();
        
        //transform.position = new Vector3(Mathf.Lerp(transform.position.x, transform.position.x + 1, Time.deltaTime), transform.position.y);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "House")
        {
            transform.position = new Vector3(333, 333);
        }
        else if(other.tag == "AntiMath")
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            play = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "House")
        {
            transform.position = new Vector3(333, 333);
        }
        else if (collision.gameObject.tag == "AntiMath")
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            play = false;
        }
    }

}
