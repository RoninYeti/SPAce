using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SPAce {
    public class WaterRising : MonoBehaviour {

        int level = 0;

        [SerializeField]
        Vector3[] raiseBy;
        Vector3 targetPosition;
        Vector3 startingPosition;
        float lerpTimer = 0;
        public delegate void WaterRisingFinishedHandler(int level);
        public event WaterRisingFinishedHandler WaterRisingFinished;
        public GameObject nebular1;
        public GameObject nebular2;
        public GameObject comet;

        [SerializeField]
        private GameObject[] objectsToDestroy;

        public float fadingTime = 3f;
        public AudioSource aSource;
        public AudioClip waterRising;
        public AudioClip victoryNote;
        public GameObject EndGameUI;

        bool Ending;

        [SerializeField]
        float lerpTime = 3;

        void Start() {
            startingPosition = transform.position;
            targetPosition = transform.position;
            nebular1.SetActive(false);
            nebular2.SetActive(false);
            comet.SetActive(false);
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

            if (level == 4 && !Ending) {
                Ending = true;
                aSource.Stop();
                aSource.PlayOneShot(victoryNote);   
                StartCoroutine(WaitFor());
            }
        }

        IEnumerator WaitFor() {
            yield return new WaitForSeconds(2f);
            Fade.StartFade(Color.black, 1, 2);
            yield return new WaitForSeconds(fadingTime);
            nebular1.SetActive(true);
            nebular2.SetActive(true);
            comet.SetActive(true);
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;

            foreach (GameObject obj in objectsToDestroy) {
                Destroy(obj);
            }

            yield return new WaitForSeconds(16f);
            EndGameUI.SetActive(true);
        }

        public void RaiseWater() {
            startingPosition = targetPosition;
            aSource.PlayOneShot(waterRising);
            targetPosition += raiseBy[level++];
            lerpTimer = 0;        
        }
    }
}