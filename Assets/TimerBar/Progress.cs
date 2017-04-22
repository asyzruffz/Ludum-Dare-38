using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    public Image Bar;
    public float max_time = 10f;
    public float cur_time = 0f;

    void Start()
    {
        cur_time = max_time;
        InvokeRepeating("fillTime", 0.5f, 1f);
    }

    void fillTime()
    {
        cur_time -= 10f;
        float calc_time = cur_time / max_time;
        SetTime(calc_time);
    }

    void SetTime(float theTime)
    {
        Bar.fillAmount = theTime;
    }
}