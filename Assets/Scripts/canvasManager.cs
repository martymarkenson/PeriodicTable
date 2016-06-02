﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class canvasManager : MonoBehaviour {
	public static bool playing; //flag for if user is in a round
	public static float timeLeft; //timeLeft before the round is over
	public static int score , levelCount; //users score and number of levels in the game
	private int goal; //the score the user needs to obtain
	Animator anim; //controls when instructions, time, score and playagain/next level

	void Start () {
		levelCount = 3;
		score = 0;
		goal = 1;
		timeLeft = 60f;
		anim = GetComponent<Animator> ();
	}

	void Update () {
		if (playing) {
			timeLeft -= Time.deltaTime;
			anim.SetTrigger ("playing"); //score and timeLeft are shown to user
		}

		if (score >= goal) {
			anim.SetTrigger ("gameOver"); //nextSteps button is shown
			playing = false;
		}

		if (timeLeft<=0) {
			anim.SetTrigger ("gameOver"); //nextSteps button is Shown
			playing = false;
		}
	}
		
	public void home() {
		SceneManager.LoadScene (0);
	}

	//if won go to next level else try again
	public void nextSteps() {
		if (score >= goal) {
			SceneManager.LoadScene ((SceneManager.GetActiveScene().buildIndex+1)%3);
		} else {
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		}
	}
}
