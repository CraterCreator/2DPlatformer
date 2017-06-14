using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public int Time = 60;
    public GUIText TimeText;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(TimeDown());
    }
    IEnumerator TimeDown()

        //While the timer has more than -1 seconds every second 1 will be taken away
    {
        while (Time > -1)
        {
            UpdateTime();
            Time--;
            yield return new WaitForSeconds(1);
        }
    }

    void UpdateTime()
    {
        TimeText.text = "Time: " + Time;
    }
}
