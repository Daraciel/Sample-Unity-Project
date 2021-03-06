﻿using System;
using UnityEngine;

public class InputPlayer : MonoBehaviour {

    public bool DebugLines;

    [HideInInspector] public float X_Axis { get; private set; }
    [HideInInspector] public float Y_Axis { get; private set; }
    [HideInInspector] public bool Attack { get; private set; }
    [HideInInspector] public bool Skill1 { get; private set; }
    [HideInInspector] public bool Skill2 { get; private set; }
    [HideInInspector] public bool Inventory { get; private set; }
    [HideInInspector] public bool Interact { get; private set; }
    [HideInInspector] public Vector2 Orientation = Vector2.down;

    // Use this for initialization
    void Start () {
        Attack = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Attack = Input.GetButtonDown("Attack");
        Skill1 = Input.GetButtonDown("Skill1");
        Skill2 = Input.GetButtonDown("Skill2");
        Inventory = Input.GetButtonDown("Inventory");
        Interact = Input.GetButtonDown("Interact");

        X_Axis = Input.GetAxis("X_Axis");
        Y_Axis = Input.GetAxis("Y_Axis");

        updateOrientation();

        if(DebugLines)
        {
            Debug.DrawLine(transform.position, transform.position + (Vector3)Orientation * 3, Color.gray);
        }
    }

    private void updateOrientation()
    {
        if (Input.GetAxisRaw("X_Axis") != 0 || Input.GetAxisRaw("Y_Axis") != 0)
        {
            Orientation.x = X_Axis;
            Orientation.y = Y_Axis;
            Orientation.Normalize();
        }
    }
}
