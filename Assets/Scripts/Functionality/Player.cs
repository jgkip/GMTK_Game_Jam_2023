using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private EntityData playerData;
    [SerializeField] private float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = playerData.healthPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            TakeDamage(collision.gameObject.GetComponent<EnemyFollow>().data.attackDamage);
        }
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void TakeDamage(float damageValue)
    {
        currentHealth -= damageValue;
    }
}
