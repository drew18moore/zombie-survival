using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    [SerializeField] private float startingPoints = 500f;
    [SerializeField] private float points;



    void Start()
    {
        points = startingPoints;
    }

    public float Points
    {
        get
        {
            return points;
        }
        set
        {
            points = value;
            print("POINTS UPDATED TO: " + points);
        }
    }
}
