using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static event Action<float> OnHealthChange; // for ui changes 
    [SerializeField] private EntityData playerData;
    [SerializeField] private float currentHealth;

    private void OnEnable()
    {
        HealthPack.OnHealthPickup += ReplenishHealth;
        IncreaseHealth.OnIncreaseMaxHealthPickup += IncreaseMaxHP;
        IncreaseDamage.OnDamagePickup += UpgradeDamage;
        IncreaseSpeed.OnSpeedPickup += UpgradeMobilitySpeed;

    }

    private void OnDisable()
    {
        HealthPack.OnHealthPickup -= ReplenishHealth;
        IncreaseHealth.OnIncreaseMaxHealthPickup -= IncreaseMaxHP;
        IncreaseDamage.OnDamagePickup -= UpgradeDamage;
        IncreaseSpeed.OnSpeedPickup -= UpgradeMobilitySpeed;
    }

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

    // TODO: still added to max health bug
    private void ReplenishHealth(float healthToAdd)
    {
        // Debug.Log("Health replenished event");
        if (currentHealth < playerData.healthPoints)
        {
            currentHealth += healthToAdd;
        }
        // OnHealthChange?.Invoke(healthToAdd);
    }

    private void IncreaseMaxHP(float increaseAmount)
    {
        //Debug.Log("Increase max hp event");
        playerData.healthPoints += increaseAmount;
    }

    private void UpgradeDamage(float multiplier)
    {
        //Debug.Log("Upgrade damage event");
        playerData.attackDamage *= multiplier;
    }

    private void UpgradeMobilitySpeed(float multiplier)
    {
        //Debug.Log("Upgrade speed event");
        playerData.movementSpeed *= multiplier;
    }

    private void TakeDamage(float damageValue)
    {
        currentHealth -= damageValue;
    }
}
