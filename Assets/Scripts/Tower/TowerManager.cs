using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    
    private HashSet<GameObject> TowerUnits = new HashSet<GameObject>();
    private Queue<GameObject> bornQueue = new Queue<GameObject>();
    private Queue<GameObject> deadQueue = new Queue<GameObject>();

    public void Born(List<GameObject> borns)
    {
        foreach (var born in borns)
        {
            Born(born);
        }
    }
    public void Born(GameObject born)
    {
        if (born.GetComponent<TowerController>() != null)
        {
            bornQueue.Enqueue(born);
        }
    }

    public void Kill(List<GameObject> kills)
    {
        foreach (var kill in kills)
        {
            Kill(kill);
        }
    }
    public void Kill(GameObject kill)
    {
        if (kill.GetComponent<TowerController>())
        {
            deadQueue.Enqueue(kill);
        }
    }

    private void BornQueueProcess()
    {
        while (0 < bornQueue.Count)
        {
            TowerUnits.Add(bornQueue.Dequeue());
        }
    }
    private void KillQueueProcess()
    {
        while (0 < deadQueue.Count)
        {
            TowerUnits.Remove(deadQueue.Dequeue());
        }
    }

    public int CountTower()
    {
        return TowerUnits.Count;
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

}
