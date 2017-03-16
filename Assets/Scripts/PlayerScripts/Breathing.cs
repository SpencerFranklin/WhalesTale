﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Breathing : MonoBehaviour {

	// Seconds you can spend underwater
	public float breathLength; // 60 is recommended
	public float currentBreath;
	// Seconds until bubbles appear again
	private float bubbleFrequency;
	private float minBubbleFrequency = 1;
	public float waterHeight;
	public Vector3 bubbleOffset;
	public GameObject bubblePrefab;
	[Header("A float on the interval (0, 1]")]
	// Closer to 0 is bubbles more often
	// Closer to 1 is bubbles less often
	public float bubbleFactor; // 0.3 is recommended
	private Rigidbody rb;
	private bool animating;

	// Use this for initialization
	void Start () {
		currentBreath = breathLength;
		rb = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		// underwater
		if(this.gameObject.transform.position.y < waterHeight) {
			animating = false;
			//rb.useGravity = false;
			if (currentBreath <= 0) {
				// out of breath
			    Debug.Log ("Dead");
				currentBreath = breathLength;
				bubbleFrequency = bubbleFactor * currentBreath;
			} 
			else {
				currentBreath -= Time.deltaTime;
				if (bubbleFrequency <= 0) {
					//spawn a bubble and reset bubbleFrequency
					int bubbleCount = Random.Range(3, 10);
					for (int i = 0; i < bubbleCount; i++){
						GameObject bubble = Instantiate(bubblePrefab) as GameObject;
						bubble.transform.position = this.gameObject.transform.position + bubbleOffset;
					}
					bubbleFrequency = bubbleFactor * currentBreath;
					if (bubbleFrequency < minBubbleFrequency) {
						bubbleFrequency = minBubbleFrequency;
					}
				} else {
					bubbleFrequency -= Time.deltaTime;
				}
			}
		}
		// above water - reset breath
		else {
			currentBreath = breathLength;
			bubbleFrequency = bubbleFactor * currentBreath;

			Debug.Log ("above");
			animating = true;
			// TODO: have whale above water animation
			// Send upward at force
			// add gravity
			// splash effect where whale lands
			// water spout? 

			//rb.AddForce(new Vector3(0, 1, 1));
			//rb.useGravity = true;	
			//this.GetComponent<WhaleMove> ().enabled = false;
		}
	}
}
