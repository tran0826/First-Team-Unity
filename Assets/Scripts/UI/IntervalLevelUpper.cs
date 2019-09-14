﻿using UnityEngine;
using UnityEngine.UI;

public class IntervalLevelUpper:ILevelUpper
{
    private GameObject gameObject;
    private float nowInterval;
    private Text text;
 
    public IntervalLevelUpper(GameObject gameObject)
    {
        this.gameObject = gameObject;
    }

    public void OnEnter()
    {
        nowInterval = GameManager.Instance.playerManager.Interval;
        text = gameObject.GetComponent<Text>();
        text.text ="Interval"+ nowInterval.ToString();
    }

    public void OnUpdate()
    {


    }

    public void OnClick()
    {
        if (GameManager.Instance.playerManager.Experience >= 1&&GameManager.Instance.playerManager.Interval>=0.1f)
        {
            GameManager.Instance.playerManager.Experience -= 1;
            GameManager.Instance.playerManager.Interval *= 0.9f;
            nowInterval = GameManager.Instance.playerManager.Interval;
            text.text = "Interval"+nowInterval.ToString();
        }
    }

    public void OnEnd()
    {

    }
}