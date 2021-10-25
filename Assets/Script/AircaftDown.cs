using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircaftDown : MonoBehaviour
{
    private GameController gameController;
    private float speed;
    private int value;

    // Update is called once per frame
    void Start()
    {
        gameController = GameController.instance;
        speed = gameController.gameInfromarion.asteroidSpeed;
        value = gameController.gameInfromarion.value;
    }
    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.5f) * -speed;
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "AirWall")
        {
            Destroy(this.gameObject);
            gameController.addScore(value);
        }
    }
}