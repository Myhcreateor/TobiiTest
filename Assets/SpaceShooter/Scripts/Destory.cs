using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;
public class Destory : MonoBehaviour {

	public GameObject explosion;
	public GameObject explosionplayer;
	private int value;
    public float deadTime=1.2f;
    private float deadTimer;
    private GameObject prego;
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
            go.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            if (prego != go)
            {
                deadTimer = 0.0f;
            }
            else
            {
                deadTimer += Time.deltaTime;
            }
            if (deadTimer >= deadTime)
            { 
                Instantiate(explosion, go.transform.position, go.transform.rotation);
                Destroy(go);
                gameController.addScore(value);
            }

        }
        prego = go;
    }


}
