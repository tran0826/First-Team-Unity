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

        gameObject.transform.Translate(0, speed * (float)GameManager.Instance.timeManager.DeltaTime(), 0);

    }

    public void OnEnd()
    {

    }
}
