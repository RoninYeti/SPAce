using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPerfume : MonoBehaviour {

    public float gazeTime = 2f;
    private float timer;
    private bool gazedAt;
    public int gasCount = 0;

    [SerializeField]
    private WaterRising water;

    void Start () {
        transform.GetChild(2).gameObject.SetActive(false);
    }

    public void PerfumeThrow() {
        TriggerPump.PerformPump();
        transform.GetChild(2).gameObject.SetActive(true);
        water.RaiseWater();

    }

    void Update() {
    }

    public void PointerEnter() {
        //Debug.Log("Pointer Enter");
        gazedAt = true;

        if (gasCount == 0)
        {
            PerfumeThrow();
            gasCount += 1;
        }
    }

    public void PointerExit() {
        gazedAt = false;
    }

    /* public void PointerDown() {
        //Debug.Log("Pointer Down");
    } */
}