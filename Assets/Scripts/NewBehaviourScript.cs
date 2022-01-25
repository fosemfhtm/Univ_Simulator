using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // SceneManager.LoadScene("SecondScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClicked(){
        GameManager.instance.sceneNumber++;
        SceneManager.LoadScene(GameManager.instance.sceneNumber);
    }
}
