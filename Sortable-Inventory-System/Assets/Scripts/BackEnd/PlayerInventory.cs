using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static IItem[] inventory;
    public int inventorySize = 17;
    public int maxInventoryWidth = 6;

    public delegate bool PickUpItemDelegate(IItem item);
    public static PickUpItemDelegate pickUpItem;

    private void Start()
    {
        pickUpItem = PickUpItem;
        inventory = new IItem[inventorySize];
        StartCoroutine(WaitUntilEndOfFrame());
    }

    public IEnumerator WaitUntilEndOfFrame()
    {
        yield return new WaitForEndOfFrame();
        InventoryVisualiser.initInventory.Invoke(maxInventoryWidth);
    }

    public bool PickUpItem(IItem item)
    {
        InventoryPanel panel = null;

        for (int i = 0; i < inventory.Length; i++)
        {

            if (inventory.Contains(item))
            {
                panel = InventoryVisualiser.AccessInventoryPanel(Array.IndexOf(inventory, item));
                break;
            }

        }

        if (panel == null || !item.isStackable)
        {
            if (inventory.Contains(null)) return false;
            int index = Array.FindIndex(inventory, i => !i.isValid);
            inventory[index] = item;
            InventoryVisualiser.AccessInventoryPanel(index).SetItem(inventory[index]);
            return true;
        }
        panel.AddItem(item.count);
        return true;
    }


}
