using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDown : MonoBehaviour
{
    private GameController gameController;
    private float speed ;
    public float dieTime = 5.00f;
    private int bottleDamage;
    // Update is called once per frame
     void Start()
    {
        gameController = GameController.instance;
        bottleDamage = gameController.gameInfromarion.asteroidDamage;
        speed = gameController.gameInfromarion.asteroidSpeed;
    }
    void Update()
    {
        dieTime -= Time.deltaTime;
        GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.85f) * -speed;
        if (dieTime <= 0.0f)
        {
            Destroy(this.gameObject);
            gameController.addScore(-bottleDamage);
            gameController.isGameOver();
        }
        
    }
}
