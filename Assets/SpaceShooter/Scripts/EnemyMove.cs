using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [System.Serializable]
    public class Boundary
    {
        public float xMin, xMax;
    }
    public float speed = 20;
    public float dieTime = 3.00f;
    public float Timer = 0;
    public GameObject shot;
    public Transform shotSpawn1;
    public Transform shotSpawn2;
    public Boundary boundary;
    private float xposition;
    private float x = 1;
    private float transformTime = 0;
    // Update is called once per frame
    void Start()
    {
        Timer = Time.time;
    }
    void Update()
    {
        xposition = this.transform.position.x;
        transformTime = Time.time;
        if (transformTime - Timer >= 1)
        {
            int a = Random.Range(0, 2);
            if (xposition > boundary.xMax)
            {
                a = 1;
            }
            if (xposition < boundary.xMin)
            {
                a = 0;
            }
            if (a == 0) x = -1;
            if (a == 1) x = 1;
            float xfloat = 0.2f * x;
            GetComponent<Rigidbody>().velocity = new Vector3(xfloat, 0.0f, 1) * speed;

            Timer = transformTime;

            Instantiate(shot, shotSpawn1.position, shotSpawn1.rotation);
            Instantiate(shot, shotSpawn2.position, shotSpawn2.rotation);
            Destroy(this.gameObject, dieTime);
        }
    }
}
