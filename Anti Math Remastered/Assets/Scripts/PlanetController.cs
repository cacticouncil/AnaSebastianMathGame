using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour {

  

    private void Start()
    {
        //Set the size depending on the desired size
        transform.localScale += new Vector3(GameManager.instance.getPlanetRadius() * 2, GameManager.instance.getPlanetRadius()*2, GameManager.instance.getPlanetRadius() * 2);
    }
}
