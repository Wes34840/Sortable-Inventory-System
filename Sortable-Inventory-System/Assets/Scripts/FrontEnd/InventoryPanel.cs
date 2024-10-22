using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    private IItem currentItem;

    private Image panelImage;

    private void Awake()
    {
        panelImage = transform.GetChild(0).GetComponent<Image>();
    }

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
        UpdateDisplay();
    }

    public string RemoveItem(int amount)
    {
        if (amount > currentItem.count) return "Cannot complete action [Invalid count]";
        currentItem.count -= amount;
        UpdateDisplay();
        return "Success";
    }

    public void NullifyPanel()
    {
        currentItem = null;
        UpdateDisplay();
    }

    public void UpdateDisplay(Sprite sprite = null, string name = "", string description = "")
    {
        if (sprite == null)
        {
            sprite = Resources.Load<Sprite>("Sprites/logo");
        }
        panelImage.sprite = sprite;
        // panelName.text = name;
        // panelDescription.text = description;
    }

}
