using UnityEngine;

public class IntervalLevelUpper:ILevelUpper
{
    private GameObject gameObject;
    private float nowInterval;
 
    public IntervalLevelUpper()
    {
    }

    public void OnEnter()
    {
        nowInterval = GameManager.Instance.playerManager.Interval;
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
        }
    }

    public void OnEnd()
    {

    }
}
