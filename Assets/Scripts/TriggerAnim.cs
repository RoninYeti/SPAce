﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TriggerAnim : MonoBehaviour
{
    public float gazeTime = 2f;
    private float timer;
    private bool gazedAt;
    public int gumCount = 0;
    public Animator gumanim;
    [SerializeField]
    private WaterRising water;
    [SerializeField]
    private float GumAnimationTime = 3; //change this one variable to affect the seconds it takes before water starts rising after animation
    private float GumAnimationTimer = Mathf.Infinity;

    void Start () {
        
	}

    public void PerformThrow() {
        DialTurnAnim.PerformTurn();
        gumanim.SetTrigger("Gumball Trigger");        
        GumAnimationTimer = GumAnimationTime;
    }

    void Update () {
        GumAnimationTimer -= Time.deltaTime;
        if (GumAnimationTimer <= 0)
        {
            water.RaiseWater();
            GumAnimationTimer = Mathf.Infinity;
        }
    }

    public void PointerEnter() {   
        gazedAt = true;        
    }

    public void PointerExit() {
        gazedAt = false;
    }

    public void PointerDown() {
        //Debug.Log("Pointer Down");
        if (gumCount == 0)
        {
            
            PerformThrow();
            gumCount += 1;            
        }
    }
    
}
