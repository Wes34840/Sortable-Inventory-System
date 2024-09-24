using UnityEngine;

public class ItemWood : IItem
{
    public ItemWood()
    {
        sprite = Resources.Load<Sprite>("Sprites/LumberIcon.png");
        name = "wood";
        description = "LUMBER";
        isStackable = true;
    }
}
