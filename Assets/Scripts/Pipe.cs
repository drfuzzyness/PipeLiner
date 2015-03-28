using UnityEngine;
using System.Collections;

public class Pipe : MonoBehaviour {

	public Importer destination;
	public Color stored;
	public float duration;

	private Renderer renderer;

	public void sendAlongPipe() {
		StartCoroutine( recieve );
	}

	IEnumerator recieve( Color package ) {
		stored = package;
		for( float time = 0; time < duration/2; time += Time.deltaTime ) {
			renderer.material.color = Color.Lerp( Color.black, package, time / (duration / 2) );
			yield return null;
		}
		renderer.material.color = stored;
		while( !destination.accepting ) {
			yield return null;
		}
		StartCoroutine( send );
	}

	IEnumerator send() {
		for( float time = 0; time < duration/2; time += Time.deltaTime ) {
			renderer.material.color = Color.Lerp( stored, Color.black, time / (duration / 2) );
			yield return null;
		}
		destination.recieveColor( stored );
		stored = Color.black;
		renderer.material.color = Color.black;
	}


	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
