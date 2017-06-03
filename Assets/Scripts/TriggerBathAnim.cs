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
        if (bathCount == 0)
        {


            PerformBathThrow();

            bathCount += 1;
            //BathwaterRiser.GetComponent<UnityStandardAssets.Water.Water>().waterlevel += 1;
        }
        

    }

    public void PointerExit()
    {
        //Debug.Log("Pointer Exit");
        gazedAt = false;
    }

    public void PointerDown()
    {
        Debug.Log("Pointer Down");
    }
}
