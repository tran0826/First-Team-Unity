using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{

    public LevelType levelType;

    private ILevelUpper currentLevelUpper = null;

    // Start is called before the first frame update
    void Start()
    {
        if (levelType == LevelType.Interval)
        {
            currentLevelUpper = new IntervalLevelUpper(this.gameObject);
            currentLevelUpper.OnEnter();
        }else if (levelType == LevelType.Power)
        {
            currentLevelUpper = new PowerLevelUpper(this.gameObject);
            currentLevelUpper.OnEnter();
        }else if (levelType == LevelType.Total)
        {
            currentLevelUpper = new TotalLevelUpper(this.gameObject);
            currentLevelUpper.OnEnter();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLevelUpper != null)
        {
            currentLevelUpper.OnUpdate();
        }
    }
    public void onClickAct()
    {
        if (currentLevelUpper != null)
        {
            Debug.Log("Click Level");

            currentLevelUpper.OnClick();
        }
    }
}
