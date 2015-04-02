using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[RequireComponent (typeof (Importer))]
public class Transformer : MonoBehaviour {
	

	[Header("State")]
	public Color stored;
	public Color outputColor;
	public Vector3 colorTransform;
	public float progress;
	
	[Header("Balance")]
	public float duration;
	
	[Header("Config")]
	public float colorTransformVisualModifier;
	private Importer importer;
	
	[Header("Setup")]
	public Renderer colorIndicator;
	public List<Renderer> colorTransformIndicator;
	public Renderer outputColorIndicator;
	public Slider progressSlider;
	
	// Use this for initialization
	void Start () {
		// assign output type
		importer = GetComponent<Importer>();
		stored = Color.black;
		importer.accepting = true;
		importer.couldAccept = true;
		updateIndicators();
	}
	
	public void changeOutputType() {
	}

	public void updateIndicators() {
		colorIndicator.material.color = stored;
		Color theColorTransform = new Color( colorTransform.x * colorTransformVisualModifier,
		                                    colorTransform.y * colorTransformVisualModifier,
		                                    colorTransform.z * colorTransformVisualModifier );
		foreach( Renderer thisRenderer in colorTransformIndicator ) {
			thisRenderer.material.color = theColorTransform;
		}
		if( progress == 0 ) 
			outputColorIndicator.material.color = theColorTransform + stored;

	}

	public void recieve( Color recieved ) {
		if( stored != Color.black )
			Debug.LogError( "There's already " + stored + " stored, so I have to overwrite it with " + recieved );
		stored = recieved;
		updateIndicators();
		StartCoroutine( processColor( stored, duration ) );
	}
	
	bool deliver() {
		if( importer.sendColor( stored ) ) {
			// If it send, clear storage
			stored = Color.black;
			updateIndicators();
			importer.accepting = true;
			return true;
		}
		return false;
	}

	

	IEnumerator processColor( Color theColor, float length ) {
		// Note, purely simulated with no visual output for now. Change later.
		Color oldColor = theColor;
		ColorBlock newColorBlock = progressSlider.colors;
		newColorBlock.normalColor = theColor;
		progressSlider.colors = newColorBlock;
		for( progress = 0; progress < length; progress += Time.deltaTime ) {
			theColor = Color.Lerp( oldColor, outputColor, progress / length );
			progressSlider.value = progress;
			progressSlider.maxValue = length;
			updateIndicators();
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
