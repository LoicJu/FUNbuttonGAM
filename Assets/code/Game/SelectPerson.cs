using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectPerson : MonoBehaviour
{

    public List<GameObject> listCircle;
    public TextMeshPro attributes;
    public Button buttonShoot;
    private GameObject selectedCircle;
    private bool hasChanged = false;

    public Camera mainCamera;
    private bool hasBeenClicked = false;
    private int scoreAttributes = 0;
    public int personalScore = 3;
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
                    personalScore--;
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

            GameObject.Find("Generation").GetComponent<generation>().generationPerdue();
            string atts = GameObject.Find("Generation").GetComponent<generation>().prenom + GameObject.Find("Generation").GetComponent<generation>().sexualite;
            attributes.GetComponent<TMPro.TextMeshPro>().SetText(atts);
            scoreAttributes = GameObject.Find("Generation").GetComponent<generation>().scorePerso;

            if (selectedCircle.transform.position.x < 0)
            {
                attributes.transform.position = new Vector3(selectedCircle.transform.position.x + 1.5f, selectedCircle.transform.position.y, 0);
            }
            else
            {
                attributes.transform.position = new Vector3(selectedCircle.transform.position.x - 1.8f, selectedCircle.transform.position.y, 0);
            }


        }
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
            personalScore--;
        }
        Destroy(selectedCircle);
    }
}
