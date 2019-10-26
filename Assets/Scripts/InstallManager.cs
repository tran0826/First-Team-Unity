using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstallManager : MonoBehaviour
{

    [SerializeField]
    private GameObject appearRoot;


    public GameObject[] FireTower;
    public GameObject[] WaterTower;
    public GameObject[] ThunderTower;
    public GameObject[] NormalTower;
    

    public GameObject SummonEffect;

    private List<MapTile> installList = new List<MapTile>();

    [SerializeField]
    private Texture2D cursorFire;
    [SerializeField]
    private Texture2D cursorWater;
    [SerializeField]
    private Texture2D cursorThunder;

    [SerializeField]
    private AudioClip summon;
    [SerializeField]
    private AudioClip summonVoice;

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
                int level = GameManager.Instance.sharedValue.FireLevel;
                var instantiateGameObject = Instantiate(FireTower[level], installPosition, installRotate);
                instantiateGameObject.transform.SetParent(appearRoot.transform);
                GameManager.Instance.towerManager.Born(instantiateGameObject);
                tile.IsExistTower = instantiateGameObject;
            }
            else if (installType == TowerType.Thunder)
            {
                int level = GameManager.Instance.sharedValue.ThunderLevel;
                var instantiateGameObject = Instantiate(ThunderTower[level], installPosition, installRotate);
                instantiateGameObject.transform.SetParent(appearRoot.transform);
                GameManager.Instance.towerManager.Born(instantiateGameObject);
                tile.IsExistTower = instantiateGameObject;
            }
            else if (installType == TowerType.Water)
            {
                int level = GameManager.Instance.sharedValue.WaterLevel;
                var instantiateGameObject = Instantiate(WaterTower[level], installPosition, installRotate);
                instantiateGameObject.transform.SetParent(appearRoot.transform);
                GameManager.Instance.towerManager.Born(instantiateGameObject);
                tile.IsExistTower = instantiateGameObject;
            }else if (installType == TowerType.Normal)
            {
                int level = GameManager.Instance.sharedValue.NormalLevel;
                var instantiateGameObject = Instantiate(NormalTower[level], installPosition, installRotate);
                instantiateGameObject.transform.SetParent(appearRoot.transform);
                GameManager.Instance.towerManager.Born(instantiateGameObject);
                tile.IsExistTower = instantiateGameObject;

            }
            installType = TowerType.None;
            GameManager.Instance.GetComponent<AudioSource>().PlayOneShot(summon);
            GameManager.Instance.GetComponent<AudioSource>().PlayOneShot(summonVoice);
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
