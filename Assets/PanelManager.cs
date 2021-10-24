using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.IO;
using LitJson;

public class PanelManager : MonoBehaviour
{
    private Button settingBtn;
    private  GameController gameController;
    private GameObject settingPanel;
    private Button returnBtn;
    private Button restoreDefaultBtn;
    private Button confirmBtn;
    public List<GameObject> inputFields;
    private List<int> settingData;
    private GameInfromarion gameInfromarion;
    private GameObject startSprite;

    void Start()
    {
        gameController = GameController.instance;
        settingData = new List<int>();
        settingBtn = transform.Find("SettingBtn").GetComponent<Button>();
        settingPanel = transform.Find("SettingPanel").gameObject;
        returnBtn = transform.Find("SettingPanel/ReturnButton").GetComponent<Button>();
        confirmBtn = transform.Find("SettingPanel/ConfirmButton").GetComponent<Button>();
        restoreDefaultBtn= transform.Find("SettingPanel/RestoreDefaultButton").GetComponent<Button>();
        startSprite = transform.Find("GameStartPanel/StartSprite").gameObject;
        settingBtn.onClick.AddListener(ShowSettingPanel);
        returnBtn.onClick.AddListener(CloseSettingPanel);
        restoreDefaultBtn.onClick.AddListener(RestoreDefault);
        confirmBtn.onClick.AddListener(ModifyData);
        gameInfromarion = LoadJson();
        
    }
    public void ShowSettingPanel() {
        settingPanel.transform.DOMoveY(400, 1.5f);
        startSprite.SetActive(false);
    }
    public void CloseSettingPanel()
    {
        settingPanel.transform.DOMoveY(1082, 1.5f);
        startSprite.SetActive(true);
    }
    public void ModifyData()
    {
        GetData();
        gameInfromarion.value = settingData[0];
        gameInfromarion.asteroidDamage = settingData[1];
        gameInfromarion.asteroidSpeed = settingData[2];
        gameInfromarion.startScore = settingData[3];
        gameInfromarion.easyGameWinScore = settingData[4];
        gameInfromarion.spawnWait = settingData[5];
        SaveJson();
        CloseSettingPanel();
    }
    public void RestoreDefault()
    {
        gameInfromarion.value = 10;
        gameInfromarion.asteroidDamage = 20;
        gameInfromarion.asteroidSpeed = 5;
        gameInfromarion.startScore = 100;
        gameInfromarion.easyGameWinScore = 200;
        gameInfromarion.spawnWait = 2;
        SaveJson();
        CloseSettingPanel();
    }
    private void GetData()
    {
        for(int i = 0; i < inputFields.Count; i++)
        {
            settingData.Add(int.Parse(inputFields[i].GetComponent<Text>().text));
        }
    }
    private GameInfromarion LoadJson()
    {
        string path = Application.streamingAssetsPath + "\\Json\\GameInformation.txt";
        string s = File.ReadAllText(path);
        GameInfromarion gameInfromarion = JsonMapper.ToObject<GameInfromarion>(s);
        return gameInfromarion;
    }
    private void SaveJson()
    {
        string path = Application.streamingAssetsPath + "\\Json\\GameInformation.txt";
        string s = JsonMapper.ToJson(gameInfromarion);
        File.WriteAllText(path, s);
    }
}
