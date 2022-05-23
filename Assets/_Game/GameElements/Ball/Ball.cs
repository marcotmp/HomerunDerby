using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Pitcher pitcher;
    
    public Action OnLandOnHomerun { get; internal set; }
    public bool IsInHitZone { get; internal set; } = true;

    private Vector3 direction;

    private bool isMoving = false;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.isKinematic)
        {
            if (isMoving)
                transform.position += direction * Time.deltaTime;
        }
        else
        {

        }
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

    public void HitBall(Vector3 direction)
    {
        isMoving = false;
        rb.isKinematic = false;
        rb.velocity = direction;
    }

    internal void MoveToHome()
    {
        MoveBy(Vector3.back*3);
    }
}
