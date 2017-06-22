using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SPAce {
    public class TriggerPump : MonoBehaviour {

        static TriggerPump instance;
        public Animator pumpanim;

        void Start () {
            instance = this;
	    }
	
        public static void PerformPump() {
            instance.pumpanim.SetTrigger("Trigger Pump");
        }

	    void Update () {
	    }
    }
}