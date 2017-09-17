using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SPAce {
    public class TriggerBathAnim : MonoBehaviour {

        public float gazeTime = 2f;
        private float timer;
        private bool gazedAt;
        public Animator bathanim;
        public int bathCount = 0;
        public AudioClip bombSplash;
        public AudioSource aSource;

        [SerializeField]
        private float BathAnimationTime = 3;
        private float BathAnimationTimer = Mathf.Infinity;

        [SerializeField]
        private WaterRising water;

        void Start () {
	    }

        public void PerformBathThrow() {
            bathanim.SetTrigger("Bathbomb Trigger");
            BathAnimationTimer = BathAnimationTime;
            aSource.PlayOneShot(bombSplash);
        }

        void Update() {
            BathAnimationTimer -= Time.deltaTime;
            if (BathAnimationTimer <= 0) {
                water.RaiseWater();
                BathAnimationTimer = Mathf.Infinity;
            }
        }

        /* public void PointerEnter() {
            gazedAt = true;
        }

        public void PointerExit() {
            gazedAt = false;
        } */

         public void PointerDown() {
            if (bathCount == 0) {
                PerformBathThrow();
                bathCount += 1;
                Destroy(GetComponent<EventTrigger>());
            }
        }
    }
}
