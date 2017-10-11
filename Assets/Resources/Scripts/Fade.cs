using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace SPAce
{
    public class Fade : MonoBehaviour
    {
        private static Fade singleton;
        [SerializeField]
        private Image panel;
        private void Start()
        {
            singleton = this;
        }
        private float fadeInTimer;
        private float fadeOutTimer;
        private float durationTimer;
        private float transitionTimer;
        private bool transitioning;

        public static void StartFade(Color color, float transitionTime, float durationTime) {
            singleton.StartFadeInstance(color, transitionTime, durationTime);
        }

        private void StartFadeInstance(Color color, float transitionTime, float durationTime)
        {
            fadeInTimer = transitionTime;
            fadeOutTimer = transitionTime;
            transitionTimer = transitionTime;
            durationTimer = durationTime;
            transitioning = true;
        }

        private void Update()
        {
            if (transitioning)
            {
                //Fade in
                if (fadeInTimer > 0)
                {
                    fadeInTimer -= Time.deltaTime;
                    panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 1-fadeInTimer / transitionTimer);
                }
                else
                {
                    //Sustain
                    if (durationTimer > 0)
                    {
                        panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 1);
                        durationTimer -= Time.deltaTime;
                    }
                    else
                    {
                        //Fade out
                        if (fadeOutTimer > 0)
                        {
                            fadeOutTimer -= Time.deltaTime;
                            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, fadeOutTimer / transitionTimer);
                        }
                        else
                        //Return
                        {
                            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, 0);
                            transitioning = false;
                        }
                    }
                }
            }
        }
    }
}
