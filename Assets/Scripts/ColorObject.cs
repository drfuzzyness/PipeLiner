using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class ColorObject : MonoBehaviour {

	public Color color;
	public float maxSpeed;
	public bool isMoving;

	public void stopMoving() {
		GetComponent<Rigidbody>().drag = 1000f;
	}

	public void startMoving() {
		GetComponent<Rigidbody>().drag = 0f;
	}

	public void setColor(Color newColor) {
		color = newColor;
		GetComponent<Renderer>().material.color = color;
	}

	void FixedUpdate() {
		if( isMoving && GetComponent<Rigidbody>().velocity.magnitude < maxSpeed ) {
			GetComponent<Rigidbody>().AddForce( transform.forward * (maxSpeed / 4), ForceMode.VelocityChange );
		}
	}
}
