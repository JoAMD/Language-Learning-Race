using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMove : MonoBehaviour
{
    public GameObject car;
    public Canvas canvas;
    private Vector3 offset = new Vector3(-65f, 70f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name.EndsWith("Yellow"))
        {
            offset = new Vector3(-135f, 20.5f, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = worldToUISpace(canvas, car.transform.position) + offset;
    }

    public Vector3 worldToUISpace(Canvas parentCanvas, Vector3 worldPos)
    {
        //Convert the world for screen point so that it can be used with ScreenPointToLocalPointInRectangle function
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        Vector2 movePos;

        //Convert the screenpoint to ui rectangle local point
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvas.transform as RectTransform, screenPos, parentCanvas.worldCamera, out movePos);
        //Convert the local point to world point
        return parentCanvas.transform.TransformPoint(movePos);
    }

}
