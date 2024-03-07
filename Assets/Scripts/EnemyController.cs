using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.TryGetComponent<PlayerController>(out PlayerController controller))
        {
            controller.KillPlayer();
        }
    }
}
