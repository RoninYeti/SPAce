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
    [SerializeField]
    private float animationTime = 3;
    private float animationTimer = Mathf.Infinity;

    void Start () {
        
	}

    public void PerformThrow() {
        //StartCoroutine(WaitforGum());
        DialTurnAnim.PerformTurn();
        gumanim.SetTrigger("Gumball Trigger");
        //Debug.Log("this is perform throw working");
        print("Gumball thrown");
        animationTimer = animationTime;
    }

    void Update () {
        animationTimer -= Time.deltaTime;
        if (animationTimer <= 0)
        {
            water.RaiseWater();
            animationTimer = Mathf.Infinity;
        }
    }

    public void PointerEnter() {   
        gazedAt = true;

        
    }

    public void PointerExit() {
        gazedAt = false;
    }

    public void PointerDown() {
        //Debug.Log("Pointer Down");
        if (gumCount == 0)
        {
            
            PerformThrow();
            gumCount += 1;
        }
    }
    /*
    IEnumerator WaitforGum()
    {
        yield return new WaitForSeconds(1000f);
    }
    */
}
