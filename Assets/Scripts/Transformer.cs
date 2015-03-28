using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof (Importer))]
public class Transformer : MonoBehaviour {
	

	[Header("State")]
	public Color stored;
	public Color outputColor;
	public float progress;
	
	[Header("Balance")]
	public float duration;
	
	[Header("Config")]
	public List<Importer> outputs;
	
	private Importer importer;
	
	[Header("Setup")]
	public Renderer colorIndicator;
	
	// Use this for initialization
	void Start () {
		// assign output type
		importer = GetComponent<Importer>();
		importer.accepting = true;
	}
	
	public void changeOutputType() {
	}
	
	
	void requestToDeliver() {
		foreach( Importer port in outputs ) {
		}
	}

	public void recieve( Color recieved ) {
		if( stored != Color.black )
			Debug.LogError( "There's already " + stored + " stored, so I have to overwrite it with " + recieved );
		stored = recieved;
		importer.accepting = false;
	}
	
	void deliver( Importer destination) {
		Debug.Log( "Sending " + stored + " to " + destination.gameObject.name );
		destination.recieveColor( stored );
		stored = Color.black;
	}

	

	IEnumerator processColor( Color theColor, float duration ) {
		// Note, purely simulated with no visual output for now. Change later.
		Color oldColor = theColor;
		for( progress = 0; progress < duration; progress += Time.deltaTime ) {
			theColor = Color.Lerp( oldColor, outputColor, progress / duration );
			yield return null;
		}
		bool sentColor = false;
		while( !sentColor ) {

		}
	}
	
	
	// Update is called once per frame
	void Update () {
		
	}
}
