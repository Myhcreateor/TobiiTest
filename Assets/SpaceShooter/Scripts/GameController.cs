using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public GameObject Obstacle;
    public GameObject Enemy;
	public Vector3 spawnValue;
	public int obstacleCount;
	public float spawnWait;
	public float startWait;
    public static GameController instance;
    public AudioSource audioSource;
	private  int score;
    private int maxScore;
	public Text scoreText;
	public Text gameoverText;
    public  int level;
	private bool isgameover = false;
     void Awake()
    {
        instance = this;
    }
    void Start(){
		gameoverText.text = "";
		score = 100;
        maxScore = score;
        level = PlayerPrefs.GetInt("Level", 0);
        audioSource = this.GetComponent<AudioSource>();
		UpdateScore ();
		StartCoroutine( SpawnWaves ());
	
	}
	void UpdateScore (){
		scoreText.text = "分数:" + score;
	}
	public void GameOver(){
		isgameover = true;
		gameoverText.text="GameOver";
        scoreText.text = "最高分:" + maxScore;
        audioSource.Stop();
	}
    public void isGameOver()
    {
        if (score < 0)
        {
            GameOver();
            StopAllCoroutines();
           
        }
    }
    IEnumerator SpawnWaves()
    {
        if (level == 0)
        {
            for (int j = 0; j < 100; j++)
            {
                yield return new WaitForSeconds(startWait);
                for (int i = 0; i < obstacleCount; i++)
                {
                    Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(Obstacle, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }

            }
        }
        else
        {
            for (int j = 0; j < 100; j++)
            {
                yield return new WaitForSeconds(startWait);
                for (int i = 0; i < obstacleCount; i++)
                {
                    Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(Obstacle, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(Random.Range(0.1f,0.7f));
                    Vector3 spawnPosition1 = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                    Quaternion spawnRotation1 = Quaternion.identity;
                    Instantiate(Obstacle, spawnPosition1, spawnRotation1);
                    yield return new WaitForSeconds(Random.Range(0.5f, 1.0f));
                }

            }
        }
           
            
    
        
        
    }
	public void	addScore(int Value){
		score += Value;
        if (score > maxScore)
        {
            maxScore = score;
        }
		UpdateScore();
	}
}
