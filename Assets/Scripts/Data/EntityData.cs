using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Entity Data", menuName = "Data/Entity Data")]
public class EntityData : ScriptableObject
{
    public float healthPoints;
    public float attackDamage;
    public float movementSpeed; 
}
