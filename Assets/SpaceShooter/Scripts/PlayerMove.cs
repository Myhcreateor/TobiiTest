using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	[System.Serializable]
	public class Boundary{
		public  float xMin, xMax, zMin, zMax; 
	}
	public float speed = 10;
	public float tilt;
	public Boundary boundary; 
	public float nextFire;
	public float fireRate;
	public GameObject shot;
	public Transform shotSpawn;

    void FixedUpdate () {
		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");
		GetComponent<Rigidbody>().velocity = new Vector3 (x, 0.0f, y) * speed;
		GetComponent<Rigidbody> ().position = new Vector3 (
			Mathf.Clamp( GetComponent<Rigidbody>().position .x,boundary.xMin,boundary.xMax),
			0.0f,
			Mathf.Clamp( GetComponent<Rigidbody>().position .z,boundary.zMin,boundary.zMax)
		);
		GetComponent<Rigidbody> ().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody> ().velocity.x * -tilt);

		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource> ().Play ();
		}
	}
}
