using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{

    private float time;

    private int totalNum = 1;
    private int currentNum = 0;
    private List<TowerBase> towerList = new List<TowerBase>();
  

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }

    public void UpdateByFrame()
    {
    }


    /*
  

    
    public void CreateTower(TowerBase tower) {
        if (currentNum < totalNum)
        {
            towerList.Add(tower);
            currentNum++;
        }
        else {
            Destroy(tower);
        }
    }
    */


}
