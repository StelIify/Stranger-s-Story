using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] int damage = 20;
    PlayerStats player;
    private void Awake()
    {
        player = FindObjectOfType<PlayerStats>();
    }
    
    
    public void AttackHitEvent()
    {
        if(player != null)
        {
            player.TakeDamage(damage);
            Debug.Log("Bang Bang");
        }
    }

    
}
