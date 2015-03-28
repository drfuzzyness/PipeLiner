using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Producer : MonoBehaviour {

	[Header("State")]
	public Queue<Color> stored;
	public Color outputType;
	public float progress;

	[Header("Balance")]
	public float duration;
	public int storageSpace;

	[Header("Config")]
	public List<Importer> outputs;

	private Importer importer;

//	[Header("Setup")]
//	public GameObject somePrefab; // don't need this

	// Use this for initialization
	void Start () {
		// assign output type
	}

	void attemptDeliveries() {
		// Attempts to deliver the color at the head of the quene
	}

	Importer findDestination() {
		// Finds a destination willing to accept. Returns that Importer if found, null if not.
		foreach( Importer port in outputs ) {
			if( port.accepting ) {
				return port;
			}
		}
		return null;
	}

	void deliver( Importer destination) {
		Debug.Log( "Sending " + stored.Peek () + " to " + destination.gameObject.name );
		destination.recieveColor( stored.Dequeue() );
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
