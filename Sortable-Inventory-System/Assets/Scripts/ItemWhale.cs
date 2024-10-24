using UnityEngine;
using UnityEngine.InputSystem;

public class ItemWhale : MonoBehaviour
{
    public void AddItemWood(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            bool isValid = PlayerInventory.pickUpItem(new ItemWood());
            if (isValid)
            {
                return;
            }
        }
    }
    public void AddItemRock(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            bool isValid = PlayerInventory.pickUpItem(new ItemRock());
            if (isValid)
            {
                return;
            }
        }
    }
}
