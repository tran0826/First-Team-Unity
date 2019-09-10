using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile : MonoBehaviour
{
    [SerializeField]TileType tileType;

    private bool isExistTower= false;

    public bool IsExistTower
    {
        get { return isExistTower; }
        set { isExistTower = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickAct()
    {
        if (tileType != TileType.Road && isExistTower == false)
        {
            GameManager.Instance.installManager.AddInstallTowerList(this);
        }
        Debug.Log("map Click");
    }
}
