using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTowerType : MonoBehaviour
{
    [SerializeField]
    private TowerType towerType;

    [SerializeField]
    private Sprite[] towerPreview;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int level = 0;
        if (towerType == TowerType.Fire)
        {
            level = GameManager.Instance.sharedValue.FireLevel;
        }else if (towerType == TowerType.Water)
        {
            level = GameManager.Instance.sharedValue.WaterLevel;
        }
        else if (towerType == TowerType.Thunder)
        {
            level = GameManager.Instance.sharedValue.ThunderLevel;
        }
        else if (towerType == TowerType.Normal)
        {
            level = GameManager.Instance.sharedValue.NormalLevel;
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = towerPreview[level];
    }

    public void OnClickAct()
    {
        Debug.Log("chtngeTowerType Click");
        GameManager.Instance.installManager.InstallType = towerType;
    }
}
