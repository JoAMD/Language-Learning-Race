using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove1 : MonoBehaviour
{
    private float speed = 0f;
    public float startTime = -200f;
    public bool first = true;
    private float timeElapsed = 0f;
    public RoadMoveNew1[] roads;
    public float roadInitialSpeed = 0;

    public void moveFront()
    {
            transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(-1, 0, 0), speed * Time.deltaTime);
    }

    private void Update()
    {
        timeElapsed = Time.time - startTime;
        if (timeElapsed < 1.5f)
        {

            for (int i = 0; i < roads.Length; i++)
            {
                roads[i].speed = roadInitialSpeed + ((5f / 1.5f) * timeElapsed);
            }
            timeElapsed = Time.time - startTime;
            /*
            transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(-1, 0, 0), speed * Time.deltaTime);
            if (timeElapsed <= 0.25f)
            {
                speed = 20f * timeElapsed;
            }
            else if (5f - timeElapsed <= 3.5f)
            {
                if (first)
                {
                    roadInitialSpeed = roads[0].speed;
                    first = false;
                }
                for (int i = 0; i < roads.Length; i++)
                {
                    roads[i].speed = roadInitialSpeed + ((5f / 3.5f) * (timeElapsed - 1.5f));
                }
                speed = 5f / 3.5f * (5f - timeElapsed);
                /*if(Mathf.Approximately(10f*(5f - timeElapsed), 35f))
                {
                    Debug.Log("in");
                    first = true;
                    timeElapsed = 1.4f;
                }
            }
            else
            {
                first = true;
            }
        */
        }
    }
}
