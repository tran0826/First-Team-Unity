using UnityEngine;
using UnityEngine.Events;


public abstract class BulletBase : MonoBehaviour
{
    [SerializeField]
    private int power;
    [SerializeField]
    protected float speed;
    protected Vector3 direction;
    private Renderer bulletRenderer;

    private AudioSource audioSource;
    [SerializeField] private AudioClip sound;
    [SerializeField] private float volume;
    [SerializeField] protected GameObject hitEffect;

    public int Power { get { return power; } protected set { power = value; } }

    public virtual bool CanDestroyOnCollision { get; protected set; } = true;

    void Awake()
    {
        audioSource = GameManager.Instance.GetComponent<AudioSource>();
        audioSource.PlayOneShot(sound,volume);
        bulletRenderer = GetComponent<Renderer>();
    }

    public abstract void Move();

    void Update()
    {
        if (GameManager.Instance.timeManager.DeltaTime() == 0) {
            GameManager.Instance.destroyManager.AddDestroyList(this.gameObject);
        }
        Move();
        
    }
    public abstract void Initialize(int power);

    public virtual void OnTriggerEnter2D(Collider2D collider)
    {
        var enemy = collider.gameObject.GetComponent<EnemyController>();
        if (enemy != null)
        {
            GameManager.Instance.collisionManager.CollisionBulletToEnemy(enemy,this);
           
            return;
        }
    }
}
