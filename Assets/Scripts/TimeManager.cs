using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private bool isPause = false;
    public void Pause()
    {
        isPause = true;
    }
    public void Resume()
    {
        isPause = false;
    }

    public void UpdateByFrame()
    {
        if(GameManager.Instance!=null) GameManager.Instance.sharedValue.Time += DeltaTime();
  //      GameManager.Instance.sharedValue.Time += DeltaTime();

    }

    public double DeltaTime()
    {
        if (isPause)
        {
            return 0f;
        }
        else
        {
            return Time.deltaTime;
        }
    }

    public double PauseDeltaTime()
    {
        return Time.deltaTime;
    }

    public double AbsoluteTime()
    {
        return GameManager.Instance.sharedValue.Time;
    }
}
