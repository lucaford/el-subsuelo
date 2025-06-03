using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float detectionRange = 10f;
    public float damage = 25f;
    public float timeBetweenAttacks = 1f;
    public int maxHits = 3;

    private Transform player;
    private NavMeshAgent agent;
    private int hitsReceived = 0;
    private float lastAttackTime = -999f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= detectionRange)
        {
            agent.SetDestination(player.position);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Time.time - lastAttackTime >= timeBetweenAttacks)
            {
                PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damage);
                    lastAttackTime = Time.time;
                }
            }
        }
    }

    public void TakeDamage()
    {
        hitsReceived++;

        if (hitsReceived >= maxHits)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}