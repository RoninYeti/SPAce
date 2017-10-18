using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SPAce {
	public class InGameUI : MonoBehaviour {

		public float timeToWait=8f;

        void OnEnable() {
            StartCoroutine(GotoFirstScene());
		}

		IEnumerator GotoFirstScene() {
			yield return new WaitForSeconds(timeToWait);
            Fade.StartFade(Color.black, 1, 2);
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(0);
		}
	}
}