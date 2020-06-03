using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hang {
	namespace ObedientObjectPool {
		public class ObedientObjectPool {
			private GameObject myObjectPrefab;
			private List<GameObject> myObjectPool = new List<GameObject> ();

			private bool isMissingScript = false;
			private Transform myParent;
			private float myObjectKillTime = 10f;

			public ObedientObjectPool (GameObject g_object, Transform g_parent, int g_startCount = 10, float g_killTime = 10f) {
				myObjectPrefab = g_object;
				myParent = g_parent;
				myObjectKillTime = g_killTime;

				// check if we need to add ObedientObject when creating a clone of the game object
				if (myObjectPrefab.GetComponent<ObedientObject>() == null){
					isMissingScript = true;
				}

				for (int i = 0; i < g_startCount; i++) {
					CreateNewObject ();
				}
			}

			private GameObject CreateNewObject () {
				GameObject t_object = Object.Instantiate (myObjectPrefab, myParent) as GameObject;

				// if the object doesnt have ObedientObject, add it to the object
				if (isMissingScript) {
					t_object.AddComponent<ObedientObject> ();
				}

				// update the kill time
				t_object.GetComponent<ObedientObject> ().SetKillTime (myObjectKillTime);

				// set the object to enactive
				t_object.SetActive (false);

				// add to pool
				myObjectPool.Add (t_object);

				return t_object;
			}

			/// <summary>
			/// Get a idle object, the object will still be enactive, you need to setactive to true to use it.
			/// </summary>
			/// <returns>a idle object.</returns>
			public GameObject Get () {
				// find a object that is not in use to return
				foreach (GameObject t_object in myObjectPool) {
					if (t_object.activeSelf == false)
						return t_object;
				}

				// if cannot find one, return a new object
				return CreateNewObject ();
			}
		}
	}
}
