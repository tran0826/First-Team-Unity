using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{

    [SerializeField] TowerType towerType = TowerType.Fire;
    [SerializeField] GameObject bulletPrefab;

    private ITowerMover currentTowerMover = null;

    // Start is called before the first frame update
    void Start()
    {
        if (towerType == TowerType.Fire)
        {
            currentTowerMover = new FireTowerMover(gameObject, bulletPrefab);
            currentTowerMover.OnEnter();
        }
        else if (towerType == TowerType.Water)
        {
            currentTowerMover = new WaterTowerMover(gameObject, bulletPrefab);
            currentTowerMover.OnEnter();
        }
        else {
            currentTowerMover = new WaterTowerMover(gameObject, bulletPrefab);
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

    public void OnClickAct()
    {
        Debug.Log("tower");
        GameManager.Instance.towerManager.Kill(gameObject);
        GameManager.Instance.destroyManager.AddDestroyList(gameObject);
    }

}
