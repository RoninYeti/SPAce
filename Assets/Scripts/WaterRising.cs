using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRising : MonoBehaviour {
    int level = 0;
    [SerializeField]
    Vector3[] raiseBy;
    Vector3 targetPosition;
    Vector3 startingPosition;
    float lerpTimer = 0;
    public delegate void WaterRisingFinishedHandler(int level);
    public event WaterRisingFinishedHandler WaterRisingFinished;

    [SerializeField]
    float lerpTime = 3;
    
	void Start () {
        startingPosition = transform.position;
        targetPosition = transform.position;
	}
	
	void Update () {
        //If we having finished rising
        if (lerpTimer / lerpTime < 1)
        {
            //Raise the water
            lerpTimer += Time.deltaTime;
            transform.position = Vector3.Lerp(startingPosition, targetPosition, Mathf.Min(lerpTimer / lerpTime, 1));
            //If this is the last frame where the water has been raised, trigger WaterRisingFinished event.
            if (lerpTimer / lerpTime >= 1 && WaterRisingFinished != null) {
                WaterRisingFinished(level);
            }
        }
	}

    public void RaiseWater() {
        startingPosition = targetPosition;
        targetPosition += raiseBy[level++];
        lerpTimer = 0;
    }
}
