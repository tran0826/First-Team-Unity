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
    private int upLeftX;
    [SerializeField]
    private int upLeftY;


    private List<string[]> map;
    private List<IndexSequencePair> roadSequence;



    // Start is called before the first frame update
    void Awake()
    {
        CsvReader csvReader = new CsvReader();
        map = csvReader.ReadFile("map");
        roadSequence = new List<IndexSequencePair>();
        int width = (int)objTile.GetComponent<SpriteRenderer>().bounds.size.x;
        upLeftX += width / 2;
        upLeftY -= width / 2;
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
                    if (tile != "0")
                    {
                        IndexSequencePair pair = new IndexSequencePair(tile, instantiateGameObject);
                        roadSequence.Add(pair);
                    }
                }

                renderX += width;
            }
            renderX = upLeftX;
            renderY -= width;
        }
        roadSequence.Sort((a, b) => string.Compare(a.index , b.index));
    }

    public void UpdateByFrame()
    {

    }

    public GameObject NextObject(ref int nowObj)
    {
        if (nowObj + 1 != roadSequence.Count)
        {
            nowObj++;
        }

        return roadSequence[nowObj].obj;
    }

    public class IndexSequencePair
    {
        public string index;
        public GameObject obj;

        public IndexSequencePair(string index, GameObject obj)
        {
            this.index=index;
            this.obj=obj;
        }
    }

}
