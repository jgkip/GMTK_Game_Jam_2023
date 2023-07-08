using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public EntityData data;
    public static event Action<int> OnEnemyDeath;
    [SerializeField] private Transform target;
    [SerializeField] private float currentHealth;
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = data.healthPoints;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        // target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) < 0.5f)
        {
            TakeDamage(50);
        }
        transform.position = Vector2.MoveTowards(transform.position, target.position, data.movementSpeed * Time.deltaTime);
    }

    private void TakeDamage(float damageValue)
    {
        currentHealth -= damageValue;
    }

    private void Die()
    {
        if (currentHealth <= 0)
        {

            OnEnemyDeath?.Invoke(index);
            Destroy(gameObject);
        }
    }
}
