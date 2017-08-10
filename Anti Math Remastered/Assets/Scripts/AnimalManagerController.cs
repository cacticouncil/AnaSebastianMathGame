using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManagerController : MonoBehaviour {

    uint animaltotal;
    GameObject animal;
	// Use this for initialization
	void Start () {
        animaltotal = GameManager.instance.getAnimalAmount();
        animal = GameManager.instance.getAnimal();
        for (uint i = 0; i < animaltotal; i++)
        {
            Instantiate(animal);
            animal.GetComponent<AnimalController>().SetupAnimals();
            animal.transform.LookAt(Vector3.zero);
            animal.transform.Rotate(-90, 0, 0);
        }
	}
	

}
