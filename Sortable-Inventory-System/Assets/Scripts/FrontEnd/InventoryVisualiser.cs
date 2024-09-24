using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryVisualiser : MonoBehaviour
{
    public GameObject rowHolder;
    public CanvasGroup canvasGroup;
    public bool isOpen;

    public static List<InventoryPanel> panels;

    public delegate void InitInventoryDelegate(int maxWidth);
    public static InitInventoryDelegate initInventory;
    public delegate void ToggleInventoryDelegate();
    public static ToggleInventoryDelegate toggleInventory;

    private void Start()
    {
        initInventory = InitInventory;
        toggleInventory = ToggleInventory;
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void InitInventory(int maxWidth)
    {
        panels = new List<InventoryPanel>();
        for (int i = 0; i < (PlayerInventory.inventory.Length / maxWidth) + 1; i++)
        {
            GameObject newHolder = Instantiate(rowHolder);

            float starting = -125f + (GetComponentInChildren<RectTransform>().rect.height / 2);
            float gap = -160f;

            newHolder.transform.SetParent(transform.GetChild(0));
            RectTransform rectTransform = newHolder.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(0, starting + (gap * i), 0);
            rectTransform.localScale = new Vector3(1, 1, 1);
            InventoryPanel[] newPanelRow = newHolder.GetComponent<InventoryRow>().InitPanels(i, maxWidth);

            panels.AddRange(newPanelRow);
        }

    }

    public void ToggleInventory()
    {
        isOpen = !isOpen;
        canvasGroup.alpha = Convert.ToInt32(isOpen);
        canvasGroup.blocksRaycasts = isOpen;
    }

    public static InventoryPanel AccessInventoryPanel(int index)
    {
        return panels[index];
    }
}
