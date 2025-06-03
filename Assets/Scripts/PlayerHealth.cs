using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Debug.Log("Player murió");
        }
    }
}
