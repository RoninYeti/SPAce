using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBathAnim : MonoBehaviour {

    // Use this for initialization
    public float gazeTime = 2f;

    private float timer;

    private bool gazedAt;

    public Animator bathanim;

    [SerializeField]
    private WaterRising water;

    //public GameObject BathwaterRiser;

    public int bathCount = 0;

    void Start () {
		
	}

    public void PerformBathThrow()
    {
        bathanim.SetTrigger("Bathbomb Trigger");
        water.RaiseWater();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PointerEnter()
    {
        //Debug.Log("Pointer Enter");
        gazedAt = true;
        if (bathCount == 0)
        {
            PerformBathThrow();
            bathCount += 1;            
        }
        

    }

    public void PointerExit()
    {
        gazedAt = false;
    }
    /*
    public void PointerDown()
    {
        Debug.Log("Pointer Down");
    }*/
}
