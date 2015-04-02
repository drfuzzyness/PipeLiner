using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof (Importer))]
public class Producer : MonoBehaviour {

	[Header("State")]
	public List<Color> stored;
	public bool running;
	
	[Header("Balance")]
	public int storageSpace;
	public float baseTimeBetweenDeliveries;
	public float timeBetweenDeliveriesIncreaseRate;

	[Header("Data")]
	public List<Color> possibleColors;
	public List<Renderer> storageIndicators;

	private Importer importer;

//	[Header("Setup")]
//	public GameObject somePrefab; // don't need this

	// Use this for initialization
	void Start () {
		// assign output type
		importer = GetComponent<Importer>();
		importer.accepting = false;
		importer.couldAccept = false;
		updateIndicators();
		StartCoroutine( generationLoop() );
	}

	bool deliver() {
		if( importer.sendColor( stored[0] ) ) {
			// If it sent, clear storage
			stored.RemoveAt(0);
			updateIndicators();
//			importer.accepting = true; // doesn't make sense for a producer to accept goods
			return true;
		}
		return false;
	}

	void updateIndicators() {
		for( int i = 0; i < storageIndicators.Count; i++ ) {
			if( i < stored.Count ) {
				storageIndicators[i].material.color = stored[i];
			} else { 
				storageIndicators[i].material.color = Color.black;
			}
		}
	}

	IEnumerator generationLoop() {
		float duration = baseTimeBetweenDeliveries;
		while( running ) {
			// wait for space
			while( stored.Count > storageSpace ) {
				// i'm full :(
				yield return null;
			}
			// make a new color
			for( float timer = 0; timer < duration; timer += Time.deltaTime ) {
				// visible thing
				yield return null;
			}
			Color randomColor = possibleColors[ Mathf.FloorToInt( Random.Range(0, possibleColors.Count ) ) ];
			stored.Add( randomColor );
			updateIndicators();
		}
	}


	
	// Update is called once per frame
	void Update () {
		if( stored.Count > 0 ) {
			deliver();
		}
	}
}
