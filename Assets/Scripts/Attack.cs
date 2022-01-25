using System.Collections;
using System.Collections.Generic;
// using System.Windows.Forms;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    public Button attack5Btn, attack3Btn, defenseBtn;
    // Start is called before the first frame update
    void Start()
    {
        // attack5Btn.onClick.AddListener(() => { });
        // attack3Btn.onClick.AddListener(() => { Debug.Log("Attack 3 ");});
        // defenseBtn.onClick.AddListener(() => { Debug.Log("Defense ");});
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onClickAttack5Btn(){
        Debug.Log("Attack 5 ");
    }
    public void onClickAttack3Btn(){
        Debug.Log("Attack 3 ");
    }
    public void onClickDefenseBtn(){
        Debug.Log("Defense ");
    }
}
