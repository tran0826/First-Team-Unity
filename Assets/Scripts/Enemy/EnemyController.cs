using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public enum MoveType
    {
        Round,
        SkyStraight
    }

    [SerializeField] MoveType moveType;

    [SerializeField] float speed;
    [SerializeField] float minSpeed;

    //private
    private float time;
    [SerializeField] private int hp;
    [SerializeField] private int experience;
    [SerializeField] private float power;
    

    public int Hp {
        get { return hp; }
        set { hp = value; }
    }
    public int Experience
    {
        get { return experience; }
        set { experience = value; }
    }
    public float Power
    {
        get { return power; }
        set { power = value; }
    }

    private bool existAreaFlag = false;
    private IEnemyMover currentEnemyMover = null;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        if (moveType == MoveType.Round)
        {
            currentEnemyMover = new RoundEnemyMover(gameObject, speed);
            currentEnemyMover.OnEnter();
        }
        else if (moveType == MoveType.SkyStraight)
        {

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (currentEnemyMover != null)
        {
            currentEnemyMover.OnUpdate();
        }
        //time += (float)GameManager.Instance.timeManager.DeltaTime();
    }


    public void HitBullet(int damage)
    {
        if (ExistArea())
        {
            hp -= damage;
        }
    }

    public void SpeedDown(float ratio) {
        speed = Mathf.Lerp(minSpeed, speed, ratio);
    }

    public void EnterExistArea()
    {
        existAreaFlag = true;
    }
    
    public bool ExistArea() {
        return existAreaFlag;
    }

}
