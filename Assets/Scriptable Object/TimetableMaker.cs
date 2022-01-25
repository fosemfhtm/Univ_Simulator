using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TimetableMaker : MonoBehaviour
{

    public List<string> SelectedLectureList;

    public List<GameObject> TableList;

    

    [SerializeField]
    private List<LectureData> lectureDatas;

    [SerializeField]
    private GameObject timetablePrefab;

    void Start()
    {
        LoadTimetable();
    }

    void Update()
    {

        if (SelectedLectureList.Count != GameManager.Instance.SelectedLectureList.Count)
        {
            Debug.Log(SelectedLectureList.Count);
            Debug.Log(GameManager.Instance.SelectedLectureList.Count);
            Debug.Log(TableList.Count);

            DestroyTimetable();
            TableList.Clear();
            LoadTimetable();
        }
    }

    void LoadTimetable()
    {
        SelectedLectureList = GameManager.Instance.SelectedLectureList.ToList();

        for (int i = 0; i < lectureDatas.Count; i++)
        {
            if (SelectedLectureList.Contains(lectureDatas[i].LectureCode))
            {
                float table_x1 = lectureDatas[i].Class1Day;
                float table_y1 = lectureDatas[i].Class1Time;
                float table_x2 = lectureDatas[i].Class2Day;
                float table_y2 = lectureDatas[i].Class2Time;

                var lectures = MakeTimetable((LectureList)i, table_x1,table_x2,table_y1,table_y2);

                string lecturecode = lectures[0].getLectureCode();

                lectures[0].GetComponent<Image>().sprite = Resources.Load("Table/" + lecturecode, typeof(Sprite)) as Sprite;
                lectures[1].GetComponent<Image>().sprite = Resources.Load("Table/" + lecturecode, typeof(Sprite)) as Sprite;
            }
            
        }
    }

    void DestroyTimetable()
    {
        for (int i = 0; i < TableList.Count; i++)
        {
            Destroy(TableList[i], 0.0f);
        }
    }

    List<Lecture> MakeTimetable(LectureList type, float x1, float x2, float y1, float y2)
    {
        x1 = x1 + 549.5f;
        y1 = y1 + 284.4f;
        x2 = x2 + 549.5f;
        y2 = y2 + 284.4f;

        var newLecture1 = Instantiate
            (timetablePrefab,
            new Vector3(x1, y1, 0),
            Quaternion.identity,
            GameObject.Find("Canvas").transform);
        newLecture1.GetComponent<Lecture>().LectureData = lectureDatas[(int)type];

        var newLecture2 = Instantiate
            (timetablePrefab,
            new Vector3(x2, y2, 0),
            Quaternion.identity,
            GameObject.Find("Canvas").transform);
        newLecture2.GetComponent<Lecture>().LectureData = lectureDatas[(int)type];

        List<Lecture> Lectures = new();

        Lectures.Add(newLecture1.GetComponent<Lecture>());
        Lectures.Add(newLecture2.GetComponent<Lecture>());

        TableList.Add(newLecture1);
        TableList.Add(newLecture2);

        return Lectures;
    }
}
