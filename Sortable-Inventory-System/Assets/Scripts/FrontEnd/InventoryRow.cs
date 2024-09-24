using UnityEngine;

public class InventoryRow : MonoBehaviour
{
    public GameObject inventoryPanel;
    public InventoryPanel[] InitPanels(int row, int width)
    {
        int panelAmount = FindPanelAmount(row, width);
        InventoryPanel[] newPanelRow = new InventoryPanel[panelAmount];

        for (int i = 0; i < panelAmount; i++)
        {
            float starting = 100f - (transform.parent.GetComponentInParent<RectTransform>().rect.width / 2);
            float gap = 160f;
            GameObject newPanel = Instantiate(inventoryPanel);
            newPanel.transform.SetParent(transform);
            RectTransform rectTransform = newPanel.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(starting + (gap * i), 0, 0);
            rectTransform.localScale = new Vector3(1, 1, 1);
            newPanelRow[i] = newPanel.GetComponent<InventoryPanel>();
        }

        return newPanelRow;
    }

    public int FindPanelAmount(int row, int width)
    {
        int panelsTillEnd = PlayerInventory.inventory.Length - (row * width);
        Debug.Log(panelsTillEnd);
        if (panelsTillEnd > width) return width;
        return panelsTillEnd;
    }

}
