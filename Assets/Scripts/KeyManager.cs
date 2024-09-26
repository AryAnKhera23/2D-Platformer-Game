using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public bool isKeyCollected;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<PlayerController>(out PlayerController controller))
        {
            isKeyCollected = true;
            controller.PickUpKey();
            Destroy(gameObject);
        }
    }
}
