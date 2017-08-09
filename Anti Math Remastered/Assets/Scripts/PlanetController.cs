using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour {

  

    private void Start()
    {


        transform.localScale += new Vector3(GameManager.instance.getPlanetRadius() * 2, GameManager.instance.getPlanetRadius()*2, GameManager.instance.getPlanetRadius() * 2);
    }
}
