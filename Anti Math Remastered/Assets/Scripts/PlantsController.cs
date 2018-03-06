using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantsController : MonoBehaviour {

    public Transform player;
	
    public void SetupPlants()
    {
        transform.rotation = Quaternion.identity;
        //transform.position = Vector3.zero;
        Vector3 AnimalPos = new Vector3(Random.Range(-10, 11), Random.Range(-10, 11), Random.Range(-10, 11));
        AnimalPos.Normalize();
        AnimalPos *= GameManager.instance.getPlanetRadius();
        //set position
        //startingY = GameManager.instance.getPlanetRadius();
        transform.position = AnimalPos;
        Matrix4x4 m = Matrix4x4.TRS(Vector3.zero, transform.rotation, Vector3.one);
        float angle = Vector3.Angle(transform.position, Vector3.zero);
        //rotate
        transform.RotateAround(Vector3.zero, m.GetColumn(0), angle);
        transform.RotateAround(Vector3.zero, m.GetColumn(1), angle);
    }
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(player, player.up);
	}
}
