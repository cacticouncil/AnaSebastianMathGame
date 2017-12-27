using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerController : MonoBehaviour {

    private void OnEnable()
    {
        NewGameManager.QuestionTime += StopMoving;
        NewGameManager.QuestionCorrect += ContinueMoving;
    }
    private void OnDisable()
    {
        NewGameManager.QuestionTime -= StopMoving;
        NewGameManager.QuestionCorrect -= ContinueMoving;
    }
    private float speed;
    private Matrix4x4 m;
    private Quaternion WheelsRotation = Quaternion.identity;
    private bool Move = true;
    //car parts. FLWheel is the joint, and the ActualFRWheel is the wheel itself
    [SerializeField]
    Transform FRWheel;
    Transform ActualFRWheel;
    [SerializeField]
    Transform FLWheel;
    Transform ActualFLWheel;
    [SerializeField]
    Transform BRWheel;
    [SerializeField]
    Transform BLWheel;
    [SerializeField]
    Transform CarBody;

    void StopMoving()
    {
        Move = false;
    }
    void ContinueMoving()
    {
        Move = true;
    }
    private void Start()
    {
         transform.position = new Vector3(transform.position.x, NewGameManager.instance.getPlanetRadius(), transform.position.z);
         speed = NewGameManager.instance.getPlanetRadius() * 2 * Mathf.PI / 500.0f;
        Input.gyro.enabled = true;

        ActualFRWheel = FRWheel.GetComponentInChildren<Transform>();
        ActualFLWheel = FLWheel.GetComponentInChildren<Transform>();
    }

    private void FixedUpdate()
    {
        if (!Move)
            return;
        //ratios obtained from the gyroscope
        float angleX = Input.acceleration.x;
        float angleY = Input.acceleration.y;
        float angleZ = -Input.acceleration.z;

        WheelsRotation = Quaternion.identity;

#if UNITY_EDITOR
        //up or down?
        int horiz = (Input.GetKey(KeyCode.RightArrow) ? 1 : 0) - (Input.GetKey(KeyCode.LeftArrow) ? 1 : 0);
        //left or right?
        int vert = (Input.GetKey(KeyCode.UpArrow) ? 1 : 0) - (Input.GetKey(KeyCode.DownArrow) ? 1 : 0);


        //update the wheels
        ActualFRWheel.Rotate(Vector3.right * vert * speed * 50);
        ActualFLWheel.Rotate(Vector3.right * vert * speed * 50);
        BRWheel.Rotate(Vector3.right * vert * speed * 50);
        BLWheel.Rotate(Vector3.right * vert * speed * 50);

      
        FLWheel.localEulerAngles= FRWheel.localEulerAngles = new Vector3(0, 30 * horiz, 0);
        CarBody.localEulerAngles = new Vector3(0, 0,30 * horiz);

        //update Matrix for rotation around the planet
        m = Matrix4x4.TRS(Vector3.zero, transform.rotation, Vector3.one);
        
        //Rotate
        if (vert != 0)
        transform.RotateAround(Vector3.zero, m.GetColumn(1), horiz);
        //Move
        transform.RotateAround(Vector3.zero, m.GetColumn(0), vert);


#elif UNITY_ANDROID
   m = Matrix4x4.TRS(Vector3.zero, transform.rotation, Vector3.one);


            if ((Mathf.Abs(angleZ) > 0.01f))
            {
            //Move
                transform.RotateAround(Vector3.zero, m.GetColumn(0), (angleZ * 2f - 1f) / speed);
             
            //update the wheels
               ActualFRWheel.Rotate(Vector3.right * angleZ * speed * 50);
               ActualFLWheel.Rotate(Vector3.right * angleZ * speed * 50);
               BRWheel.Rotate(Vector3.right * (angleZ-0.5f) * speed * 50);
               BLWheel.Rotate(Vector3.right * (angleZ-0.5f) * speed * 50);
              if(angleZ >= 0)
                {
               FLWheel.localEulerAngles = FRWheel.localEulerAngles = new Vector3(0, angleX *45, 0);
        CarBody.localEulerAngles = new Vector3(0, 0,30 * angleX);
                 }

               else
                {
                 FLWheel.localEulerAngles = FRWheel.localEulerAngles = new Vector3(0, -angleX *45, 0);
                    CarBody.localEulerAngles = new Vector3(0, 0,15 * -angleX);
                 }
            }
            if ((Mathf.Abs(angleX) > 0.01f))
            {
                //rotate
                transform.RotateAround(Vector3.zero, m.GetColumn(1), (angleX * 2));
            }
#else

#endif
    }
}
