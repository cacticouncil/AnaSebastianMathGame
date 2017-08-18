using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour {

    public Material[] mats;
    Material mat;
    MeshRenderer mesh;
    private void Start()
    {
        mat = mats[InfoManager.instance.ID];
        mesh = GetComponent<MeshRenderer>();
        mesh.material = mat;
        //Set the size depending on the desired size
        transform.localScale += new Vector3(GameManager.instance.getPlanetRadius() * 2, GameManager.instance.getPlanetRadius()*2, GameManager.instance.getPlanetRadius() * 2);
    }
}
