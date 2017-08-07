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
    Vector3 rotU = new Vector3(1, 0, 0);
    Vector3 rotD = new Vector3(-1, 0, 0);

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
        float angleZ = Input.acceleration.z;
        float angleY = Input.acceleration.y;
        float angleX = Input.acceleration.x;
        if (phone && (-angleX > 0.1 || -angleX < -0.1))
        {
            Vector3 rot = new Vector3(0, 0,  -angleX);
            transform.RotateAround(Vector3.zero, rot, Time.deltaTime * 100*Mathf.Abs(-angleX));
        }
        else
        {

           // Vector3 rot = new Vector3(0, 0, angleX);
           // transform.RotateAround(Vector3.zero, rot, Time.deltaTime * 50 * Mathf.Abs(angleX));
            if (Input.GetKey(KeyCode.LeftArrow))
                transform.Rotate(new Vector3(0,1,0), Time.deltaTime * 100);
            
            if (Input.GetKey(KeyCode.RightArrow))
                transform.Rotate(new Vector3(0, -1, 0), Time.deltaTime * 100);
            if (Input.GetKey(KeyCode.UpArrow))
                transform.RotateAround(Vector3.zero, rotU, Time.deltaTime * 100);

            if (Input.GetKey(KeyCode.DownArrow))
                transform.RotateAround(Vector3.zero, rotD, Time.deltaTime * 100);

        }
        text.GetComponent<Text>().text = "X: " +angleX.ToString()+ " Y: " + angleY.ToString()+ " Z: " + angleZ.ToString();

    }
}
