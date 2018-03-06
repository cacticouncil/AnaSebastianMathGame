using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadingmarker : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<MeshRenderer>().enabled = true;
    }
}
