using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstallManager : MonoBehaviour
{

    [SerializeField]
    private GameObject appearRoot;

    public GameObject FireTower;

    private List<MapTile> installList = new List<MapTile>();

    [SerializeField]
    private Texture2D cursorFire;

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
           
            Vector2 mousePos = Input.mousePosition;
            Camera gameCamera = Camera.main;
            Vector3 installPosition = gameCamera.ScreenToWorldPoint(mousePos);
            installPosition.z = 0;
            Quaternion installRotate = new Quaternion();
            installRotate = Quaternion.identity;
            var instantiateGameObject = Instantiate(FireTower,installPosition,installRotate);
            instantiateGameObject.transform.SetParent(appearRoot.transform);
        }


    }

    public void ChangeCursor()
    {
        Cursor.SetCursor(cursorFire, new Vector2(cursorFire.width / 2, cursorFire.height / 2), CursorMode.ForceSoftware);
    }

    public void ReturnCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
