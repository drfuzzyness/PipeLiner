using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Importer : MonoBehaviour {
	// Exists so that there's standardized way of recieving colors

	[Header("State")]
	public bool accepting;

	[Header("Config")]
	public bool couldAccept;
//	public List<Importer> inputs;
	public List<Pipe> outputs;

	public void recieveColor( Color delivery ) {
		SendMessage( "recieve", delivery );
	}

	public bool sendColor( Color delivery ) {
		// Returns true if sent
		Pipe target = requestToDeliverToPorts();
		if( target != null ) {
			target.sendAlongPipe( delivery );
			Debug.Log( "Sending " + delivery + " to " + target.gameObject.name );
			return true;
		}
		return false;
	}


	Pipe requestToDeliverToPorts() {
		// Currently finds the most open port
		foreach( Pipe pipe in outputs ) {
			if( pipe.destination.accepting )
				return pipe;
		}
		return null;
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
