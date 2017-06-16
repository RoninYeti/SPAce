﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

    public Transform position1;
    public Transform position2;
    public float fadeWaitTime = 2f;
    private int PlayerState = 0;
    public AudioClip movementAudio;
    public AudioSource aSource;
    private AfterRopePulled stateMacBehavoir;
    public Animator animRef;
    public bool doorOpen = false;
    public GameObject invisWall;
    public GameObject invisWall1;
    public GameObject invisWall2;
    public Collider waterCol;

    private void Awake()
    {
        aSource = GetComponent<AudioSource>();

            stateMacBehavoir = animRef.GetBehaviour<AfterRopePulled>();
            stateMacBehavoir.movePlayerRef = this;
    }
    
    public void DoorUp()
    {
        if (doorOpen)
        { 
            StartCoroutine(QuickFadeWait());
            waterCol.enabled = false;
        }    
    }

    IEnumerator QuickFadeWait()
    {
     //   print(PlayerState);
        SteamVR_Fade.Start(Color.black, 1);
        yield return new WaitForSeconds(fadeWaitTime);
        // aSource.PlayOneShot(movementAudio);
        switch (PlayerState)
        {
            case 0:
                {
                    transform.position = position1.position;
                    PlayerState++;
                    TriggerCloseAnim.PerformClose();
                    DestroyInvisWall();
                    break;
                }
            case 1:
                {
                    transform.position = position2.position;
                    PlayerState++;
                    ActivateObjects();
                    break;
                }
        }
        yield return new WaitForSeconds(fadeWaitTime);
        // yield return new WaitForSeconds(movementAudio.length);
        SteamVR_Fade.Start(Color.clear, 1);
       
        if (!waterCol.enabled && PlayerState == 1)
        {
            waterCol.enabled = true;
        }
      
        //    print(PlayerState);
    }

    public void DestroyInvisWall()
    {
        DestroyObject(invisWall);
    }

    public void ActivateObjects()
    {
        DestroyObject(invisWall1);
        DestroyObject(invisWall2);
    }

    public void MoveToWater()
    {
        StartCoroutine(QuickFadeWait());
        waterCol.enabled = false;
    }
    
	// Update is called once per frame
	void Update () {		
	}
}
