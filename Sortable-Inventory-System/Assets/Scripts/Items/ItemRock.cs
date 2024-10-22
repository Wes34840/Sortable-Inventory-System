using UnityEngine;

public class ItemRock : IItem
{
    public ItemRock()
    {
        sprite = Resources.Load<Sprite>("Sprites/RockIcon");
        name = "Stone";
        description = "T'is a rock";
        isStackable = false;
    }
}
