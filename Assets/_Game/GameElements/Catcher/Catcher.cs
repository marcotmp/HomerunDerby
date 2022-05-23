using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catcher : MonoBehaviour
{
    public Ball ball;
    public BoxCollider catcherBoundsCollider;

    public Action OnBallCatched { get; internal set; }

    public bool hasBall { get; private set; } = false;

    private void Update()
    {
        // check if the ball is in hand
        if (!hasBall && catcherBoundsCollider.bounds.Contains(ball.transform.position))
        {
            ball.Stop();
            hasBall = true;
            OnBallCatched?.Invoke();
        }
    }

    internal void ReleaseBall()
    {
        hasBall = false;
    }
}
