using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitcher : MonoBehaviour
{
    public float delayBeforePitching = 2;
    public Transform hand;
    public Action OnReleaseBall { get; internal set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        StartCoroutine(PitchProcess());
    }

    private IEnumerator PitchProcess()
    {
        Debug.Log("PitchProcess wait");
        yield return new WaitForSeconds(delayBeforePitching);
        Debug.Log("PitchProcess pitch");

        // do pitch animation
        //yield return new WaitForSeconds(1);
        Animator_OnReleaseBallFrame();
    }

    public void Animator_OnReleaseBallFrame()
    {
        OnReleaseBall?.Invoke();
    }

    internal void GrabBall(Ball ball)
    {
        ball.transform.position = hand.position;
    }
}
