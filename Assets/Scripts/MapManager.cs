using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;
public class MapManager : MonoBehaviour
{
    [SerializeField]
    private GameObject appearRoot;

    [SerializeField]
    private GameObject roadTile;

    [SerializeField]
    private GameObject objTile;

    [SerializeField]
    private int width;

    [SerializeField]//敵が通るチェックポイントの数
    private int objNum;

    [SerializeField]
    private int upLeftX;
    [SerializeField]
    private int upLeftY;


    private List<string[]> map;
    private List<GameObject> roadSeaquence;//敵が通るチェックポイント




    // Start is called before the first frame update
    void Awake()
    {
        CsvReader csvReader = new CsvReader();
        map = csvReader.ReadFile("map");
        roadSeaquence = new List<GameObject>();
        int renderX = upLeftX;
        int renderY = upLeftY;
        foreach(string[] row in map)
        {
            foreach(string tile in row)
            {
                if (tile == "-1")
                {
                    Vector3 placePosition = new Vector3(renderX, renderY, 1);
                    Quaternion q = new Quaternion();
                    q = Quaternion.identity;
                    var instantiateGameObject = Instantiate(objTile,placePosition,q);
                    instantiateGameObject.transform.SetParent(appearRoot.transform);
                }
                else
                {
                    Vector3 placePosition = new Vector3(renderX, renderY, 1);
                    Quaternion q = new Quaternion();
                    q = Quaternion.identity;
                    var instantiateGameObject = Instantiate(roadTile, placePosition, q);
                    instantiateGameObject.transform.SetParent(appearRoot.transform);
                }


                renderX += width;
            }
            renderX = upLeftX;
            renderY += width;
        }
    }

    public void UpdateByFrame()
    {

    }

    public GameObject NextObject(ref int nowObj)
    {
        if (nowObj + 1 != roadSeaquence.Count)
        {
            nowObj++;
        }

        return roadSeaquence[nowObj];
    }
}
