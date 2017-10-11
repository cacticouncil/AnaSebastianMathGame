using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkylineController : MonoBehaviour {
    
    
    //where do I want to start on the Y?
    float startingY;

    //this is pretty self explanatory
    bool move = true;



    // Use this for initialization
    void Start()
    {
        //set position
       // startingY = GameManager.instance.getPlanetRadius();
       // transform.position = new Vector3(transform.position.x, startingY, transform.position.z);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!move)
            return;
        //Get angles (-1 to 1) from phone rotation
        float angleZ = -Input.acceleration.z;
        float angleY = Input.acceleration.y;
        float angleX = Input.acceleration.x;
        float speed = InfoManager.instance.planetRadius * 2 * Mathf.PI / 500.0f;
#if UNITY_EDITOR

        int horiz = (Input.GetKey(KeyCode.RightArrow) ? 1 : 0) - (Input.GetKey(KeyCode.LeftArrow) ? 1 : 0);
        int vert = (Input.GetKey(KeyCode.UpArrow) ? 1 : 0) - (Input.GetKey(KeyCode.DownArrow) ? 1 : 0);

        Matrix4x4 m = Matrix4x4.TRS(Vector3.zero, transform.rotation, Vector3.one);
        //Rotate
        transform.RotateAround(Vector3.zero, m.GetColumn(1), 0 - GameManager.instance.Joystic.GetComponentInChildren<WheelController>().getX() * 0.05f* GameManager.instance.Joystic.GetComponentInChildren<WheelController>().GetSpeed());
        //Move
        // transform.RotateAround(Vector3.zero, m.GetColumn(0), vert / speed);


#elif UNITY_ANDROID
            Matrix4x4 m = Matrix4x4.TRS(Vector3.zero, transform.rotation, Vector3.one);
        if (InfoManager.instance.Gyroscope)
        {
            if ((Mathf.Abs(angleX) > 0.01f))
            {
                //rotate
                transform.RotateAround(Vector3.zero, m.GetColumn(1), (-angleX * 0.05f));
            }
        }
        else
        {
            if ((Mathf.Abs(angleX) > 0.01f))
            {
                //rotate
                transform.RotateAround(Vector3.zero, m.GetColumn(1), (-GameManager.instance.Joystic.GetComponent<WheelController>().getX() * 0.05f* GameManager.instance.Joystic.GetComponentInChildren<WheelController>().GetSpeed()));
            }
        }
            

#else
        int horiz = (Input.GetKey(KeyCode.RightArrow) ? 1 : 0) - (Input.GetKey(KeyCode.LeftArrow) ? 1 : 0);
            int vert = (Input.GetKey(KeyCode.UpArrow) ? 1 : 0) - (Input.GetKey(KeyCode.DownArrow) ? 1 : 0);

            Matrix4x4 m = Matrix4x4.TRS(Vector3.zero, transform.rotation, Vector3.one);
            //Rotate
            transform.RotateAround(Vector3.zero, m.GetColumn(1), horiz*2);
            //Move
           // transform.RotateAround(Vector3.zero, m.GetColumn(0), vert / speed);
#endif

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
