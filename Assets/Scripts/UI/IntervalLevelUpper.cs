using UnityEngine;
using UnityEngine.UI;
using Common;

public class IntervalLevelUpper:ILevelUpper
{
    private GameObject gameObject;
 
    public IntervalLevelUpper(GameObject gameObject)
    {
        this.gameObject = gameObject;
    }

    public void OnEnter()
    {
        
    }

    public void OnUpdate()
    {


    }

    public bool OnClick()
    {
        int nowLevel = GameManager.Instance.sharedValue.IntervalLevel;
        if (nowLevel < Define.MAX_PLAYER_LEVEL && GameManager.Instance.playerManager.Experience >= Define.PLAYER_LEVEL_UP_TABLE[nowLevel])
        {
            GameManager.Instance.playerManager.Experience -= Define.PLAYER_LEVEL_UP_TABLE[nowLevel];
            GameManager.Instance.sharedValue.IntervalLevel += 1;
            return true;
        }
        return false;
    }

    public void OnEnd()
    {

    }
}
