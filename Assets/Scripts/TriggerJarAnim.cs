using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerJarAnim : MonoBehaviour {

    public float gazeTime = 2f;
    private float timer;
    private bool gazedAt;
    public Animator jarpouranim;
    public int jarCount = 0;
    //public GameObject JarwaterRiser;

    [SerializeField]
    private WaterRising water;

    void Start () {
	}

    public void PerformJarPour() {
        jarpouranim.SetTrigger("JarPour Trigger");
        water.RaiseWater();
    }

    void Update () {        
    }

    public void PointerEnter() {
        //Debug.Log("Pointer Enter");
        gazedAt = true;
        
        if (jarCount == 0)
        {            
            PerformJarPour();
            jarCount += 1;
            //JarwaterRiser.GetComponent<UnityStandardAssets.Water.Water>().waterlevel += 1;
        }
    }

    public void PointerExit() {
        //Debug.Log("Pointer Exit");
        gazedAt = false;
    }

    /* public void PointerDown() {
        //Debug.Log("Pointer Down");
    } */
}

