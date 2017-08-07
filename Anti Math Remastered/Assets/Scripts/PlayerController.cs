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

    Vector3 MoveDirection = Vector3.zero;
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
        float angleZ = -Input.acceleration.z;
        float angleY = Input.acceleration.y;
        float angleX = Input.acceleration.x;
        if (phone)
        {
            Matrix4x4 m = Matrix4x4.TRS(Vector3.zero, transform.rotation, Vector3.one);
            if ((Mathf.Abs(angleZ) > 0.01f))
            {
                //Move
                transform.RotateAround(Vector3.zero, m.GetColumn(0), angleZ*2f-1f);
            }
            if ((Mathf.Abs(angleX) > 0.01f))
            {
                //rotate
                transform.RotateAround(Vector3.zero, m.GetColumn(1), angleX);
            }
            //Vector3 rot = new Vector3(angleZ, angleY, angleX);
            //transform.RotateAround(Vector3.zero, rot, Time.deltaTime * 100/* * Mathf.Abs(-angleX)*/);
            //Rotate
            
           

        }
        else
        {

        

            int horiz = (Input.GetKey(KeyCode.RightArrow) ? 1 : 0) - (Input.GetKey(KeyCode.LeftArrow) ? 1 : 0);
            int vert = (Input.GetKey(KeyCode.UpArrow) ? 1 : 0) - (Input.GetKey(KeyCode.DownArrow) ? 1 : 0);

            Matrix4x4 m = Matrix4x4.TRS(Vector3.zero, transform.rotation, Vector3.one);
            //Rotate
            transform.RotateAround(Vector3.zero, m.GetColumn(1), horiz);
            //Move
            transform.RotateAround(Vector3.zero, m.GetColumn(0), vert);

        }
        text.GetComponent<Text>().text = "X: " + angleX.ToString() + "\n Y: " + angleY.ToString() + "\n Z: " + angleZ.ToString();
    }

  
}
