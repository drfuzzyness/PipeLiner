using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Producer : MonoBehaviour {

	[Header("State")]
	public bool running;
	
	[Header("Balance")]
	public int storageSpace;
	public float baseTimeBetweenDeliveries;
	public float timeBetweenDeliveriesIncreaseRate;

	[Header("Data")]
	public List<Color> possibleColors;
	public List<Transform> spawnPoints;

	[Header("Setup")]
	public GameObject colorObject;

	// Use this for initialization
	void Start () {
		// assign output type
		StartCoroutine( generationLoop() );
	}

	void deliver( Color newColor) {
		Vector3 spawnPos = spawnPoints[ Mathf.FloorToInt( Random.Range(0, spawnPoints.Count ) ) ].position;
		ColorObject newBlock = Instantiate( colorObject, spawnPos, transform.rotation ) as ColorObject;
		newBlock.setColor( newColor );
	}
	

	IEnumerator generationLoop() {
		float duration = baseTimeBetweenDeliveries;
		while( running ) {
			// make a new color
			for( float timer = 0; timer < duration; timer += Time.deltaTime ) {
				// visible thing
				yield return null;
			}
			deliver( possibleColors[ Mathf.FloorToInt( Random.Range(0, possibleColors.Count ) ) ] );
		}
	}


	
	// Update is called once per frame
	void Update () {
	}
}
