using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public ScrollRect Inventory;

    // Update is called once per frame
    void Update()
    {
        InventoryButton();
    }

    private void InventoryButton()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            InventoryManager.Instance.ListItems();
            Inventory.gameObject.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void ClosedButtonInventory()
    {
        Inventory.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
