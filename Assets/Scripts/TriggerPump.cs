using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPump : MonoBehaviour {

    static TriggerPump instance;

    public Animator pumpanim;

    void Start () {
        instance = this;
	}
	
    public static void PerformPump()
    {
        instance.pumpanim.SetTrigger("Trigger Pump");
        //Debug.Log("pump should be working");
    }

	// Update is called once per frame
	void Update () {
		
	}
}
