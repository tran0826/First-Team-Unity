using UnityEngine;
using UnityEngine.UI;

public class PowerLevelUpper : ILevelUpper
{
    private GameObject gameObject;
    private float nowPower;

    public PowerLevelUpper(GameObject gameObject)
    {
        this.gameObject = gameObject;
    }

    public void OnEnter()
    {
        nowPower = GameManager.Instance.playerManager.Power;
    }

    public void OnUpdate()
    {


    }

    public bool OnClick()
    {
        if (GameManager.Instance.playerManager.Experience >= 1 && GameManager.Instance.playerManager.Power <= 100)
        {
            GameManager.Instance.playerManager.Experience -= 1;
            GameManager.Instance.playerManager.Power +=1;
            nowPower = GameManager.Instance.playerManager.Power;
            return true;
        }
        return false;
    }

    public void OnEnd()
    {

    }
}
