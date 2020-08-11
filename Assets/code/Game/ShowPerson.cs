using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPerson : MonoBehaviour
{
    public GameObject circle;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(circle, new Vector3(0.208757f, -0.2164043f, -6.712757f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
