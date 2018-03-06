using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, transform.position.x + 1, Time.deltaTime/5), transform.position.y);
    }
}
