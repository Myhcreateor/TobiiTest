using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestory : MonoBehaviour {


    public GameObject explosion;
    public GameObject explosionplayer;
    public GameController gameController;

    void Start()
    {

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject == null)
        {
            Debug.Log(">>>>");
        }
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        gameController.GameOver();
        Debug.Log(message: other.tag);
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }

}

