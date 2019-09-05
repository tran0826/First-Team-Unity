using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    //[SerializeField]
    //private PowerType powerType;
    [SerializeField]
    private float maxInterval;
    [SerializeField]
    private float minInterval;
    [SerializeField]
    private int maxPower;

    private double lastShootSec;
    private float levelInterval;
    private int level;
    private bool isActive = false;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        lastShootSec = GameManager.Instance.timeManager.AbsoluteTime();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
