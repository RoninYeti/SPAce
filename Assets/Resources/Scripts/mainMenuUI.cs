using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SPAce {
	public class mainMenuUI : MonoBehaviour {

		void Start () {
		}
		
		void Update () {	
		}

		public void StartGame() {
            Fade.StartFade(Color.black, 1, 2);
            StartCoroutine(QuickFadeWait());
        }

        IEnumerator QuickFadeWait() {
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(1);
            SteamVR_Fade.Start(Color.clear, 2);
        }

        public void EndGame() {
			Application.Quit ();
		}
	}
}