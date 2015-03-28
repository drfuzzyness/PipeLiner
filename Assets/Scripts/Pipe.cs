using UnityEngine;
using System.Collections;

public class Pipe : MonoBehaviour {

	public Importer destination;
	public Color stored;
	public float duration;

	public Renderer indicator;

	public void sendAlongPipe( Color package) {
		StartCoroutine( "recieve", package );
	}

	IEnumerator recieve( Color package ) {
		stored = package;
		for( float time = 0; time < duration/2; time += Time.deltaTime ) {
			indicator.material.color = Color.Lerp( Color.black, package, time / (duration / 2) );
			yield return null;
		}
		indicator.material.color = stored;
		while( !destination.accepting ) {
			// wait until the destination can accept
			yield return null;
		}
		StartCoroutine( "send" );
	}

	IEnumerator send() {
		for( float time = 0; time < duration/2; time += Time.deltaTime ) {
			indicator.material.color = Color.Lerp( stored, Color.black, time / (duration / 2) );
			yield return null;
		}
		destination.recieveColor( stored );
		stored = Color.black;
		indicator.material.color = Color.black;
	}


	// Use this for initialization
	void Start () {
		indicator.material.color = Color.black;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
