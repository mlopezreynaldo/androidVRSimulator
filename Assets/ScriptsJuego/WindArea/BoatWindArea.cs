using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatWindArea : MonoBehaviour {
    public bool inWindZone = false;
    public GameObject windZone;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
}