using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMovement : MonoBehaviour
{
    public Vector2 startPos;
    public Vector2 endPos;
    public float step;
    private float progress;

    void Start()
    {
        transform.position=startPos;
    }

    void FixedUpdate()
    {
        transform.position = Vector2.Lerp(startPos,endPos,progress);
        progress += step;
    }
}
