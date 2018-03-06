using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempphoto : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.LookAt(Camera.main.transform);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x+25,transform.eulerAngles.y+180,transform.eulerAngles.z);
	}
	
	
}
