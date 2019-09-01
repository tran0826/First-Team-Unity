using UnityEngine;

public class RoundEnemyMover : IEnemyMover
{
    private GameObject gameObject;
    private float speed;
    private bool flag;

    public RoundEnemyMover(GameObject gameObject, float speed)
    {
        this.gameObject = gameObject;
        this.speed = speed;
    }

    public void OnEnter()
    {
        flag = false;
    }

    public void OnUpdate()
    {
        //float deltaT = (float)GameManager.Instance.timeManage.DeltaTime();

        gameObject.transform.Translate(0, speed * 0.001f / 5, 0);

    }

    public void OnEnd()
    {

    }
}
