using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidScript : MonoBehaviour {

    Vector3 KidPos;
    Matrix4x4 m;
    public void SetupKid()
    {
        transform.rotation = Quaternion.identity;
        KidPos = new Vector3(Random.Range(-10, 11), Random.Range(-10, 11), Random.Range(-10, 11));
        KidPos.Normalize();
        KidPos *= (NewGameManager.instance.getPlanetRadius());
        //set position
        transform.position = KidPos;
        transform.LookAt(Vector3.zero);
        transform.Rotate(-90, 0, 0);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameManager")
        {
            Destroy(this.gameObject);
        }
    }
}
