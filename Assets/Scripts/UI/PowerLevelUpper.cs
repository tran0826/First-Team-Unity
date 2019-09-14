using UnityEngine;
using UnityEngine.UI;

public class PowerLevelUpper : ILevelUpper
{
    private GameObject gameObject;
    private float nowPower;
    private Text text;

    public PowerLevelUpper(GameObject gameObject)
    {
        this.gameObject = gameObject;
    }

    public void OnEnter()
    {
        nowPower = GameManager.Instance.playerManager.Power;
        text = gameObject.GetComponent<Text>();
        text.text = "Power"+nowPower.ToString();
    }

    public void OnUpdate()
    {


    }

    public void OnClick()
    {
        if (GameManager.Instance.playerManager.Experience >= 1 && GameManager.Instance.playerManager.Power <= 100)
        {
            GameManager.Instance.playerManager.Experience -= 1;
            GameManager.Instance.playerManager.Power +=1;
            nowPower = GameManager.Instance.playerManager.Power;
            text.text = "Power"+nowPower.ToString();
        }
    }

    public void OnEnd()
    {

    }
}
