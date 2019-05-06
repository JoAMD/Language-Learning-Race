using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject data; //Data prefab to instantiate

    // Start is called before the first frame update
    void Awake()
    {
        //Check if a Data prefab has already been assigned to static variable Data.instance or if it's still null
        if (Data.instance == null)
            //Instantiate data prefab
            Instantiate(data);
    }
}
