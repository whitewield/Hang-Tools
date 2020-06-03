using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TransitionManager : MonoBehaviour {

	private static TransitionManager instance = null;
	public static TransitionManager Instance { get { return instance; } }

	void Awake () {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
		} else {
			instance = this;
		}

		DontDestroyOnLoad(this.gameObject);
		this.transform.position = Vector3.back * 5;
	}

	private string myNextScene;

	private enum Status {
		Idle,
		TransitionIn,
		TransitionOut
	}

	[SerializeField] Collider2D myCollider2D;
	[SerializeField] Image myImage;
	[SerializeField] Color myTransitionColor = Color.black;
	[SerializeField] float myAnimationTime = 0.5f;
	private float myAnimationTimer;
	private Status myStatus = Status.Idle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		UpdateTransitionIn ();
		UpdateTransitionOut ();

//		Debug.Log (myAnimationTimer);
	}

	public void UpdateTransitionIn () {
		if (myStatus == Status.TransitionIn) {
			myAnimationTimer -= Time.unscaledDeltaTime;
			if (myAnimationTimer <= 0) {
				myAnimationTimer = 0;
				myStatus = Status.Idle;


			}

			//change the color
			Color t_color = myTransitionColor;
			t_color.a = (myAnimationTimer / myAnimationTime);
			myImage.color = t_color;
		}
	}

	public void UpdateTransitionOut () {
//		Debug.Log (myAnimationTimer);
		if (myStatus == Status.TransitionOut) {
			myAnimationTimer -= Time.unscaledDeltaTime;
			if (myAnimationTimer <= 0) {
				myAnimationTimer = 0;
				myStatus = Status.Idle;
				StartLoading ();
			}

			//change the color
			Color t_color = myTransitionColor;
			t_color.a = 1 - (myAnimationTimer / myAnimationTime);
			myImage.color = t_color;
		}
	}

	public void StartTransition (string g_scene) {
		myNextScene = g_scene;
		//		myGrapeAnimator.SetBool ("isGrape", true);
		TransitionOut ();
	}

	public void EndTransition () {
		TransitionIn ();
	}

	public void TransitionIn () {
		
		myAnimationTimer = myAnimationTime;
		myStatus = Status.TransitionIn;
		//		myAnimator.SetBool ("isTransitioning", false);
		myCollider2D.enabled = false;
		myImage.raycastTarget = false;
	}

	public void TransitionOut () {
		Debug.Log ("TransitionOut");
		myAnimationTimer = myAnimationTime;
		myStatus = Status.TransitionOut;
//		myAnimator.SetBool ("isTransitioning", true);
		myCollider2D.enabled = true;
		myImage.raycastTarget = true;
	}

	public void StartLoading () {
		SceneManager.LoadSceneAsync (myNextScene);
	}
}
