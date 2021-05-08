using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottle : MonoBehaviour {
	public float speed =20;
	public float dieTime = 3.00f;
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody> ().velocity = new Vector3 (0.0f, 0.0f, 1) * speed;
		Destroy (this.gameObject, dieTime);
	}

}
