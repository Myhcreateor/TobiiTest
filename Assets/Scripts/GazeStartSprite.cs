using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tobii.Gaming;
public class GazeStartSprite : MonoBehaviour
{
    public Scrollbar scrollbar;
    private SpriteRenderer sr;
    public Color easyColor;
    public Color difficultColor;
    public float gazeTime;
    private float timer;
    private int level;
    void Start()
    {
        gazeTime = 2.0f;
        timer = gazeTime;
        level = 0;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject go = TobiiAPI.GetFocusedObject();
        //if (go != null && go.tag == "Start")
        if (go != null && go.ToString().CompareTo("StartSprite (UnityEngine.GameObject)") == 0)
        {
            timer -= Time.deltaTime;
            scrollbar.size = (gazeTime - timer) / gazeTime;
            if (timer <= 0)
            {
                PlayerPrefs.SetInt("Level", level);
                Application.LoadLevel(2);
            }
        }
        else if (go != null && go.ToString().CompareTo("easy (UnityEngine.GameObject)") == 0)
        {
            sr.color = easyColor;
            timer = gazeTime;
            level = 0;
        }
        else if (go != null && go.ToString().CompareTo("difficult (UnityEngine.GameObject)") == 0)
        {
            sr.color = difficultColor;
            timer = gazeTime;
            level = 1;
        }
    }
    public void SetEasyButton()
    {
        sr.color = easyColor;
        timer = gazeTime;
        level = 0;

    }
    public void SetDifficultButton()
    {
        sr.color = difficultColor;
        timer = gazeTime;
        level = 1;
    }
    public void StartGameButton()
    {
        PlayerPrefs.SetInt("Level", level);
        Application.LoadLevel(2);
    }

}

