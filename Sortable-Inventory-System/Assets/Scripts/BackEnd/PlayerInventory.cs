using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static IItem[] inventory;
    public int inventorySize = 17;
    public int maxInventoryWidth = 6;

    public static Func<IItem, bool> pickUpItem;

    private void Start()
    {
        pickUpItem += PickUpItem;
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
        // Check item if it's stackable
        if (item.isStackable)
        {
            // If true check inventory if an item of the same type is already in the inventory 
            if (Array.Exists(inventory, i => i?.GetType() == item.GetType()))
            {
                // If true, find panel for item and add onto it
                int itemIndex = Array.IndexOf(inventory, item);

                inventory[itemIndex].count += item.count;
                InventoryVisualiser.AccessInventoryPanel(itemIndex).UpdateDisplay();
                return true;
            }

        }
        // if false, check inventory for the nearest empty panel
        int firstEmptySlot = 0;

        // If all spaces are already taken, return false
        for (int i = 0; i <= inventory.Count(); i++)
        {
            // If there's a single null 
            if (inventory[i] == null)
            {
                firstEmptySlot = i;
                break;
            }

            // If no slot is available
            if (i == inventory.Count() - 1)
            {
                return false;
            }

        }

        // Otherwise, assign the item to the first open slot
        inventory[firstEmptySlot] = item;
        InventoryVisualiser.AccessInventoryPanel(firstEmptySlot).SetItem(item);
        return true;
    }

}
