using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Common;

public class TowerRequiredExp : MonoBehaviour
{
    [SerializeField]
    private TowerType towerType;

    private Text text;

    // Start is called before the first frame update
    void Awake()
    {
        text = gameObject.GetComponent<Text>();
        text.text = Define.LEVEL_UP_TABLE[0].ToString();
    }

    // Update is called once per frame
    void Update()
    {
        int nowLevel = Define.MAX_LEVEL;
        if (towerType ==TowerType.Fire)
        {
            nowLevel = GameManager.Instance.sharedValue.FireLevel;
        }
        else if (towerType == TowerType.Water)
        {
            nowLevel = GameManager.Instance.sharedValue.WaterLevel;
        }
        else if (towerType == TowerType.Thunder)
        {
            nowLevel = GameManager.Instance.sharedValue.ThunderLevel;
        }else if (towerType == TowerType.Normal)
        {
            nowLevel = GameManager.Instance.sharedValue.NormalLevel;
        }


        if (nowLevel == Define.MAX_LEVEL)
        {
            text.text = "-";
        }
        else
        {
            text.text = Define.LEVEL_UP_TABLE[nowLevel].ToString();
        }


    }
}
