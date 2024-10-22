using UnityEngine;

public class ItemWood : IItem
{
    public ItemWood(int count = 1)
    {
        sprite = Resources.Load<Sprite>("Sprites/LumberIcon");
        name = "wood";
        description = "Lorem Ipsum";
        isStackable = true;
        this.count = count;
    }
}
