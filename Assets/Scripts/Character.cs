using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
 public virtual float GetAttackDamage() { return 0; }
 
 public virtual void TakeDamage(float damage) { }
 
 public virtual void Attack() { }
}
