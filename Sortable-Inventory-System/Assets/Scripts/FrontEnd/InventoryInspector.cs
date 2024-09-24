using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryInspector : MonoBehaviour
{

    public Image itemImage;
    public TMP_Text itemCounter, textFieldName, textFieldDescription;

    public delegate void OnItemSelectDelegate(IItem item);
    public static OnItemSelectDelegate showSelectedItem;

    public delegate void OnItemDeselectDelegate();
    public static OnItemDeselectDelegate emptyInspector;

    private void Start()
    {
        showSelectedItem = ShowSelectedItem;
        emptyInspector = EmptyInspector;

    }

    private void ShowSelectedItem(IItem item)
    {
        itemImage.sprite = item.sprite;
        if (item.isStackable)
        {
            itemCounter.gameObject.SetActive(true);
            itemCounter.text = item.count.ToString();
        }

        textFieldName.text = item.name;
        textFieldDescription.text = item.description;
    }

    private void EmptyInspector()
    {
        itemImage.sprite = itemImage.sprite;
        itemCounter.gameObject.SetActive(false);
        textFieldName.text = "";
        textFieldDescription.text = "";
    }

}
