using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRising : MonoBehaviour
{
    
    int level = 0;
    public float fadingTime = 3f;
    [SerializeField]
    Vector3[] raiseBy;
    Vector3 targetPosition;
    Vector3 startingPosition;
    float lerpTimer = 0;
    public delegate void WaterRisingFinishedHandler(int level);
    public event WaterRisingFinishedHandler WaterRisingFinished;
    public GameObject nebular;
    public GameObject steamer;
    
    [SerializeField]
    float lerpTime = 3;

    void Start()
    {
        startingPosition = transform.position;
        targetPosition = transform.position;
        nebular.SetActive(false);
    }

    void Update()
    {
        //If we having finished rising
        if (lerpTimer / lerpTime < 1)
        {
            //Raise the water
            lerpTimer += Time.deltaTime;
            transform.position = Vector3.Lerp(startingPosition, targetPosition, Mathf.Min(lerpTimer / lerpTime, 1));
            //If this is the last frame where the water has been raised, trigger WaterRisingFinished event.
            if (lerpTimer / lerpTime >= 1 && WaterRisingFinished != null)
            {
                WaterRisingFinished(level);
            }
        }

        if (level == 4)
        {

            StartCoroutine(WaitFor());

        }


    }

    IEnumerator WaitFor()
    {
        SteamVR_Fade.Start(Color.black, 1);

        yield return new WaitForSeconds(4f);
        nebular.SetActive(true);
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        DestroyObject(steamer);
        SteamVR_Fade.Start(Color.clear, 1);
        yield return new WaitForSeconds(fadingTime);
        
    }

    public void RaiseWater()
    {
        startingPosition = targetPosition;
        targetPosition += raiseBy[level++];
        lerpTimer = 0;        
    }

    

}