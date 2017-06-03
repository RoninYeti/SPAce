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
    /*
    public static float LerpTime {
        get {
            return lerpTime;
        }
         set {
            print("Asdf");
            lerpTime = value;
        }
    }
    */
	// Use this for initialization
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

    /*public void GoCoroutine()
    {
        StartCoroutine(WaitForWater());
    }

    IEnumerator WaitForWater()
    {
        yield return new WaitForSeconds(1f);
        print("1");

        yield return new WaitForSeconds(1f);
        print("2");
        RaiseWater();
    }*/

    public void RaiseWater()
    {
        startingPosition = targetPosition;
        targetPosition += raiseBy[level++];
        lerpTimer = 0;
    }
}
