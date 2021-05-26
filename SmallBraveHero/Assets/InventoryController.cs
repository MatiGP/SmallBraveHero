using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private float inventoryMoveXTreshold = 400f;
    [SerializeField] private float inventoryMoveXSpeed = 1.4f;
    [SerializeField] private Ease inventoryMoxeEase = Ease.InElastic;

    private bool isOpen = false;
    private InventoryControls inventoryControls;
    private float rootXPos = 0;
    private bool isOpening = false;

    void Awake()
    {
        inventoryControls = new InventoryControls();
        rootXPos = transform.position.x;
        inventoryControls.Inventory.OpenInventory.performed += OpenInventory_performed;
        inventoryControls.Inventory.OpenInventory.Enable();
    }

    private void OnDestroy()
    {
        inventoryControls.Inventory.OpenInventory.performed -= OpenInventory_performed;
        inventoryControls.Inventory.OpenInventory.Disable();
    }

    private void OpenInventory_performed(InputAction.CallbackContext context)
    {
        if (isOpening)
        {
            return;
        }

        isOpen = context.ReadValue<float>() > 0.9f && !isOpen;

        isOpening = true;

        OpenInventory(isOpen);
    }

    private void OpenInventory(bool isOpen)
    {

        Debug.Log("Boop");

        if (isOpen)
        {
            transform.DOMoveX(rootXPos + inventoryMoveXTreshold, inventoryMoveXSpeed).SetEase(inventoryMoxeEase).OnComplete(() => isOpening = false);
        }
        else
        {
            transform.DOMoveX(rootXPos - inventoryMoveXTreshold, inventoryMoveXSpeed).SetEase(inventoryMoxeEase).OnComplete(() => isOpening = false);
        }
    }

   
    
}
