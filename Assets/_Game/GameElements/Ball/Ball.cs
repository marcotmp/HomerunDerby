using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Pitcher pitcher;
    
    public Action OnLandOnHomerun { get; internal set; }
    public bool IsInHitZone { get; internal set; }

    private Vector3 direction;

    private bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
            transform.position += direction * Time.deltaTime;
    }

    internal void Stop()
    {
        isMoving = false;
    }

    internal void MoveBy(Vector3 direction)
    {
        isMoving = true;
        this.direction = direction;
    }

    internal void MoveToHome()
    {
        MoveBy(Vector3.back*3);
    }
}
