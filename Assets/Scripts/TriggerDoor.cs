using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour {
        
    public Animator DoorAnim;
    
	void Start() {
    }
	
	void Update () {    
	}

    public void OpenDoor() {
        DoorAnim.SetTrigger("Door Trigger");
    }   
}
