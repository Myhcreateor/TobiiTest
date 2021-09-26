using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;
public class Destory : MonoBehaviour {

	public GameObject explosion;
	public GameObject explosionplayer;
	private int value;
	private GameController gameController;

	void Start(){
        gameController = GameController.instance;
        value = gameController.gameInfromarion.value;
    }
 
     void Update()
    {
        GameObject go = TobiiAPI.GetFocusedObject();
        
        if (go != null && go.tag == "Obstacle")
        {
            Instantiate(explosion, go.transform.position, go.transform.rotation);
            Destroy(go);
            gameController.addScore(value);
        }
    }

}
