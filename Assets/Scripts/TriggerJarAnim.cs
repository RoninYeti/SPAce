using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerJarAnim : MonoBehaviour {

    public float gazeTime = 2f;
    private float timer;
    private bool gazedAt;
    public Animator jarpouranim;
    public int jarCount = 0;
    [SerializeField]
    private float JarAnimationTime = 3;
    private float JarAnimationTimer = Mathf.Infinity;

    [SerializeField]
    private WaterRising water;

    void Start () {
	}

    public void PerformJarPour() {
        jarpouranim.SetTrigger("JarPour Trigger");
        //water.RaiseWater();
        JarAnimationTimer = JarAnimationTime;
    }

    void Update ()
    {
        JarAnimationTimer -= Time.deltaTime;
        if (JarAnimationTimer <= 0)
        {
            water.RaiseWater();
            JarAnimationTimer = Mathf.Infinity;
        }
    }

    public void PointerEnter() {
        //Debug.Log("Pointer Enter");
        gazedAt = true;
        
        
    }

    public void PointerExit() {
        //Debug.Log("Pointer Exit");
        gazedAt = false;
    }

    public void PointerDown() {
        //Debug.Log("Pointer Down");
        if (jarCount == 0)
        {
            PerformJarPour();
            jarCount += 1;            
        }
    } 
}

