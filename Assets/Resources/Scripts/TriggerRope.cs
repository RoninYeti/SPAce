using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SPAce {
    public class TriggerRope : MonoBehaviour {

        public float gazeTime = 2f;
        private float timer;
        private bool gazedAt;
        public int pullCount = 0;
        public Animator RopeAnim;

        [SerializeField]
        private TriggerDoor opener;
    
        void Start() { 
        }

        public void OpenSesame() {
            RopeAnim.SetTrigger("RopePull Trigger");
            opener.OpenDoor();
        }
 
        void Update() {  
        }

        public void PointerDown() {
            if (pullCount == 0) {
                OpenSesame();
                pullCount += 1;
            }
        } 
    }
}