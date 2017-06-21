using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour {
        
    public Animator DoorAnim;
    public AudioClip doorOpen;
    public AudioSource aSource;

    void Start() {
    }
	
	void Update () {    
	}

    public void OpenDoor() {
        aSource.PlayOneShot(doorOpen);
        DoorAnim.SetTrigger("Door Trigger");
    }   
}
