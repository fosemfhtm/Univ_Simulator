using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lecture : MonoBehaviour
{
    [SerializeField]
    private LectureData lectureData;
    public LectureData LectureData { set { lectureData = value; } }

    public void WatchLectureInfo() {
        Debug.Log("강의 이름 :: " + lectureData.LectureName);
        Debug.Log("강의 코드 :: " + lectureData.LectureCode);
    }

    public string getLectureCode()
    {
        return lectureData.LectureCode;
    }
}
