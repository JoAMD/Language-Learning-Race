using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSet : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = GetComponent<Slider>().value;
    }
}
