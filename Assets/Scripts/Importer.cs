using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Importer : MonoBehaviour {
	// Exists so that there's standardized way of recieving colors

	[Header("State")]
	public bool accepting;

	[Header("Config")]
	public List<Importer> inputs;
	public List<Pipe> outputs;

	public void recieveColor( Color delivery ) {
		SendMessage( "recieve", delivery );
	}

	public void sendColor( Color delivery ) {

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
