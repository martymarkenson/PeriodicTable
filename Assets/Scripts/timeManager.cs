﻿using UnityEngine;
using System.Collections;

public class timeManager : MonoBehaviour {

	void Update () {
		GetComponent<TextMesh> ().text = canvasManager.shotsLeft.ToString ("0");
	}
}