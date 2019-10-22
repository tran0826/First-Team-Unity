using UnityEngine;
using UnityEngine.UI;

public class TotalLevelUpper : ILevelUpper
{
    private GameObject gameObject;
    private float nowTotal;
    
    public TotalLevelUpper(GameObject gameObject)
    {
        this.gameObject = gameObject;
    }

    public void OnEnter()
    {
        nowTotal = GameManager.Instance.playerManager.Total;
      
    }

    public void OnUpdate()
    {


    }

    public bool OnClick()
    {
        if (GameManager.Instance.playerManager.Experience >= 1 && GameManager.Instance.playerManager.Total <= 20)
        {
            GameManager.Instance.playerManager.Experience -= 1;
            GameManager.Instance.playerManager.Total += 1;
            nowTotal = GameManager.Instance.playerManager.Total;
            return true;
        }
        return false;
    }

    public void OnEnd()
    {

    }
}
