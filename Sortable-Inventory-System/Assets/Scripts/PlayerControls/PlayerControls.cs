using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToggleInventory(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            InventoryVisualiser.toggleInventory.Invoke();
        }
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {

    }
}
