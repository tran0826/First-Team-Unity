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
//            Instantiate(FireTower, tile.transform);
            tile.IsExistTower = true;

            var instantiateGameObject = Instantiate(FireTower,tile.transform);
            instantiateGameObject.transform.SetParent(appearRoot.transform);
        }


    }

}
