using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
   
    //Pc or mobile?
    public bool phone = true;
  
    //change from pc to mobile
    public void SetPhone()
    {
        phone = !phone;
    }
    //Rigidbody element to avoid the getcomponent
    Rigidbody rb;
    //where do I want to start on the Y?
    float startingY;

    //this is pretty self explanatory
    bool move = true;
    //Debug stuff
    public GameObject text;


	// Use this for initialization
	void Start () {
        //set position
        startingY = GameManager.instance.getPlanetRadius();
        transform.position = new Vector3(transform.position.x, startingY, transform.position.z);
        //set components
        rb = GetComponent<Rigidbody>();
        ////use the gyroscope
        //Input.gyro.enabled = true;
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!move)
            return;
        //Get angles (-1 to 1) from phone rotation
        float angleZ = -Input.acceleration.z;
       
        float angleY = Input.acceleration.y;
        float angleX = Input.acceleration.x;
        float speed = InfoManager.instance.planetRadius * 2 * Mathf.PI / 500.0f;
#if UNITY_EDITOR


        //   if(!phone)
        // {      
        GetComponentInChildren<Animator>().speed = Mathf.Abs(1);
        int horiz = (Input.GetKey(KeyCode.RightArrow) ? 1 : 0) - (Input.GetKey(KeyCode.LeftArrow) ? 1 : 0);
            int vert = (Input.GetKey(KeyCode.UpArrow) ? 1 : 0) - (Input.GetKey(KeyCode.DownArrow) ? 1 : 0);

            Matrix4x4 m = Matrix4x4.TRS(Vector3.zero, transform.rotation, Vector3.one);
            //Rotate
            transform.RotateAround(Vector3.zero, m.GetColumn(1), horiz*2);
            //Move
            transform.RotateAround(Vector3.zero, m.GetColumn(0), vert / speed);

        // }
#elif UNITY_ANDROID
      //  else
      //  {
         GetComponentInChildren<Animator>().speed = Mathf.Abs(angleZ)*2;
            Matrix4x4 m = Matrix4x4.TRS(Vector3.zero, transform.rotation, Vector3.one);
            if ((Mathf.Abs(angleZ) > 0.01f))
            {
                //Move
                transform.RotateAround(Vector3.zero, m.GetColumn(0), (angleZ * 2f - 1f) / speed);
            }
            if ((Mathf.Abs(angleX) > 0.01f))
            {
                //rotate
                transform.RotateAround(Vector3.zero, m.GetColumn(1), (angleX * 2));
            }
    //    }

#else
        int horiz = (Input.GetKey(KeyCode.RightArrow) ? 1 : 0) - (Input.GetKey(KeyCode.LeftArrow) ? 1 : 0);
            int vert = (Input.GetKey(KeyCode.UpArrow) ? 1 : 0) - (Input.GetKey(KeyCode.DownArrow) ? 1 : 0);

            Matrix4x4 m = Matrix4x4.TRS(Vector3.zero, transform.rotation, Vector3.one);
            //Rotate
            transform.RotateAround(Vector3.zero, m.GetColumn(1), horiz*2);
            //Move
            transform.RotateAround(Vector3.zero, m.GetColumn(0), vert / speed);
#endif
        text.GetComponent<Text>().text = "X: " + angleX.ToString() + "\n Y: " + angleY.ToString() + "\n Z: " + angleZ.ToString();
    }

    private void OnEnable()
    {
        GameManager.QuestionTime += AlterPlayerMovement;
    }
    private void OnDisable()
    {
        GameManager.QuestionTime -= AlterPlayerMovement;
    }
    void AlterPlayerMovement()
    {
        move = !move;
    }
   
}
