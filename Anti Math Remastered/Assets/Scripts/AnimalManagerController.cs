using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnimalManagerController : MonoBehaviour {

    uint animaltotal;
    GameObject animal;
    public GameObject plant;
    public Text DonkeyAmount;
    [HideInInspector]
    public  List<GameObject> Animals = new List<GameObject>();
    // Use this for initialization
    void Start () {
        AnimalController.AnimalCount = 0;
        animaltotal = GameManager.instance.getAnimalAmount();
        animal = GameManager.instance.getAnimal();
        for (uint i = 0; i < animaltotal; i++)
        {
            GameObject temp = Instantiate(animal);
            temp.GetComponent<AnimalController>().SetupAnimals(i);
            temp.transform.LookAt(Vector3.zero);
            temp.transform.Rotate(-90, 0, 0);
            AnimalController.AnimalCount++;
            Animals.Add(temp);
        }

        for (int i = 0; i < 200; i++)
        {
            GameObject temp = Instantiate(plant);
            temp.GetComponent<PlantsController>().SetupPlants();
            temp.GetComponent<SpriteRenderer>().sprite = GameManager.instance.Plants[Random.Range(0,44)];
            temp.transform.LookAt(Vector3.zero);
            temp.transform.Rotate(-90, 0, 0);
        }
        DonkeyAmount.text = "Targets remaining:" + AnimalController.AnimalCount;
    }

    private void Update()
    {
        float u = Time.deltaTime;
    }

}


