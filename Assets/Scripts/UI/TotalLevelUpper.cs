using UnityEngine;
using UnityEngine.UI;
using Common;

public class TotalLevelUpper : ILevelUpper
{
    private GameObject gameObject;
   
    public TotalLevelUpper(GameObject gameObject)
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
        int nowLevel = GameManager.Instance.sharedValue.TotalLevel;
        if (nowLevel < Define.MAX_PLAYER_LEVEL && GameManager.Instance.playerManager.Experience >= Define.PLAYER_LEVEL_UP_TABLE[nowLevel])
        {
            GameManager.Instance.playerManager.Experience -= Define.PLAYER_LEVEL_UP_TABLE[nowLevel];
            GameManager.Instance.sharedValue.TotalLevel += 1;
            return true;
        }
        return false;
    }

    public void OnEnd()
    {

    }
}
