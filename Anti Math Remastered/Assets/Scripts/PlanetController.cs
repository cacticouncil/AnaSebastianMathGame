using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour {
    public float PlanetGravity;
	// Update is called once per frame
	void Update () {
        
	}

    public void AttractMeDaddy(Transform _player)
    {
        Vector3 deltaPos = (_player.position - transform.position).normalized;
        _player.GetComponent<Rigidbody>().AddForce(deltaPos * PlanetGravity);

    }
}
