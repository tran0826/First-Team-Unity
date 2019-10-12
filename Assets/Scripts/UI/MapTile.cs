using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile : MonoBehaviour
{
    [SerializeField]TileType tileType;

    private bool isExistTower= false;
    private GameObject tower;

    /*
    public bool IsExistTower
    {
        get { return (tower!=null); }
        set { isExistTower = value; }
     
    }
    */

    public GameObject IsExistTower
    {
        get { return tower; }
        set { tower = value; }
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
        if (tileType != TileType.Road && tower == null&&GameManager.Instance.installManager.CanInstallTower())
        {
            GameManager.Instance.installManager.AddInstallTowerList(this);
            GameManager.Instance.installManager.ReturnCursor();
        }
        Debug.Log("map Click");
    }

    public void OnEnterAct()
    {
        if (tileType != TileType.Road && tower == null&&GameManager.Instance.installManager.CanInstallTower())
        {
            GameManager.Instance.installManager.ChangeCursor();
        }
    }

    public void OnExitAct()
    {
        if (tileType != TileType.Road && tower == null)
        {
            GameManager.Instance.installManager.ReturnCursor();
        }
    }
}
