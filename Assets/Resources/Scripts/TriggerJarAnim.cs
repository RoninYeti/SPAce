using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SPAce {
    public class TriggerJarAnim : MonoBehaviour {

        public float gazeTime = 2f;
        private float timer;
        private bool gazedAt;
        public Animator jarpouranim;
        public int jarCount = 0;
        public AudioClip jellySplash;
        public AudioSource aSource;

        [SerializeField]
        private float JarAnimationTime = 3;
        private float JarAnimationTimer = Mathf.Infinity;

        [SerializeField]
        private WaterRising water;

        void Start () {
	    }

        public void PerformJarPour() {
            jarpouranim.SetTrigger("JarPour Trigger");
            aSource.PlayOneShot(jellySplash);
            JarAnimationTimer = JarAnimationTime;
        }

        void Update () {
            JarAnimationTimer -= Time.deltaTime;
            if (JarAnimationTimer <= 0) {
                water.RaiseWater();
                JarAnimationTimer = Mathf.Infinity;
            }
        }

        public void PointerDown() {
            if (jarCount == 0) {
                PerformJarPour();
                jarCount += 1;
                Destroy(GetComponent<EventTrigger>());
            }
        } 
    }
}