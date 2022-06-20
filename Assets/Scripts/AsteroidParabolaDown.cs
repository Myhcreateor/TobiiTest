using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidParabolaDown : MonoBehaviour
{
    private GameController gameController;
    private float speed;
    public float dieTime = 5.00f;
    private int bottleDamage;
    private Rigidbody rigidbody;
    // Update is called once per frame
    void Start()
    {
        gameController = GameController.instance;
        rigidbody = GetComponent<Rigidbody>();
        bottleDamage = gameController.gameInfromarion.asteroidDamage;
        speed = gameController.gameInfromarion.asteroidSpeed;
    }
    void Update()
    {
        dieTime -= Time.deltaTime;
        rigidbody.velocity = new Vector3(0.6f, 0.0f,(dieTime-5)*0.8f) * speed;
        if (dieTime <= 0.0f)
        {
            Destroy(this.gameObject);
            gameController.addScore(-bottleDamage);
            gameController.isGameOver();
        }

    }
}
