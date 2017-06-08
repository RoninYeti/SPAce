using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

    public Transform position1;
    public Transform position2;
    public float fadeWaitTime = 2f;
    private int PlayerState = 0;
    public AudioClip movementAudio;
    public AudioSource aSource;
    private StateMachineBehaviour stateMacBehavoir;
    private void Awake()
    {
        aSource = GetComponent<AudioSource>();
        
    }

    public void DoorUp()
    {
        //start courotine
    }

    IEnumerator QuickFadeWait()
    {
        //Call fade Steam script
        yield return new WaitForSeconds(fadeWaitTime);
        aSource.PlayOneShot(movementAudio);
        switch (PlayerState)
        {
            case 0:
                {
                    transform.position = position1.position;
                    break;
                }
            case 1:
                {
                    transform.position = position2.position;
                    break;
                }
        }
        yield return new WaitForSeconds(fadeWaitTime);
        //Call fade Steam script
        PlayerState++;

    }

    public void MoveToWater()
    {
        //start coroutine
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
}
