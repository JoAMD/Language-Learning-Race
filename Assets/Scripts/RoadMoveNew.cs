using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMoveNew : MonoBehaviour
{
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, transform.position + new Vector3(1, 0, 0), speed * Time.deltaTime);
        if(transform.position.x > 40)
        {
            Instantiate(gameObject, new Vector3(-30.5f, 7.48f, 0), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
