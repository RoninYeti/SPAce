using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TriggerRope : MonoBehaviour {
    public float gazeTime = 2f;
    private float timer;
    private bool gazedAt;
    public int pullCount = 0;
    public Animator RopeAnim;

    [SerializeField]
    private TriggerDoor opener;
    
    void Start() { 
    }

    public void OpenSesame() {                        //this was performthrow
        RopeAnim.SetTrigger("RopePull Trigger");
        opener.OpenDoor();
    }
 
    void Update() {
        
    }

    public void PointerEnter() {
        //Debug.Log("Pointer Enter");
        gazedAt = true;

        
    }

    public void PointerExit(){
        //Debug.Log("Pointer Exit");
        gazedAt = false;
    }

    public void PointerDown() {
        //   Debug.Log("Pointer Down");
        if (pullCount == 0)
        {
            OpenSesame();
            pullCount += 1;
        }
    } 
}
