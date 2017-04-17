﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour {

	public GameObject player;
	public GameObject whaleNPC;
	public GameObject fishHead;
	[Range(0,1)]
	public float whaleChance;
	public float landmarkDistance = 200f;
	public float whaleSpawnDelay = 25f;
	public float fishSpawnDelay = 10f;
	private float timer1 = 0;
	private float timer2 = 0;
	public GameObject[] landmarks;
	private List<Vector2> landmarkLocs;
	public bool spawnLM = false;
	// Use this for initialization
	void Start () {
		GameObject p = GameObject.Find("whale");
		player = p;
		landmarkLocs = new List<Vector2> ();
	}
	
	// Update is called once per frame
	void Update () {
		timer1 += Time.deltaTime;
		timer2 += Time.deltaTime;

		if (timer1 >= whaleSpawnDelay) {
			spawnWhale ();
			timer1 = 0;
		}
		if (timer2 >= fishSpawnDelay) {
			spawnFish ();
			timer2 = 0;
		}
		spawnLandmark ();
	}

	void spawnWhale(){
		if (Random.value <= whaleChance) {
			Random.seed = System.DateTime.Now.Millisecond;
			GameObject whale = Instantiate (whaleNPC) as GameObject;
			Vector3 pos = Vector3.Scale (player.transform.forward, new Vector3 (150, 150, 150));
			Vector3 rand = Vector3.Scale(player.transform.forward, new Vector3 (Random.Range (150, 351), 0, Random.Range (150, 351)));
			Vector3 result = pos + rand;
			result.y = Random.Range (-35, -15);
			whale.transform.position = result;
		}
	}

	void spawnFish(){
		Random.seed = System.DateTime.Now.Millisecond;
		GameObject fish = Instantiate (fishHead) as GameObject;
		Vector3 pos =  Vector3.Scale (player.transform.forward, new Vector3 (150, 150, 150));
		Vector3 rand = Vector3.Scale(player.transform.forward, new Vector3 (Random.Range (150, 351), 0, Random.Range (150, 351)));
		Vector3 result = pos + rand;
		result.y = Random.Range (-35, -15);
		fish.transform.position = result;
	}

	void spawnLandmark() {
		bool spawn = true;
		Random.seed = System.DateTime.Now.Millisecond;
		int selector = Random.Range (0, landmarks.Length);
		Vector3 pos =  Vector3.Scale (player.transform.forward, new Vector3 (150, 150, 150));
		Vector3 rand = Vector3.Scale(player.transform.forward, new Vector3 (Random.Range (150, 351), 0, Random.Range (150, 351)));
		Vector3 result = pos + rand;
		result.y = -55;
		Vector2 resultXZ = new Vector2 (result.x, result.z);
		foreach (Vector2 v in landmarkLocs) {
			if (Vector2.Distance (resultXZ, v) < landmarkDistance)
				spawn = false;
		}
		if (spawn) {
			GameObject.Instantiate (landmarks [selector], result, Quaternion.identity);
			landmarkLocs.Add (resultXZ);
		}
	}
}
