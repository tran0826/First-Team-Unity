using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstallManager : MonoBehaviour
{

    [SerializeField]
    private GameObject appearRoot;

    public GameObject FireTower;

    private List<MapTile> installList = new List<MapTile>();

 //   private TowerType installType = TowerType.Fire;

    public void UpdateByFrame()
    {
        InstallTower();
        installList.Clear();
    }


    public void AddInstallTowerList(MapTile tile)
    {
        installList.Add(tile);
    }

    private void InstallTower()
    {
        foreach(var tile in installList)
        {
            tile.IsExistTower = true;
            Vector3 installPosition = tile.transform.position;
            installPosition.z = 0;
            Quaternion installRotate = new Quaternion();
            installRotate = Quaternion.identity;
            var instantiateGameObject = Instantiate(FireTower,installPosition,installRotate);
            instantiateGameObject.transform.SetParent(appearRoot.transform);
        }


    }

}
