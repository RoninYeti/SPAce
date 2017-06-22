using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SPAce {
    public class DialTurnAnim : MonoBehaviour {

        static DialTurnAnim instance;
        public Animator Dialturnanim;

        void Start () {
            instance = this;
	    }
	
        public static void PerformTurn() {
            instance.Dialturnanim.SetTrigger("Turn Trigger");
        }
    
	    void Update () {
	    }
    }
}
