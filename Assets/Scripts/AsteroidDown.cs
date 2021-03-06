using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDown : MonoBehaviour
{
    private GameController gameController;
    private float speed ;
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
        GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.5f) * -speed;
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "AirWall")
        {
            Destroy(this.gameObject);
            gameController.addScore(-bottleDamage);
            gameController.isGameOver();
            GameProgress.unfinished++;
            GameProgress.continuousFinished = 0;
            GameProgress.continuousUnfinished++;
            GameProgress.AdjustDifficult();
            Debug.Log("differentLevel:" + GameProgress.differentLevel);
        }
    }
}
