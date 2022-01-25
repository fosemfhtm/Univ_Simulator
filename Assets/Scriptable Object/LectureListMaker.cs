using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum LectureList
{
    calculus1,
    physics1,
    chemistry1,
    biology
}

public class LectureListMaker : MonoBehaviour
{
    
    [SerializeField]
    private List<LectureData> lectureDatas;

    [SerializeField]
    private GameObject lecturePrefab;

    void Start() {

        for (int i = 0; i < lectureDatas.Count; i++) {
            var lecture = MakeLectureList((LectureList)i, i);
            string lecturecode = lecture.getLectureCode();
            lecture.GetComponent<SpriteRenderer>().sprite = Resources.Load("List/"+lecturecode, typeof(Sprite)) as Sprite;
            lecture.GetComponent<Button>().onClick.AddListener(AddLecture);
        }
    }

    public Lecture MakeLectureList(LectureList type, int i) {
        
        var newLecture = Instantiate (lecturePrefab, new Vector3(-8, 3-i, 0), Quaternion.identity)
            .GetComponent<Lecture>();
        newLecture.LectureData = lectureDatas[(int)type];

        return newLecture;
    }

    void AddLecture()
    {
        Debug.Log("add");
    }



}
