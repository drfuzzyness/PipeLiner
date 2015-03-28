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
	
	private Importer importer;
	
	[Header("Setup")]
	public Renderer colorIndicator;
	
	// Use this for initialization
	void Start () {
		// assign output type
		importer = GetComponent<Importer>();
		stored = Color.black;
		importer.accepting = true;
		importer.couldAccept = true;
		colorIndicator.material.color = stored;
	}
	
	public void changeOutputType() {
	}

	public void recieve( Color recieved ) {
		if( stored != Color.black )
			Debug.LogError( "There's already " + stored + " stored, so I have to overwrite it with " + recieved );
		stored = recieved;
		colorIndicator.material.color = stored;
		importer.accepting = false;
		StartCoroutine( processColor( stored, duration ) );
	}
	
	bool deliver() {
		if( importer.sendColor( stored ) ) {
			// If it send, clear storage
			stored = Color.black;
			colorIndicator.material.color = stored;
			importer.accepting = true;
			return true;
		}
		return false;
	}

	

	IEnumerator processColor( Color theColor, float length ) {
		// Note, purely simulated with no visual output for now. Change later.
		Color oldColor = theColor;
		for( progress = 0; progress < length; progress += Time.deltaTime ) {
			theColor = Color.Lerp( oldColor, outputColor, progress / length );
			colorIndicator.material.color = theColor;
			yield return null;
		}
		Debug.Log( "Processing " + oldColor + " to " + theColor + " is done." );
		bool sentColor = false;
		while( !sentColor ) {
			sentColor = deliver();
			yield return null;
		}
	}
	
	
	// Update is called once per frame
	void Update () {
		
	}
}
