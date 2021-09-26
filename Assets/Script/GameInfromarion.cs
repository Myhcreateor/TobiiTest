using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfromarion
{
        public int value;//消灭一个Asteroid获得积分数
        public int asteroidDamage;//Asteroid未击毁减少的分数
        public int asteroidSpeed;//Asteroid的下降速度
        public int startScore;//游戏开始的初始分数
        public int easyGameWinScore;//简单模式的游戏成功的分数条件
        public int difficultGameWinScore;//困难模式的游戏成功的分数条件
        public int spawnWait;//陨石掉落的间隔，默认简单模式是1，困难模式是1-random.range(0.3,0.6)
    public GameInfromarion()
    {
        value = 10;
        asteroidDamage = 20;
        asteroidSpeed = 6;
        startScore = 100;
        easyGameWinScore = 300;
        difficultGameWinScore = 500;
        spawnWait = 1;
    }
    public GameInfromarion(int value,int asteroidDamage,int asteroidSpeed,int startScore,int easyGameWinScore,int difficultGameWinScore,int spawnWait)
    {
        this.value = value;
        this.asteroidDamage = asteroidDamage;
        this.asteroidSpeed = asteroidSpeed;
        this.startScore = startScore;
        this.easyGameWinScore = easyGameWinScore;
        this.difficultGameWinScore = difficultGameWinScore;
        this.spawnWait = spawnWait;
    }
}
