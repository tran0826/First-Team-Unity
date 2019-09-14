using UnityEngine;
using UnityEngine.UI;

public class TotalLevelUpper : ILevelUpper
{
    private GameObject gameObject;
    private float nowTotal;
    private Text text;

    public TotalLevelUpper(GameObject gameObject)
    {
        this.gameObject = gameObject;
    }

    public void OnEnter()
    {
        nowTotal = GameManager.Instance.playerManager.Total;
        text = gameObject.GetComponent<Text>();
        text.text = "Total"+nowTotal.ToString();
    }

    public void OnUpdate()
    {


    }

    public void OnClick()
    {
        if (GameManager.Instance.playerManager.Experience >= 1 && GameManager.Instance.playerManager.Total <= 20)
        {
            GameManager.Instance.playerManager.Experience -= 1;
            GameManager.Instance.playerManager.Total += 1;
            nowTotal = GameManager.Instance.playerManager.Total;

            text.text = "Total"+nowTotal.ToString();
        }
    }

    public void OnEnd()
    {

    }
}
