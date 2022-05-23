using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batter : MonoBehaviour
{
    public Transform bat;
    public Transform batIdlePosition;
    public Transform batHitPosition;

    public Action OnBatSwang { get; internal set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void Activate()
    {
    }

    internal void Deactivate()
    {
    }
}
