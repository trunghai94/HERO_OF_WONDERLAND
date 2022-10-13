using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    Items item;

    public Button RemoveButton;
    public void RemoveItem()
    {
        InventoryManager.Instance.Removed(item);

        Destroy(gameObject);
    }

    public void AddItem(Items newItem)
    {
        item = newItem;
    }
}
