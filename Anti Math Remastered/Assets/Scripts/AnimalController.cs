using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour {

    Vector3 AnimalPos;
    public static int AnimalCount = 0;
    public uint AnimalID;
    public void SetupAnimals(uint ID)
    {
        AnimalID = ID;
        transform.rotation = Quaternion.identity;
        //transform.position = Vector3.zero;
        AnimalPos = new Vector3(Random.Range(-10, 11), Random.Range(-10, 11), Random.Range(-10, 11));
        AnimalPos.Normalize();
        AnimalPos *= (GameManager.instance.getPlanetRadius() - 2.5f);
        //set position
        //startingY = GameManager.instance.getPlanetRadius();
        transform.position = AnimalPos;
        Matrix4x4 m = Matrix4x4.TRS(Vector3.zero, transform.rotation, Vector3.one);
        float angle = Vector3.Angle( transform.position, Vector3.zero);
        //rotate
        transform.RotateAround(Vector3.zero, m.GetColumn(0), angle);
        transform.RotateAround(Vector3.zero, m.GetColumn(1), angle);
    }
  
}
