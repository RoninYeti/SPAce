using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerJarAnim : MonoBehaviour {

    // Use this for initialization

    public float gazeTime = 2f;

    private float timer;

    private bool gazedAt;

    public Animator jarpouranim;

    [SerializeField]
    private WaterRising water;

    //public GameObject JarwaterRiser;

    public int jarCount = 0;

    void Start () {
		
	}

    public void PerformJarPour()
    {
        jarpouranim.SetTrigger("JarPour Trigger");
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
        
        if (jarCount == 0)
        {


            PerformJarPour();

            jarCount += 1;
            //JarwaterRiser.GetComponent<UnityStandardAssets.Water.Water>().waterlevel += 1;
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

