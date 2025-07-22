using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ParametersScript : MonoBehaviour
{
    public static int scoreValue = 0;
    public static int healValue = 1000;
    public static int point = 0;
    public TextMeshProUGUI parameters;

    void Start()
    {
    }

    void Update()
    {
        parameters.text = "SCORE: " + scoreValue + "\nHEAL: " + healValue;
        Debug.Log(scoreValue);
    }
}
