using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantsScript : MonoBehaviour {

    [SerializeField]
    private Transform player;

    private Vector3 PlantPos;
	
    public void SetupPlant(Sprite _plantText)
    {
        transform.rotation = Quaternion.identity;
        PlantPos = new Vector3(Random.Range(-10, 11), Random.Range(-10, 11), Random.Range(-10, 11));
        PlantPos.Normalize();
        PlantPos *= NewGameManager.instance.getPlanetRadius();
        //set position
        transform.position = PlantPos;
        GetComponent<SpriteRenderer>().sprite = _plantText;

        //adjust size
        transform.localScale = new Vector3(Random.Range(0.2f, 1.5f), Random.Range(0.2f, 1.5f), Random.Range(0.2f, 1.5f));
    }
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(player, player.up);
	}
}
