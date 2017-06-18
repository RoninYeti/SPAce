using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBathAnim : MonoBehaviour {

    public float gazeTime = 2f;
    private float timer;
    private bool gazedAt;
    public Animator bathanim;
    public int bathCount = 0;
    //public GameObject BathwaterRiser;

    [SerializeField]
    private WaterRising water;

    void Start () {
	}

    public void PerformBathThrow() {
        bathanim.SetTrigger("Bathbomb Trigger");
        water.RaiseWater();
    }

    void Update(){
    }

    public void PointerEnter() {
        //Debug.Log("Pointer Enter");
        gazedAt = true;

        
    }

    public void PointerExit() {
        gazedAt = false;
    }

     public void PointerDown() {
        //Debug.Log("Pointer Down");
        if (bathCount == 0)
        {
            PerformBathThrow();
            bathCount += 1;
        }
    }
}
