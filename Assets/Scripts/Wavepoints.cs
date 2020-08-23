using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wavepoints : MonoBehaviour {

    public static Transform[] points;

    private void Awake()
    {
        points = new Transform[transform.childCount];
        //creates new array of wavepoints

        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
            //sets each in thing in the array a wavepoint
        }
    }
}
