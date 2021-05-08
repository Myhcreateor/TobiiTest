using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destory1 : MonoBehaviour {

	public float deadTime;
	void Start(){
		Destroy (gameObject, deadTime);
	}
}
