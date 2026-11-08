using UnityEngine;

public class DemoSpawnButton : MonoBehaviour {
    //TODO: add collections to assembly reference
    public InventoryManager inventoryManager;
    public ItemData[] itemsToPickup;

    public void PickupItem(int id) {
        bool result = inventoryManager.AddItemToNextEmptySlot(itemsToPickup[id]);
        if (result == true) {
            Debug.Log("Item added");
        }
        else {
            Debug.Log("Item not added, INVENTORY IS FULL");
        }
    }

    public void GetSelectedItemForButton() {
        //InventoryItem itemSelected = InventoryManager.Instance.GetSelectedItem();
        bool itemIsInUse = false;
        ItemData receivedItem = inventoryManager.GetSelectedItem(itemIsInUse);
        if (receivedItem != null) {
            Debug.Log("RECEIVED ITEM: " + receivedItem);
        }
        else {
            Debug.Log("No item selected");
        }
    }

    public void UseSelectedItemForButton() {
        //InventoryItem itemSelected = InventoryManager.Instance.GetSelectedItem();
        bool itemIsInUse = true;
        ItemData receivedItem = inventoryManager.GetSelectedItem(itemIsInUse);
        if (receivedItem != null) {
            Debug.Log("USED ITEM: " + receivedItem);
        }
        else {
            Debug.Log("No item selected");
        }
    }

    public void UseSelectedInventoryItem() {
        //InventoryItem itemSelected = InventoryManager.Instance.GetSelectedItem();
        bool itemIsInUse = true;
        ItemData receivedItem = inventoryManager.GetSelectedItem(itemIsInUse);
        if (receivedItem != null) {
            Debug.Log("USED ITEM: " + receivedItem);
        }
        else {
            Debug.Log("No item selected");
        }
    }
}
