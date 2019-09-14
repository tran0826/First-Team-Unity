using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    public enum LevelType
    {
        Interval,
        Total,
        Power
    }

    public LevelType levelType;

    private ILevelUpper currentLevelUpper = null;

    // Start is called before the first frame update
    void Start()
    {
        if (levelType == LevelType.Interval)
        {
            currentLevelUpper = new IntervalLevelUpper();
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
