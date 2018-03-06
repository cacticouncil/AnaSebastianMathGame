using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewPlayerController : MonoBehaviour {

    private void OnEnable()
    {
        NewGameManager.QuestionTime += StopMoving;
        NewGameManager.QuestionCorrect += ContinueMoving;
        NewGameManager.EndGame += StopMoving;
        NewGameManager.Paused += MuteEngine;
        NewGameManager.UnPaused += UnmuteEngine;
    }
    private void OnDisable()
    {
        NewGameManager.QuestionTime -= StopMoving;
        NewGameManager.QuestionCorrect -= ContinueMoving;
        NewGameManager.EndGame -= StopMoving;
        NewGameManager.Paused -= MuteEngine;
        NewGameManager.UnPaused -= UnmuteEngine;
    }


    [SerializeField]
    bool tutorial = false;
    [SerializeField]
    Slider Slide;

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
        GetComponent<AudioSource>().volume = 0.6f;
    }
    private void Start()
    {
        if (!tutorial)
        {

         transform.position = new Vector3(transform.position.x, NewGameManager.instance.getPlanetRadius(), transform.position.z);
         speed = NewGameManager.instance.getPlanetRadius() * 2 * Mathf.PI / 500.0f;
        }
        else
        {
            transform.position = new Vector3(transform.position.x, 50, transform.position.z);
            speed = 100 * 2 * Mathf.PI / 500.0f;
            Move = true;
        }
        Input.gyro.enabled = true;

        ActualFRWheel = FRWheel.GetComponentInChildren<Transform>();
        ActualFLWheel = FLWheel.GetComponentInChildren<Transform>();
    }

    void MuteEngine()
    {
        GetComponent<AudioSource>().volume = 0;
    }
    void UnmuteEngine()
    {
        GetComponent<AudioSource>().volume = 0.6f;

    }
    private void FixedUpdate()
    {
        if (!Move)
        {
            //update the wheels
            ActualFRWheel.Rotate(Vector3.right* 0);
            ActualFLWheel.Rotate(Vector3.right* 0);
            BRWheel.Rotate(Vector3.right *0);
            BLWheel.Rotate(Vector3.right *0);

            GetComponent<AudioSource>().pitch = 0;
            FLWheel.localEulerAngles = FRWheel.localEulerAngles = new Vector3(0, 0, 0);
            CarBody.localEulerAngles = new Vector3(0, 0, 0);
            return;
        }
        //ratios obtained from the gyroscope
        float angleX = Input.acceleration.x;
        float angleY = Input.acceleration.y;
        float angleZ = -Input.acceleration.z;
        if(Slide != null)
        Slide.value = -angleZ;
        WheelsRotation = Quaternion.identity;

#if UNITY_EDITOR
        /**  //up or down?
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
          transform.RotateAround(Vector3.zero, m.GetColumn(0), vert); **/

        m = Matrix4x4.TRS(Vector3.zero, transform.rotation, Vector3.one);

        GetComponent<AudioSource>().pitch = (StabilizeSpeed((angleZ * 2f - 1f) / speed)+1);
        if ((Mathf.Abs(angleZ) > 0.01f))
        {
            //Move
            transform.RotateAround(Vector3.zero, m.GetColumn(0), StabilizeSpeed((angleZ * 2f - 1f) / speed));

            //update the wheels
            ActualFRWheel.Rotate(Vector3.right * angleZ * speed * 50);
            ActualFLWheel.Rotate(Vector3.right * angleZ * speed * 50);
            BRWheel.Rotate(Vector3.right * (angleZ - 0.5f) * speed * 50);
            BLWheel.Rotate(Vector3.right * (angleZ - 0.5f) * speed * 50);
            if (angleZ >= 0)
            {
                FLWheel.localEulerAngles = FRWheel.localEulerAngles = new Vector3(0, angleX * 45, 0);
                CarBody.localEulerAngles = new Vector3(0, 0, 30 * angleX);
            }

            else
            {
                FLWheel.localEulerAngles = FRWheel.localEulerAngles = new Vector3(0, -angleX * 45, 0);
                CarBody.localEulerAngles = new Vector3(0, 0, 15 * -angleX);
            }
        }
        if ((Mathf.Abs(angleX) > 0.01f))
        {
            //rotate
            transform.RotateAround(Vector3.zero, m.GetColumn(1), (angleX * 2));
        }
#elif UNITY_ANDROID
   m = Matrix4x4.TRS(Vector3.zero, transform.rotation, Vector3.one);


            if ((Mathf.Abs(angleZ) > 0.01f))
            {
            //Move
                transform.RotateAround(Vector3.zero, m.GetColumn(0), StabilizeSpeed( (angleZ * 2f - 1f) / speed) );
             
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

#endif
    }


    float StabilizeSpeed(float _speed)
    {
        float ans = 0;
        if (_speed< 0)
        {
            if (_speed < 0 && _speed >= -0.2f)
            {
                ans = -0.1f;
            }
            if (_speed < -0.2f && _speed >= -0.4f)
            {
                ans = -0.3f;
            }
            if (_speed < -0.4f && _speed >= -0.6f)
            {
                ans = -0.5f;
            }
            if (_speed < -0.6f && _speed >= -0.8f)
            {
                ans = -0.7f;
            }
            if (_speed < -0.8f && _speed >= -1f)
            {
                ans = -0.9f;
            }
        }
        else
        {
            if (_speed > 0 && _speed <= 0.2f)
            {
                ans = 0.1f;
            }
            if (_speed > 0.2f && _speed <= 0.4f)
            {
                ans = 0.3f;
            }
            if (_speed >0.4f && _speed <= 0.6f)
            {
                ans = 0.5f;
            }
            if (_speed > 0.6f && _speed <= 0.8f)
            {
                ans = 0.7f;
            }
            if (_speed > 0.8f && _speed <= 1f)
            {
                ans = 0.9f;
            }
        }

        return ans;
    }
}
