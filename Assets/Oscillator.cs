﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]

public class Oscillator : MonoBehaviour {

    [SerializeField] Vector3 movementVector = new Vector3(0f, 10f, 0f);
    [SerializeField] float period = 2f;

    float movementFactor;
    Vector3 startingPos;

	// Use this for initialization
	void Start () {
        startingPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (period <= Mathf.Epsilon) return;
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2f;
        float rawSinWave = Mathf.Sin(cycles * tau);
        movementFactor = rawSinWave / 2;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
	}
}