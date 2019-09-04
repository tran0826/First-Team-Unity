using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    
    [SerializeField] private int experience;
    private float interval;
    private int power;
    private int total;

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

    public float GetInterval()
    {
        return interval;
    }
    public int GetPower()
    {
        return power;
    }
    
    public int GetTotal() {
        return total;
    }



    public void LevelUpdate()
    {

    }


}
