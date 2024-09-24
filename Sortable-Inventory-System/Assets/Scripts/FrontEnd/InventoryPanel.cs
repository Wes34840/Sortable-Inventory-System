using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    private IItem currentItem;

    [SerializeField] private Image panelImage;
    public IItem GetItemPanel()
    {
        return currentItem;
    }

    public void SetItem(IItem item)
    {
        currentItem = item;
        UpdateDisplay(item.sprite, item.name, item.description);
    }

    public void AddItem(int amount)
    {
        currentItem.count += amount;
    }

    public string RemoveItem(int amount)
    {
        if (amount > currentItem.count) return "Cannot complete action [Invalid count]";
        currentItem.count -= amount;
        return "Success";
    }

    public void NullifyPanel()
    {
        currentItem = null;
        UpdateDisplay();
    }

    public void UpdateDisplay(Sprite sprite = null, string name = "", string description = "")
    {
        panelImage.sprite = sprite;
        // panelName.text = name;
        // panelDescription.text = description;
    }

}
