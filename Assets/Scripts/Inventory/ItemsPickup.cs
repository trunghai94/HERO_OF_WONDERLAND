using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsPickup : MonoBehaviour
{
    public Items items;
    
    void Pickup()
    {
        InventoryManager.Instance.Add(items);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Pickup();
        }
    }
    
}
