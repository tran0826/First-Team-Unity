using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{

    [SerializeField] TowerType towerType = TowerType.Fire;

    private ITowerMover currentTowerMover = null;

    // Start is called before the first frame update
    void Start()
    {
        if (towerType == TowerType.Fire) {
            currentTowerMover = new FireTowerMover(gameObject);
            currentTowerMover.OnEnter();
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if (currentTowerMover != null)
        {
            currentTowerMover.OnUpdate();
        }
    }


}
