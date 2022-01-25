using UnityEngine;

[CreateAssetMenu(fileName = "Lecture Data", menuName = "Scriptable Object/Lecture Data", order = int.MaxValue)]
public class LectureData : ScriptableObject
{
    [SerializeField]
    private string lectureName;
    public string LectureName { get { return lectureName; } }

    [SerializeField]
    private string lectureCode;
    public string LectureCode { get { return lectureCode; } }

    [SerializeField]
    private float class1Time;
    public float Class1Time { get { return class1Time; } }

    [SerializeField]
    private float class1Day;
    public float Class1Day { get { return class1Day; } }

    [SerializeField]
    private float class2Time;
    public float Class2Time { get { return class2Time; } }

    [SerializeField]
    private float class2Day;
    public float Class2Day { get { return class2Day; } }

    private string rewardCard1;
    private string rewardCard2;
    private string rewardCard3;
    private string department;
}

