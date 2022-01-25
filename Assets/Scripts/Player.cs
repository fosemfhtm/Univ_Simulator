using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHp;
    public int nowHp;
    public Image nowHpBar;
    public float height = 1.7f;

    public GameObject prfHpBar;
    public GameObject canvas;
    
    RectTransform hpBar;
    // Start is called before the first frame update
    void Start()
    {
        // hpBar = Instantiate(prfHpBar, canvas.transform).GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 _hpBarPos = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y+height, 0));
        // hpBar.position = _hpBarPos;
    }
}
