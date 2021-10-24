using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System.IO;
public class GameController : MonoBehaviour {
	public GameObject Obstacle;
    public GameObject parabolaObstacleLift;
    public GameObject parabolaObstacleRight;
    public GameObject returnButton;
    public GameObject Enemy;
	public Vector3 spawnValue;
	public int obstacleCount;
	private float spawnWait;
	public float startWait;
    public static GameController instance;
    public AudioSource audioSource;
	private  int score;
    private int maxScore;
	public Text scoreText;
	public Text gameoverText;
    public  int level;
	private bool isgameover = false;
    public GameInfromarion gameInfromarion;
     void Awake()
    {
        instance = this;
        gameInfromarion = LoadJson();
    }
    void Start(){
        //gameInfromarion = new GameInfromarion();
        gameoverText.text = "";
        returnButton.SetActive(false);
        score = gameInfromarion.startScore;
        spawnWait = gameInfromarion.spawnWait;
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
		gameoverText.text="游戏失败";
        scoreText.text = "最高分:" + maxScore;
        audioSource.Stop();
        returnButton.SetActive(true);
	}
    public void isGameOver()
    {
        if (score < 0)
        {
            GameOver();
            StopAllCoroutines();
           
        }
    }
    public void isGameWin()
    {
        if(level==0&& score >= gameInfromarion.easyGameWinScore)//默认简单模式300分游戏胜利
        {
            gameoverText.text = "简单模式游戏胜利";
            isgameover = true;
            scoreText.text = "最高分:" + maxScore;
            audioSource.Stop();
            StopAllCoroutines();
            returnButton.SetActive(true);
        }
        else if(level == 1 && score >= gameInfromarion.difficultGameWinScore)//默认困难模式500分游戏胜利
        {
            gameoverText.text = "困难模式游戏胜利";
            isgameover = true;
            scoreText.text = "最高分:" + maxScore;
            audioSource.Stop();
            StopAllCoroutines();
            returnButton.SetActive(true);
        }
        
    }
    public void QuitGame()
    {
        Application.Quit();
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
                    yield return new WaitForSeconds(spawnWait+(3-GameProgress.differentLevel)*0.5f);
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
                    if(i == 0)
                    {
                        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                        Quaternion spawnRotation = Quaternion.identity;
                        Instantiate(Obstacle, spawnPosition, spawnRotation);
                        yield return new WaitForSeconds(spawnWait - Random.Range(0.0f, 0.4f));
                    }else if (i == 1)
                    {
                        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                        Quaternion spawnRotation = Quaternion.identity;
                        Instantiate(Obstacle, spawnPosition, spawnRotation);
                        yield return new WaitForSeconds(spawnWait - Random.Range(0.0f, 0.4f));
                    }
                    else if (i == obstacleCount - 1)
                    {
                        if (Random.Range(0.0f, 1.0f) > 0.5)
                        {
                            Vector3 spawnParapolaPosition = new Vector3(Random.Range(-10, -6), 1, Random.Range(-6, 0));
                            Quaternion spawnParapolaRotation = Quaternion.identity;
                            Instantiate(parabolaObstacleLift, spawnParapolaPosition, spawnParapolaRotation);
                        }
                        else
                        {
                            Vector3 spawnParapolaPosition = new Vector3(Random.Range(8,12), 1, Random.Range(-6, 0));
                            Quaternion spawnParapolaRotation = Quaternion.identity;
                            Instantiate(parabolaObstacleRight, spawnParapolaPosition, spawnParapolaRotation);
                        }
                        yield return new WaitForSeconds(spawnWait - Random.Range(0f, 0.4f));
                    }
                   
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
        if (!isgameover) { UpdateScore(); }
        isGameWin();
	}
    
    /// <summary>
    /// 关于Json
    /// </summary>
    public void SaveJson()
    {
        string path = Application.streamingAssetsPath + "\\Json\\GameInformation.txt";
        string s = JsonMapper.ToJson(gameInfromarion);
        File.WriteAllText(path, s);
    }
    public  GameInfromarion LoadJson()
    {
        string path = Application.streamingAssetsPath + "\\Json\\GameInformation.txt";
        string s = File.ReadAllText(path);
        GameInfromarion gameInfromarion = JsonMapper.ToObject<GameInfromarion>(s);
        return gameInfromarion;
    }
}
