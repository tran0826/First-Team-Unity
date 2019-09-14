using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTowerType : MonoBehaviour
{
    [SerializeField]
    private TowerType towerType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickAct()
    {
        Debug.Log("chtngeTowerType Click");
        GameManager.Instance.installManager.InstallType = towerType;
    }
}
