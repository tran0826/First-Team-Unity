using UnityEngine;
using UnityEngine.Events;

public enum Group
{
    Player,
    Enemy
}

public abstract class BulletBace : MonoBehaviour
{
    [SerializeField]
    private int power;
    [SerializeField]
    protected float speed;
    protected Vector3 direction;
    private Renderer bulletRenderer;

    [SerializeField] public Group group = Group.Enemy;
    public int Power { get { return power; } protected set { power = value; } }

    public virtual bool CanDestroyOnCollision { get; protected set; } = true;

    //public PowerType PowerType { get; protected set; }

    void Awake()
    {
        bulletRenderer = GetComponent<Renderer>();
    }

    public abstract void Move();

    void Update()
    {
        Move();
        UpdateRotation();

    }
    public abstract void Initialize(float ratio);

    private void UpdateRotation()
    {
        if (Vector3.Angle(this.transform.up, direction) < 5f) return;

        this.transform.rotation = Quaternion.FromToRotation(this.transform.up, direction);
    }

    public virtual void OnTriggerEnter2D(Collider2D collider)
    {
        /*
        var player = collider.gameObject.GetComponent<PlayerController>();
        if (player != null && group == Group.Enemy)
        {
            GameManager.Instance.collisionManager.CollisionBulletToPlayer(player, this);
            return;
        }

        */
        var enemy = collider.gameObject.GetComponent<EnemyController>();
        if (enemy != null && group == Group.Player)
        {
            GameManager.Instance.collisionManager.CollisionBulletToEnemy(enemy);
            return;

        }
    }
}
