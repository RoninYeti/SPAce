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
    public GameObject nebular;
    public GameObject steamer;
    public GameObject gumball;
    public GameObject perfume;
    public GameObject jelly;
    public GameObject jar;
    public GameObject bathbomb;
    public GameObject spa;
    public float fadingTime = 3f;
    public AudioClip waterRising;
    public AudioClip victoryNote;
    public AudioClip endSong;
    public AudioSource aSource;

    [SerializeField]
    float lerpTime = 3;

    void Start() {
        startingPosition = transform.position;
        targetPosition = transform.position;
        nebular.SetActive(false);
    }

    void Update() {
        //If we having finished rising
        if (lerpTimer / lerpTime < 1) {
            //Raise the water
            lerpTimer += Time.deltaTime;
            transform.position = Vector3.Lerp(startingPosition, targetPosition, Mathf.Min(lerpTimer / lerpTime, 1));
            //If this is the last frame where the water has been raised, trigger WaterRisingFinished event.
            if (lerpTimer / lerpTime >= 1 && WaterRisingFinished != null) {
                WaterRisingFinished(level);
            }
        }

        if (level == 4) {
            //aSource.PlayOneShot(victoryNote);            Fix This Sound Effect!
            StartCoroutine(WaitFor());
        }
    }

    IEnumerator WaitFor() {
        SteamVR_Fade.Start(Color.black, 1);
        yield return new WaitForSeconds(fadingTime);
        nebular.SetActive(true);
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        DestroyObject(steamer);
        DestroyObject(gumball);
        DestroyObject(perfume);
        DestroyObject(bathbomb);
        DestroyObject(jelly);
        DestroyObject(jar);
        DestroyObject(spa);
        SteamVR_Fade.Start(Color.clear, 2);
        //aSource.PlayOneShot(endSong);                     Fix This Song!!
    }

    public void RaiseWater() {
        startingPosition = targetPosition;
        aSource.PlayOneShot(waterRising);
        targetPosition += raiseBy[level++];
        lerpTimer = 0;        
    }
}