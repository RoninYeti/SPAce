using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCloseAnim : MonoBehaviour {

    static TriggerCloseAnim instance;
    public Animator closeanim;

    void Start () {
        instance = this;
	}
	
    public static void PerformClose() {
        instance.closeanim.SetTrigger("Door Close Trigger");
    }
	
	void Update () {
	}
}
