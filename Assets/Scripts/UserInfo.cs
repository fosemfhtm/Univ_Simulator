using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UserInfo : MonoBehaviour
{
    public List<int> holdingCardInfo;
    private static UserInfo mainCharacter = null;
    // public int[] activatedCArd= {1, 1, 1, 1};
    // public int userHp = 50;
    // public int userMaxHp = 50;
    // public int money = 100;
    // public int enemyHp = 20;
    // public int enemyMaxHp = 20;
    // public int enemyReward = 0;
    public Image nowHpBar;
    public Image nowHpBar2;
    public GameObject prfHpBar;
    public GameObject prfHpBar2;
    public GameObject enemy;
    public GameObject userCharacter;
    public GameObject attackEffect;
    public GameObject hitEffect;

    private Text enemyHpTxt;
    private Text playerHpTxt;

    AudioSource audioSource;
    public AudioClip audioEnemy;
    public AudioClip audioPlayer;

    int attack = 0;
    int defense = 1;
    public int count = 0;
    public bool flag = false;
    int sceneCnt = 0;

    public Fungus.Flowchart flowchart;

    // Start is called before the first frame update
    void Awake()
    {
        this.audioSource = GetComponent<AudioSource>();
        if (null == mainCharacter)
        {
            mainCharacter = this;
            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public static UserInfo MainCharacter
    {
        get
        {
            if (null == mainCharacter)
            {
                return null;
            }
            return mainCharacter;
        }
    }
    void Start()
    {
        // this.audioSource = GetComponent<AudioSource>();
        attackEffect.SetActive(false);
        hitEffect.SetActive(false);
        enemyHpTxt = GameObject.Find("EnemyHp").GetComponent<Text>();
        playerHpTxt = GameObject.Find("PlayerHp").GetComponent<Text>();

        string curSceneName = SceneManager.GetActiveScene().name;
        if (curSceneName.Contains("Mid"))
        {
            if (GameManager.instance.startFinal) GameManager.instance.startFinal = false;
            attack = 1000;
            GameManager.instance.enemyMaxHp = 1000;
            GameManager.instance.enemyHp = GameManager.instance.enemyMaxHp;
        }
        else
        {
            if (!GameManager.instance.startFinal)
            {
                GameManager.instance.playerHp = GameManager.instance.playerMaxHp;
                GameManager.instance.startFinal = true;
            }
            attack = 2000;
            GameManager.instance.enemyMaxHp = 2000;
            GameManager.instance.enemyHp = GameManager.instance.enemyMaxHp;
        }

        enemyHpTxt.text = GameManager.instance.enemyMaxHp.ToString();
        playerHpTxt.text = GameManager.instance.playerHp.ToString();
        Debug.Log(GameManager.instance.playerMaxHp);
        // nowHpBar.fillAmount = (float)GameManager.instance.enemyHp/(float)GameManager.instance.enemyMaxHp;
        nowHpBar2.fillAmount = (float)GameManager.instance.playerHp / (float)GameManager.instance.playerMaxHp;
    }
    // Update is called once per frame
    void Update()
    {
        if (sceneCnt < 5)
        {
            defense = Convert.ToInt32(flowchart.Variables[7].ToString());
            sceneCnt++;
        }

        nowHpBar2.fillAmount = (float)GameManager.instance.playerHp / (float)GameManager.instance.playerMaxHp;
        enemyHpTxt.text = GameManager.instance.enemyHp.ToString();
        playerHpTxt.text = GameManager.instance.playerHp.ToString();
        if (GameManager.instance.enemyHp <= 0)
        {
            // SceneManager.LoadScene("StartScene");
             //GameManager.instance.enemyHp = 30;
            string curSceneName = SceneManager.GetActiveScene().name;
            if (curSceneName.Contains("Mid"))
            {
                //if (GameManager.instance.startFinal) GameManager.instance.startFinal = false;
                GameManager.instance.enemyHp = 1000;
            }
            else
            {
                GameManager.instance.enemyHp = 2000;
            }
            enemyHpTxt.text = "0";
            // flowchart.SetIntegerVariable("Stamina", GameManager.instance.userHp);
            Invoke("moveToNextScene", (float)1.5);
            // GameManager.instance.sceneNumber++;
            // SceneManager.LoadScene(GameManager.instance.sceneNumber);
        }
        if (GameManager.instance.playerHp <= 0)
        {
            //     Debug.Log("LOAD");
            //     flowchart.SetIntegerVariable('STAMINA', GameManager.instance.userHp);
            SceneManager.LoadScene(0);
        }
    }

    void moveToNextScene()
    {
        if (GameManager.instance.sceneNumber == 4)
        {
            GameManager.instance.sceneNumber++;
        }
        GameManager.instance.sceneNumber++;
        Debug.Log(GameManager.Instance.sceneNumber);
        SceneManager.LoadScene(GameManager.instance.sceneNumber);
    }
    public void hitEnemy(int a)
    {
        showHitEffect();
        audioSource.clip = audioPlayer;
        audioSource.Play();
        Invoke("hideHitEffect", 1);
        if (a < 0)
        { //heal player
            if (GameManager.instance.playerHp - a >= GameManager.instance.playerMaxHp)
            {
                GameManager.instance.playerHp = GameManager.instance.playerMaxHp;
            }
            else
            {
                GameManager.instance.playerHp -= a;
            }
            playerHpTxt.text = GameManager.instance.playerHp.ToString();
            nowHpBar2.fillAmount = (float)GameManager.instance.playerHp / (float)GameManager.instance.playerMaxHp;
        }
        else
        { //attack monster
            GameManager.instance.enemyHp -= a;
            enemyHpTxt.text = GameManager.instance.enemyHp.ToString();
            nowHpBar.fillAmount = (float)GameManager.instance.enemyHp / (float)GameManager.instance.enemyMaxHp;
        }
        // GameManager.instance.enemyHp -= a;
        // enemyHpTxt.text = GameManager.instance.enemyHp.ToString();
        // nowHpBar.fillAmount = (float)GameManager.instance.enemyHp/(float)GameManager.instance.enemyMaxHp;
        count++;
        if (count >= 3)
        {
            Invoke("MoveUp", 2);
        }
    }

    public void AttackedByEnemy()
    {
        GameManager.instance.playerHp -= (int)attack / defense;
        playerHpTxt.text = GameManager.instance.playerHp.ToString();
        nowHpBar2.fillAmount = (float)GameManager.instance.playerHp / (float)GameManager.instance.playerMaxHp;
        Debug.Log("Get Damage By Enemy");
        flag = true;
    }

    void MoveUp()
    {
        Vector3 position = enemy.transform.localPosition;
        position.y += 1;
        enemy.transform.localPosition = position;
        Invoke("MoveDown", (float)0.5);
    }

    void MoveDown()
    {
        Vector3 position = enemy.transform.localPosition;
        position.y -= 1;
        enemy.transform.localPosition = position;
        Invoke("MoveLR", 0);
    }

    void MoveLR()
    {
        // MoveLeft();
        showAttackEffect();
        audioSource.clip = audioEnemy;
        audioSource.Play();
        Invoke("hideAttackEffect", 1);
        Vector3 position = userCharacter.transform.localPosition;
        double pos = 0.1;
        position.x -= (float)pos;
        userCharacter.transform.localPosition = position;
        Invoke("MoveLeft", 0);
        Debug.Log("Move");
        Invoke("MoveLeft", (float)0.3);
        Debug.Log("Move2");
        Invoke("MoveLeft", (float)0.6);
        Debug.Log("Move3");
        // MoveLeft();
        // MoveLeft();
        // MoveLeft();
        // Thread.Sleep(10);
        // hideAttackEffect();
        position = userCharacter.transform.localPosition;
        // double pos = 0.1;
        position.x += (float)pos;
        userCharacter.transform.localPosition = position;
        Invoke("AttackedByEnemy", 0);
    }

    void MoveLeft()
    {
        Vector3 position = userCharacter.transform.localPosition;
        double pos = 0.2;
        position.x += (float)pos;
        userCharacter.transform.localPosition = position;
        // Thread.Sleep(1000);
        // MoveRight();
        Invoke("MoveRight", (float)0.2);
        Debug.Log("MoveLeft");
        // Invoke("AttackedByEnemy",0);
    }

    void MoveRight()
    {
        Vector3 position = userCharacter.transform.localPosition;
        double pos = 0.2;
        position.x -= (float)pos;
        userCharacter.transform.localPosition = position;
        Debug.Log("MoveRight");
        // Thread.Sleep(1000);
        // MoveCenter();
        // Invoke("MoveCenter",(float)0.1);
    }

    void showAttackEffect()
    {
        attackEffect.SetActive(true);
    }
    void hideAttackEffect()
    {
        attackEffect.SetActive(false);
    }

    void showHitEffect()
    {
        hitEffect.SetActive(true);
    }
    void hideHitEffect()
    {
        hitEffect.SetActive(false);
    }
}