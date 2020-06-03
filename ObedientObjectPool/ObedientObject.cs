using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hang {
	namespace ObedientObjectPool {
		public class ObedientObject : MonoBehaviour {
			private float myKillTime = 10f;
			private float myTimer;

			public void SetKillTime (float g_time) {
				myKillTime = g_time;
			}

			private void OnEnable () {
				myTimer = Time.time + myKillTime;
			}

			private void Update () {
				if (Time.time > myTimer) {
					Kill ();
				}
			}

			public void Kill () {
				this.gameObject.SetActive (false);
			}
		}
	}
}
