using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDown : MonoBehaviour
{
    private GameController gameController;
    public float speed = -6;
    public float dieTime = 5.00f;
    // Update is called once per frame
     void Start()
    {
        gameController = GameController.instance;
    }
    void Update()
    {
        dieTime -= Time.deltaTime;
        GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 1) * speed;
        if (dieTime <= 0.0f)
        {
            Destroy(this.gameObject);
            if (gameController.level==0)
            {
                gameController.addScore(-20);
            }
            if(gameController.level == 1)
            {
                gameController.addScore(-30);
            }
            gameController.isGameOver();
        }
        
    }
}
