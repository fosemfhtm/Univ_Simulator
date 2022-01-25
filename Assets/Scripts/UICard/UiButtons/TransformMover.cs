using UnityEngine;

namespace Tools.UI
{
    public class TransformMover : MonoBehaviour
    {
        public void MoveUp()
        {
            transform.localPosition += new Vector3(0, 1, 0);
            Debug.Log("moveup");
        }

        public void MoveDown()
        {
            transform.localPosition += new Vector3(0, -1, 0);
        }
    }
}