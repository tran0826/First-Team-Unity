using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    
    [SerializeField] private int experience;
    [SerializeField] private GameObject playerObject;
    private float interval;
    private int power;
    private int total;
    public float Interval
    {
        get { return interval; }
        set { interval = value; }
    }
    public int Total
    {
        get { return total; }
        set { total = value; }
    }
    public int Power
    {
        get { return power; }
        set { power = value; }
    }

    private HashSet<GameObject> PlayerUnits = new HashSet<GameObject>();

    public void Awake()
    {
        var player = Instantiate(playerObject);
        PlayerUnits.Add(player);
    }

    


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



    public void LevelUpdate()
    {

    }


}
