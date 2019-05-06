using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMove : MonoBehaviour
{
    public float speed = 5f;
    private bool once = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, transform.position - new Vector3(1, 0, 0), speed * Time.deltaTime);
        if(once && transform.position.x < -40)
        {
            Instantiate(gameObject, new Vector3(40, 0, 0), Quaternion.identity);
            Destroy(gameObject, 4);
            once = false;
        }
    }
}
