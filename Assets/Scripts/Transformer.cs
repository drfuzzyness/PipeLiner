using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof (Importer))]
public class Transformer : MonoBehaviour {
	
	[Header("State")]
	public List<Color> stored;
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

	}
	
	void deliver() {
		
	}
	
	
	// Update is called once per frame
	void Update () {
		
	}
}
