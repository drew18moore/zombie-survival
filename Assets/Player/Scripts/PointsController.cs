using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsController : MonoBehaviour
{
    [SerializeField] private float startingPoints = 500f;
    [SerializeField] private float points;

    [SerializeField] private TextMeshProUGUI pointsText;

    void Start()
    {
        points = startingPoints;
        pointsText.text = points.ToString();
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
            pointsText.text = points.ToString();
            print("POINTS UPDATED TO: " + points);
        }
    }
}
