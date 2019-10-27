using UnityEngine;

public class RoundEnemyMover : IEnemyMover
{
    private GameObject gameObject;
    private float speed;
    
    private GameObject nextObject;
    int nowObj=-1;

    private float targetAngle = 0;
    private float nowAngle = 0;

    

    public RoundEnemyMover(GameObject gameObject, float speed)
    {
        this.gameObject = gameObject;
        this.speed = speed;
        nextObject = GameManager.Instance.mapManager.NextObject(ref nowObj);
        var diff = gameObject.transform.position - nextObject.transform.position;
        var axis = Vector3.Cross(gameObject.transform.forward, diff);
        targetAngle = Vector3.Angle(new Vector3(0f, -1f, 0f), diff) * (axis.y < 0 ? -1 : 1);
    }

    public void OnEnter()
    {
        
    }

    public void OnUpdate()
    {
        speed = gameObject.GetComponent<EnemyController>().Speed;

        Vector3 distVec = gameObject.transform.position - nextObject.transform.position;
        float dist = distVec.magnitude;
        if (dist<10) {
            //Debug.Log(dist+":"+ nowObj);
            nextObject= GameManager.Instance.mapManager.NextObject(ref nowObj);
            
        }
        var diff = gameObject.transform.position - nextObject.transform.position;
        var axis = Vector3.Cross(gameObject.transform.forward, diff);
        targetAngle = Vector3.Angle(new Vector3(0f, -1f, 0f), diff) * (axis.y < 0 ? -1 : 1);
        if (targetAngle - nowAngle >= 180)
        {
            if (targetAngle > 0)
            {
                targetAngle -= 360;
            }
            else
            {
                nowAngle += 360;
            }
        }
        else if (targetAngle - nowAngle <= -180)
        {
            if (targetAngle < 0)
            {
                targetAngle += 360;
            }
            else
            {
                nowAngle -= 360;
            }
        }
        nowAngle += (targetAngle - nowAngle) * 0.1f * speed * (float)GameManager.Instance.timeManager.DeltaTime();
 //       nowAngle = targetAngle;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, nowAngle);
        gameObject.transform.Translate(0, speed * (float)GameManager.Instance.timeManager.DeltaTime(), 0);

    }

    public void OnEnd()
    {

    }
}
