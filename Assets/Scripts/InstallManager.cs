using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstallManager : MonoBehaviour
{

    [SerializeField]
    private GameObject appearRoot;

    public GameObject FireTower;
    public GameObject WaterTower;
    public GameObject ThunderTower;

    public GameObject SummonEffect;

    private List<MapTile> installList = new List<MapTile>();

    [SerializeField]
    private Texture2D cursorFire;
    [SerializeField]
    private Texture2D cursorWater;
    [SerializeField]
    private Texture2D cursorThunder;

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip summon;

    private TowerType installType = TowerType.None;
    public TowerType InstallType
    {
        get { return installType; }
        set { installType = value; }
    }

    public void UpdateByFrame()
    {
        InstallTower();
        installList.Clear();
    }


    public void AddInstallTowerList(MapTile tile)
    {
        installList.Add(tile);
    }

    public bool CanInstallTower()
    {
        if (GameManager.Instance.towerManager.CountTower() < GameManager.Instance.playerManager.Total)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void InstallTower()
    {
        foreach(var tile in installList)
        {
            if (installType == TowerType.None) continue;
       //     tile.IsExistTower = true;
           
            Vector2 mousePos = Input.mousePosition;
            Camera gameCamera = Camera.main;
            Vector3 installPosition = gameCamera.ScreenToWorldPoint(mousePos);
            installPosition.z = 0.5f;
            Quaternion installRotate = new Quaternion();
            installRotate = Quaternion.identity;
            Instantiate(SummonEffect, installPosition, installRotate);
            installPosition.z = 0;
            if (installType == TowerType.Fire)
            {
                var instantiateGameObject = Instantiate(FireTower, installPosition, installRotate);
                instantiateGameObject.transform.SetParent(appearRoot.transform);
                GameManager.Instance.towerManager.Born(instantiateGameObject);
                tile.IsExistTower = instantiateGameObject;
            }
            else if (installType == TowerType.Thunder)
            {
                var instantiateGameObject = Instantiate(ThunderTower, installPosition, installRotate);
                instantiateGameObject.transform.SetParent(appearRoot.transform);
                GameManager.Instance.towerManager.Born(instantiateGameObject);
                tile.IsExistTower = instantiateGameObject;
            }
            else if (installType == TowerType.Water)
            {
                var instantiateGameObject = Instantiate(WaterTower, installPosition, installRotate);
                instantiateGameObject.transform.SetParent(appearRoot.transform);
                GameManager.Instance.towerManager.Born(instantiateGameObject);
                tile.IsExistTower = instantiateGameObject;
            }
            installType = TowerType.None;
            audioSource.PlayOneShot(summon);
        }


    }

    public void ChangeCursor()
    {
        if (installType == TowerType.Fire)
        {
            Cursor.SetCursor(cursorFire, new Vector2(cursorFire.width / 2, cursorFire.height / 2), CursorMode.ForceSoftware);
        }else if (installType == TowerType.Thunder)
        {
            Cursor.SetCursor(cursorThunder, new Vector2(cursorFire.width / 2, cursorFire.height / 2), CursorMode.ForceSoftware);
        }else if (installType == TowerType.Water)
        {
            Cursor.SetCursor(cursorWater, new Vector2(cursorFire.width / 2, cursorFire.height / 2), CursorMode.ForceSoftware);
        }
    }

    public void ReturnCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
