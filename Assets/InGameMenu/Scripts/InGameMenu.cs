﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InGameMenu : MonoBehaviour {

	private bool isPause = false;

	private Rect butRect;
	private float ctrlWidth = 160;
	private float ctrlHeight = 30;

	GameObject leftWindow;
	GameObject rightWindow;

	void Awake () {
		butRect = new Rect ((Screen.width - ctrlWidth) / 2, -Screen.height - (((4*ctrlHeight)+(4*20))/2), ctrlWidth, ctrlHeight);
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {			// Keycode auslesen aus den PlayerPrefs
			ToggleTimeScale();
		}
	}

	void ToggleTimeScale () {
		Debug.Log ("ToggleTimeScale");
		if (!isPause) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
		isPause = !isPause;
	}
		
	void OnGUI() {
		// Create the whole GUI	
		if (isPause) {
			butRect.y = (Screen.height - ctrlHeight) / 2;
			if (GUI.Button (butRect, "Continue")) {
				ToggleTimeScale ();
			}
			butRect.y += ctrlHeight + 20;
			if (GUI.Button (butRect, "Main Menu")) {
				UnityEngine.SceneManagement.SceneManager.LoadScene (0);
			}

			butRect.y += ctrlHeight + 20;
			if (GUI.Button (butRect, "Settings")) {
				Debug.Log ("Settings clicked");
				
				PlayerPrefs.SetInt( "previousLevel", Application.loadedLevel);
				UnityEngine.SceneManagement.SceneManager.LoadScene (1);
			}

			butRect.y += ctrlHeight + 20;
			if (GUI.Button (butRect, "Exit")) {
				ToggleTimeScale ();
				Application.Quit();
			}		
		}
	}
}