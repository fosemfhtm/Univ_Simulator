using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public static GameManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    public int Money;
    public int Happiness;

    public int Logic;
    public int Memory;
    public int Intution;
    public int application;

    public List<string> SelectedLectureList;

    public int[] activatedCards = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
    public int playerHp = 1000;
    public int playerMaxHp = 1000;
    public int money = 100;
    public int enemyHp = 30;
    public int enemyMaxHp = 30;
    public int enemyReward = 0;

    public int sceneNumber = 0;
    public bool startFinal = false;

}