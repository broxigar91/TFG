using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;



public class StatGrow : MonoBehaviour {

    [System.Serializable]
    public struct Values
    {
        public char range;
        public List<Vector2> growPoints;
        public int probability;
    }

    public List<Values> statGrow;

    public void Start()
    {
        string data = JsonUtility.
    }
}
