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
    private List<Texture2D> cursorFire;
    [SerializeField]
    private List<Texture2D> cursorWater;
    [SerializeField]
    private List<Texture2D> cursorThunder;
    [SerializeField]
    private List<Texture2D> cursorNormal;

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
        if (GameManager.Instance.towerManager.CountTower() < GameManager.Instance.sharedValue.TotalLevel+1)
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
            int level = GameManager.Instance.sharedValue.FireLevel;
            Cursor.SetCursor(cursorFire[level], new Vector2(cursorFire[level].width / 2, cursorFire[level].height / 2), CursorMode.ForceSoftware);
        }else if (installType == TowerType.Thunder)
        {
            int level = GameManager.Instance.sharedValue.ThunderLevel;
            Cursor.SetCursor(cursorThunder[level], new Vector2(cursorThunder[level].width / 2, cursorThunder[level].height / 2), CursorMode.ForceSoftware);
        }else if (installType == TowerType.Water)
        {
            int level = GameManager.Instance.sharedValue.WaterLevel;
            Cursor.SetCursor(cursorWater[level], new Vector2(cursorWater[level].width / 2, cursorWater[level].height / 2), CursorMode.ForceSoftware);
        }else if (installType == TowerType.Normal)
        {
            int level = GameManager.Instance.sharedValue.NormalLevel;
            Cursor.SetCursor(cursorNormal[level], new Vector2(cursorNormal[level].width / 2, cursorNormal[level].height / 2), CursorMode.ForceSoftware);
        }
    }

    public void ReturnCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
