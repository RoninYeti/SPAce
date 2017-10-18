using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SPAce {
	public class mainMenuUI : MonoBehaviour {

        public AudioSource aSource;
        public AudioClip buttonPress;
        public GameObject buttonSparkPlay;
        public GameObject buttonSparkExit;

        void Start () {
		}
		
		void Update () {	
		}

		public void StartGame() {
            buttonSparkPlay.SetActive(true);
            aSource.PlayOneShot(buttonPress);
            StartCoroutine(QuickFadeWait());
        }

        IEnumerator QuickFadeWait() {
            //Instantiate(buttonSpark, transform.position, transform.rotation);
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(1);
        }

        public void EndGame() {
            buttonSparkExit.SetActive(true);
            aSource.PlayOneShot(buttonPress);
            Application.Quit ();
		}
	}
}