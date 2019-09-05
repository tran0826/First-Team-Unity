using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    
    public BulletType bulletType = BulletType.Fire;

    [SerializeField] private BulletGenerator bulletGenerator;

    private void Awake()
    {
        bulletGenerator = GetComponent<BulletGenerator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.towerManager.Born(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
