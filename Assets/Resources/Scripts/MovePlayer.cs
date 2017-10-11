using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SPAce {
    public class MovePlayer : MonoBehaviour {

        public Transform position1;
        public Transform position2;
        public float fadeWaitTime = 2f;
        private int PlayerState = 0;
        public AudioClip movementAudio;
        public AudioClip doorClose;
        public AudioSource aSource;
        private AfterRopePulled stateMacBehavoir;
        public Animator animRef;
        public bool doorOpen = false;
        public GameObject invisWall;
        public GameObject invisWall1;
        public GameObject invisWall2;
        public GameObject invisWall3;
        public Collider waterCol;
    
        private void Awake() {
            aSource = GetComponent<AudioSource>();
            stateMacBehavoir = animRef.GetBehaviour<AfterRopePulled>();
            stateMacBehavoir.movePlayerRef = this;
        }
    
        public void DoorUp() {
            if (doorOpen) { 
                StartCoroutine(QuickFadeWait());
                waterCol.enabled = false;
            }    
        }

        IEnumerator QuickFadeWait() {
            Fade.StartFade(Color.black, 1, 2);
            aSource.PlayOneShot(movementAudio);
            yield return new WaitForSeconds(movementAudio.length);
            switch (PlayerState) {
                case 0: {
                        TriggerCloseAnim.PerformClose();
                        aSource.PlayOneShot(doorClose);
                        transform.position = position1.position;
                        PlayerState++;
                        DestroyInvisWall();
                        break;
                    }
                case 1: {
                        transform.position = position2.position;
                        PlayerState++;
                        ActivateObjects();
                        break;
                    }
            }

            SteamVR_Fade.Start(Color.clear, 2);
            if (!waterCol.enabled && PlayerState == 1) {
                waterCol.enabled = true;
            }
        }

        public void DestroyInvisWall() {
            DestroyObject(invisWall);
            DestroyObject(invisWall3);
        }

        public void ActivateObjects() {
            DestroyObject(invisWall1);
            DestroyObject(invisWall2);
        }

        public void MoveToWater() {
            StartCoroutine(QuickFadeWait());
            waterCol.enabled = false;
        }

        void Update () {  
	    }
    }
}
