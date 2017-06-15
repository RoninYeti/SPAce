using System.Collections;
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
    void Start () {
        
	}

    public void PerformThrow()
    {
        gumanim.SetTrigger("Gumball Trigger");
        
        water.RaiseWater();
        
    }

    // Update is called once per frame
    void Update () {
		if (gazedAt)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
            
        }
	}

    public void PointerEnter()
    {
        //Debug.Log("Pointer Enter");
        gazedAt = true;
        if (gumCount == 0)
        {


            PerformThrow();

            gumCount += 1;
            
        }
    }

    public void PointerExit()
    {
        
        gazedAt = false;
    }

    public void PointerDown()
    {
        Debug.Log("Pointer Down");
    }

}
