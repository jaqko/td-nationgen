using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startlocation : MonoBehaviour
{
    public string decidedLocation = "None";
    void Start()
    {
        float number = Random.Range(0, 2);
        if (Mathf.RoundToInt(number) == 0)
            decidedLocation = "Newly Formed Island Nation";
        else if (Mathf.RoundToInt(number) == 1)
            decidedLocation = "Newly Formed Island Colony";
        else if (Mathf.RoundToInt(number) == 0)
            decidedLocation = "Newly Formed Island Rebellion";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
