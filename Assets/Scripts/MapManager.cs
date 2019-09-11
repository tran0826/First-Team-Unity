using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    private GameObject appearRoot;

    [SerializeField]
    private GameObject mapTiles;// とりあえず

    private List<GameObject> roadSeaquence;




    // Start is called before the first frame update
    void Awake()
    {
        var instantiateGameObject = Instantiate(mapTiles);
        instantiateGameObject.transform.SetParent(appearRoot.transform);
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
