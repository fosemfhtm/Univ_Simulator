using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLecture : MonoBehaviour
{

    private List<string> SelectedLectureList;

    public Fungus.Flowchart flowchart;

    public void ClickCalculus1()
    {
        Debug.Log("click MA101");

        if (GameManager.Instance.SelectedLectureList.Contains("MA101"))
        {
            GameManager.Instance.SelectedLectureList.Remove("MA101");
            flowchart.SetBooleanVariable("MA101", false);
        }
        else
        {
            GameManager.Instance.SelectedLectureList.Add("MA101");
            flowchart.SetBooleanVariable("MA101", true);
        }
        
    }

    public void ClickPhysics1()
    {
        Debug.Log("click PH101");

        if (GameManager.Instance.SelectedLectureList.Contains("PH101"))
        {
            GameManager.Instance.SelectedLectureList.Remove("PH101");
            flowchart.SetBooleanVariable("PH101", false);
        }
        else
        {
            GameManager.Instance.SelectedLectureList.Add("PH101");
            flowchart.SetBooleanVariable("PH101", true);
        }

    }

    public void ClickChemistry1()
    {
        Debug.Log("click CH101");

        if (GameManager.Instance.SelectedLectureList.Contains("CH101"))
        {
            GameManager.Instance.SelectedLectureList.Remove("CH101");
            flowchart.SetBooleanVariable("CH101", false);
        }
        else
        {
            GameManager.Instance.SelectedLectureList.Add("CH101");
            flowchart.SetBooleanVariable("CH101", true);
        }

    }

    public void ClickBiology()
    {
        Debug.Log("click BS101");

        if (GameManager.Instance.SelectedLectureList.Contains("BS101"))
        {
            GameManager.Instance.SelectedLectureList.Remove("BS101");
            flowchart.SetBooleanVariable("BS101", false);
        }
        else
        {
            GameManager.Instance.SelectedLectureList.Add("BS101");
            flowchart.SetBooleanVariable("BS101", true);
        }

    }

}
