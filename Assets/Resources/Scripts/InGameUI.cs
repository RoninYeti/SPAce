﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SPAce {
	public class InGameUI : MonoBehaviour {

		public float timeToWait=5f;

		void OnEnable() {
			StartCoroutine(GotoFirstScene());
		}

		IEnumerator GotoFirstScene() {
			yield return new WaitForSeconds(timeToWait);
			SceneManager.LoadScene(0);
		}
	}
}