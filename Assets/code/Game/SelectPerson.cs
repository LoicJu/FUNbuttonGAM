using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPerson : MonoBehaviour
{

    public List<GameObject> listCircle;
    public GameObject attributes;
    public GameObject attributesPerson;
    private float x_person;
    // Start is called before the first frame update
    void Start()
    {
        listCircle = GameObject.Find("Generation").GetComponent<ShowPerson>().circlesList;
        attributesPerson = Instantiate(attributes, new Vector3(100, 100, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        //timer
        // select person
        GameObject selectedCircle = listCircle[0];
        // generate personage
        // todo change text
        attributesPerson.transform.position = new Vector3(selectedCircle.transform.position.x, selectedCircle.transform.position.y, 0);
    }
}
