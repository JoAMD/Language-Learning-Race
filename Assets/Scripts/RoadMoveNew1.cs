using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMoveNew1 : MonoBehaviour
{
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(1, 0, 0), speed * Time.deltaTime);
        if (transform.position.x > 60)
        {
            transform.position = new Vector3(-60, transform.position.y, transform.position.z);
        }
    }
}
