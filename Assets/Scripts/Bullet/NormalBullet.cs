using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : BulletBase
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Initialize(int power,Vector3 targetPos) {
        float angle = Vector3.Angle(this.transform.position,targetPos);
        transform.RotateAround(this.transform.position,this.transform.forward,angle);

    }
    public override void Move() {
        
    }
}
