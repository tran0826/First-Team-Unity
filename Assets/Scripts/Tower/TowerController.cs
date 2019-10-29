using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{

    [SerializeField] TowerType towerType = TowerType.Fire;
    [SerializeField] GameObject bulletPrefab;

    private AudioSource audioSource;
    [SerializeField] AudioClip sound;

    private ITowerMover currentTowerMover = null;
    private bool WillDestroy = false;
    private float DestroyTime = 0;
    private float alpha = 1f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameManager.Instance.GetComponent<AudioSource>();
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


    /*
     
        else if(towerType == TowerType.Thunder){
            currentTowerMover = new ThunderTowerMover(gameObject, bulletPrefab);
            currentTowerMover.OnEnter();
        }else{
            currentTowerMover = new NormalTowerMover(gameObject, bulletPrefab);
            currentTowerMover.OnEnter();
        }
     */

    // Update is called once per frame
    void Update()
    {
        if (currentTowerMover != null)
        {
            currentTowerMover.OnUpdate();
        }
        if (WillDestroy)
        {
            DestroyTime +=(float) GameManager.Instance.timeManager.PauseDeltaTime();
            alpha = 1f - DestroyTime*2;
            this.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, alpha);
            if (DestroyTime > 0.5f)
            {
                GameManager.Instance.towerManager.Kill(gameObject);
                GameManager.Instance.destroyManager.AddDestroyList(gameObject);
            }
           
        }

    }



    public void OnClickAct()
    {
        Debug.Log("tower");
        WillDestroy = true;
        audioSource.PlayOneShot(sound,0.1f);
    }

}
