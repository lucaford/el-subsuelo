using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed = 10f;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        rb.velocity = transform.forward * speed;
    }


    void OnTriggerEnter(Collider coll)
    {
        EnemyController enemy = coll.gameObject.GetComponent<EnemyController>();

        if (enemy != null)
        {
            enemy.TakeDamage();
        }

        Destroy(gameObject);
    }
}
