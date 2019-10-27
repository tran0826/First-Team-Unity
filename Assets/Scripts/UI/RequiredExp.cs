using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Common;

public class RequiredExp : MonoBehaviour
{
    [SerializeField]
    private LevelType levelType;

    private Text text;

    // Start is called before the first frame update
    void Awake()
    {
        text = gameObject.GetComponent<Text>();
        text.text = Define.PLAYER_LEVEL_UP_TABLE[0].ToString();
    }

    // Update is called once per frame
    void Update()
    {
        int nowLevel = Define.MAX_PLAYER_LEVEL;
        if (levelType == LevelType.Interval)
        {
            nowLevel = GameManager.Instance.sharedValue.IntervalLevel;
        }else if (levelType == LevelType.Power)
        {
            nowLevel = GameManager.Instance.sharedValue.PowerLevel;
        }else if (levelType == LevelType.Total)
        {
            nowLevel = GameManager.Instance.sharedValue.TotalLevel;
        }
        if (nowLevel == Define.MAX_PLAYER_LEVEL)
        {
            text.text = "-";
        }
        else
        {
            text.text = Define.PLAYER_LEVEL_UP_TABLE[nowLevel].ToString();
        }


    }
}
