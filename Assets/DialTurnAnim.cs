using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialTurnAnim : MonoBehaviour {

    static DialTurnAnim instance;
    
    public Animator Dialturnanim;

    void Start () {
        instance = this;
	}
	
    public static void PerformTurn()
    {
        instance.Dialturnanim.SetTrigger("Turn Trigger");
        //Debug.Log("yuiop");
    }
    
	// Update is called once per frame
	void Update () {
	
	}
}
