using UnityEngine;

public class RoundEnemyMover : IEnemyMover
{
    private GameObject gameObject;
    private float speed;
    private bool flag;
    private GameObject nextObject;
    int nowObj;

    private float targetAngle = 0;
    private float nowAngle = 0;

    public RoundEnemyMover(GameObject gameObject, float speed)
    {
        this.gameObject = gameObject;
        this.speed = speed;
        nowObj = -1;
        nextObject = GameManager.Instance.mapManager.NextObject(ref nowObj);
        var diff = gameObject.transform.position - nextObject.transform.position;
        var axis = Vector3.Cross(gameObject.transform.forward, diff);
        targetAngle = Vector3.Angle(new Vector3(0f, -1f, 0f), diff) * (axis.y < 0 ? -1 : 1);
        if (targetAngle > 180f) targetAngle -= 360f;
        Debug.Log(nowObj);
    }

    public void OnEnter()
    {
        flag = false;
    }

    public void OnUpdate()
    {
        Vector3 distVec = gameObject.transform.position - nextObject.transform.position;
        float dist = distVec.magnitude;
        if (dist<10) {
            Debug.Log(dist+":"+ nowObj);
            nextObject= GameManager.Instance.mapManager.NextObject(ref nowObj);
            var diff = gameObject.transform.position - nextObject.transform.position;
            var axis = Vector3.Cross(gameObject.transform.forward, diff);
            targetAngle = Vector3.Angle(new Vector3(0f, -1f, 0f), diff) * (axis.y < 0 ? -1 : 1);
            if (targetAngle > 180f) targetAngle -= 360f;
            Debug.Log(targetAngle + ":" + nowObj);
        }

        nowAngle += (targetAngle - nowAngle) * 0.5f;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, nowAngle);
        gameObject.transform.Translate(0, speed * (float)GameManager.Instance.timeManager.DeltaTime(), 0);

    }

    public void OnEnd()
    {

    }
}
