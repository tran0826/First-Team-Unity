using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    
    [SerializeField] private int experience;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private float interval;
    [SerializeField] private int power;
    [SerializeField] private int total;
    private Queue<GameObject> bornQueue = new Queue<GameObject>();
    private Queue<GameObject> deadQueue = new Queue<GameObject>();

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
    public int Experience
    {
        get { return experience; }
        set { experience = value; }
    }

    public void Born(GameObject born)
    {
        if (born.GetComponent<EnemyController>() != null)
        {
            bornQueue.Enqueue(born);
        }
    }
    public void Kill(GameObject kill)
    {
        if (kill.GetComponent<EnemyController>())
        {
            deadQueue.Enqueue(kill);
        }
    }
    private void BornQueueProcess()
    {
        while (0 < bornQueue.Count)
        {
            PlayerUnits.Add(bornQueue.Dequeue());
        }
    }
    private void KillQueueProcess()
    {
        while (0 < deadQueue.Count)
        {
            PlayerUnits.Remove(deadQueue.Dequeue());
        }
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
        BornQueueProcess();
        KillQueueProcess();
    }



    public void LevelUpdate()
    {

    }


}
