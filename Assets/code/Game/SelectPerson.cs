using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPerson : MonoBehaviour
{

    public List<GameObject> listCircle;
    public GameObject attributes;
    public Button buttonShoot;
    private GameObject selectedCircle;
    private bool hasChanged = false;

    public Camera mainCamera;
    private bool hasBeenClicked = false;
    private int scoreAttributes = 10;
    private int personalScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        // get button
        buttonShoot.onClick.AddListener(TaskOnClick);
        // get list circle
        listCircle = GameObject.Find("Generation").GetComponent<ShowPerson>().circlesList;
        // create attributes
        attributes = Instantiate(attributes, new Vector3(100, 100, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        // test if change person
        if(hasChanged != GameObject.Find("Generation").GetComponent<ShowPerson>().hasChanged)
        {
            // if not click and needed
            if(!hasBeenClicked)
            {
                if (scoreAttributes<0)
                {
                    // bad
                    mainCamera.backgroundColor = Color.red;
                }
                else
                {
                    // good
                    mainCamera.backgroundColor = Color.green;
                }
            }
            hasBeenClicked = false;
            selectedCircle = listCircle[0];
            hasChanged = !hasChanged;
            if(selectedCircle.transform.position.x < 0)
            {
                attributes.transform.position = new Vector3(selectedCircle.transform.position.x + 1.5f, selectedCircle.transform.position.y, 0);
            }
            else
            {
                attributes.transform.position = new Vector3(selectedCircle.transform.position.x - 1.8f, selectedCircle.transform.position.y, 0);
            }
            
        }
        // generate personage

    }

    void TaskOnClick()
    {
        hasBeenClicked = true;
        if (scoreAttributes < 0)
        {
            // good !
            mainCamera.backgroundColor = Color.green;

        }
        else
        {
            // bad !
            mainCamera.backgroundColor = Color.red;
        }
        Destroy(selectedCircle);
    }
}
