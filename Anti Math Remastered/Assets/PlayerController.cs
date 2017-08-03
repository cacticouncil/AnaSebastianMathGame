using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    bool phone = true;
    [SerializeField]
    GameObject text;
    GameObject daddy;

    Vector3 rotL = new Vector3(0, 0, 1);
    Vector3 rotR = new Vector3(0, 0, -1);
    
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        //daddy = new GameObject("Daddy");
        //daddy.transform.position = transform.position;
        //transform.parent = daddy.transform;
        rb = GetComponent<Rigidbody>();
        Input.gyro.enabled = true;
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        // daddy.transform.Rotate(0,0, -Input.gyro.rotationRateUnbiased.z);
        float angleZ = -Input.acceleration.x;
        if (phone && (angleZ > 0.2 || angleZ < -0.2))
        {
             Vector3 rot = new Vector3(0, 0,  angleZ);
            transform.RotateAround(Vector3.zero, rot, Time.deltaTime * 100*Mathf.Abs(angleZ));
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow))
                transform.RotateAround(Vector3.zero, rotL, Time.deltaTime * 100);

            if (Input.GetKey(KeyCode.RightArrow))
                transform.RotateAround(Vector3.zero, rotR, Time.deltaTime * 100);

            // if (Input.GetKeyDown(KeyCode.UpArrow))
            //     rb.AddRelativeForce(0, 500, 0);
        }
        text.GetComponent<Text>().text = angleZ.ToString();

    }
}
