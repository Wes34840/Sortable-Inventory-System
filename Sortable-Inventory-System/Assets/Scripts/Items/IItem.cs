using UnityEngine;

public class IItem
{
    public Sprite sprite;
    public string name, description;
    public bool isStackable, isValid;
    public int count;
    public IItem(bool isValid = true)
    {
        this.isValid = isValid;
    }
}
