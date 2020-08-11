using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPerson : MonoBehaviour
{
    public List<GameObject> circlesList;
    public GameObject circle;
    public float time = 0.0f;
    public float WAIT_TIME = 2.0f;
    private int NB_INSTANCES = 4;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i< NB_INSTANCES; i++)
        {
            Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
            float x = Random.Range(-screenBounds.x, screenBounds.x);
            float y = Random.Range(-screenBounds.y, screenBounds.y);
            GameObject instance = Instantiate(circle, new Vector3(x, y, 0), Quaternion.identity);
            circlesList.Add(instance);
        }


    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > WAIT_TIME)
        {
            time -= WAIT_TIME;
            // screenBounds not const in case of resize
            Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
            float x = Random.Range(-screenBounds.x, screenBounds.x);
            float y = Random.Range(-screenBounds.y, screenBounds.y);
            
            GameObject instance = Instantiate(circle, new Vector3(x, y, 0), Quaternion.identity);
            circlesList.Add(instance);
            if (circlesList.Count > NB_INSTANCES)
            {
                Destroy(circlesList[0]);
                circlesList.RemoveAt(0);
            }
        }

    }
}
