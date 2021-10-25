using DG.Tweening;
using Tobii.Gaming;
using UnityEngine;

public class Destory : MonoBehaviour
{

    public GameObject explosion;
    public GameObject explosionplayer;
    private int value;
    public float deadTime = 1.2f;
    private float deadTimer = 0.0f;
    private bool isTranslate = false;
    private GameObject prego;
    private GameController gameController;
    void Start()
    {
        gameController = GameController.instance;
        value = gameController.gameInfromarion.value;
    }

    void Update()
    {
        GameObject go = TobiiAPI.GetFocusedObject();
        if (go != null && go.tag == "Obstacle")
        {
            go.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            if (isTranslate == false)
            {
                Tween twe = go.transform.DOScale(new Vector3(1.25f, 1.25f, 1.25f), 1.2f);
                twe.SetEase(Ease.InCubic);
                twe.OnComplete(() =>
                {
                    Instantiate(explosion, go.transform.position, go.transform.rotation);
                    DestroyImmediate(go.gameObject);
                    gameController.addScore(value);
                    GameProgress.finished++;
                    GameProgress.continuousFinished++;
                    GameProgress.continuousUnfinished = 0;
                    GameProgress.AdjustDifficult();
                    Debug.Log("differentLevel:" + GameProgress.differentLevel);
                });
                isTranslate = true;
            }
        }
        else if (go != null && go.tag == "Aircaft")
        {
            go.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            if (isTranslate == false)
            {
                Tween twe = go.transform.DOScale(new Vector3(1.05f, 1.05f, 1.05f), 1.2f);
                twe.SetEase(Ease.InCubic);
                twe.OnComplete(() =>
                {
                    Instantiate(explosionplayer, go.transform.position, go.transform.rotation);
                    DestroyImmediate(go.gameObject);
                    gameController.addScore(-value);
                    //GameProgress.finished++;
                    //GameProgress.continuousFinished++;
                    //GameProgress.continuousUnfinished = 0;
                    //GameProgress.AdjustDifficult();
                    //Debug.Log("differentLevel:" + GameProgress.differentLevel);
                });
                isTranslate = true;
            }
        }
    }
}


