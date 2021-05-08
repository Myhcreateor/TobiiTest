using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRolator : MonoBehaviour {
	public float tumble = 5.00f;
	void Start(){
		GetComponent <Rigidbody> ().angularVelocity = Random.insideUnitSphere * tumble;

	}
	void Update () {
		
	}
}
