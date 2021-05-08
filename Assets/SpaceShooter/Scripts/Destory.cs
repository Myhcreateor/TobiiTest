using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;
public class Destory : MonoBehaviour {

	public GameObject explosion;
	public GameObject explosionplayer;
	public int Value;
	private GameController gameController;

	void Start(){
		Value = 10;
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if(gameControllerObject != null){
			gameController = gameControllerObject.GetComponent<GameController>();
			}
	}
 
     void Update()
    {
        GameObject go = TobiiAPI.GetFocusedObject();
        
        if (go != null && go.tag == "Obstacle")
        {
            Instantiate(explosion, go.transform.position, go.transform.rotation);
            Destroy(go);
            gameController.addScore(Value);
        }
    }

}
