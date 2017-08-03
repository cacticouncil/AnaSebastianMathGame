using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour {
    GameObject daddy;
	// Use this for initialization
	void Start () {
        daddy = new GameObject("Daddy");
        daddy.transform.position = transform.position;
        transform.parent = daddy.transform;
        Input.gyro.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        daddy.transform.Rotate(0, -Input.gyro.rotationRateUnbiased.y, 0);
        transform.Rotate(-Input.gyro.rotationRateUnbiased.x, 0, 0);
	}
}
