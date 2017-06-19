using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPerfume : MonoBehaviour {

    public float gazeTime = 2f;
    private float timer;
    private bool gazedAt;
    public int gasCount = 0;
    [SerializeField]
    private float GasAnimationTime = 3;
    private float GasAnimationTimer = Mathf.Infinity;

    [SerializeField]
    private WaterRising water;

    void Start () {
        transform.GetChild(2).gameObject.SetActive(false);
    }

    public void PerfumeThrow() {
        TriggerPump.PerformPump();
        transform.GetChild(2).gameObject.SetActive(true);
        //water.RaiseWater();
        GasAnimationTimer = GasAnimationTime;

    }

    void Update()
    {
        GasAnimationTimer -= Time.deltaTime;
        if (GasAnimationTimer <= 0)
        {
            water.RaiseWater();
            GasAnimationTimer = Mathf.Infinity;
        }
    }

    public void PointerEnter() {
        //Debug.Log("Pointer Enter");
        //gazedAt = true;
    }

    public void PointerExit() {
        gazedAt = false;
    }

    public void PointerDown() {
        

        if (gasCount == 0)
        {
            PerfumeThrow();
            gasCount += 1;            
        }
    } 
}