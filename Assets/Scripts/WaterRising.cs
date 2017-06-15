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
    [SerializeField]
    float lerpTime = 3;
    
	void Start ()
    {
        startingPosition = transform.position;
        targetPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        lerpTimer += Time.deltaTime;
        //print(startingPosition + " " + targetPosition + " " + Mathf.Min(lerpTimer / lerpTime, 1));
        transform.position = Vector3.Lerp(startingPosition, targetPosition, Mathf.Min(lerpTimer/lerpTime,1));
	}

    public void RaiseWater()
    {
        startingPosition = targetPosition;
        targetPosition += raiseBy[level++];
        lerpTimer = 0;
    }
}
