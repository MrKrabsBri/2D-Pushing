using UnityEngine;

public class DemoSpawnButton : MonoBehaviour {
    public InventoryManager inventoryManager;
    public Item[] itemsToPickup;

    public void PickupItem(int id) {
        bool result = inventoryManager.AddItemToNextEmptySlot(itemsToPickup[id]);
        if (result == true) {
            Debug.Log("Item added");
        }
        else {
            //Debug.Log("INVENTORY IS FULL");
        }
    }

    public void GetSelectedItemForButton() {
        //InventoryItem itemSelected = InventoryManager.Instance.GetSelectedItem();
        bool itemIsInUse = false;
        Item receivedItem = inventoryManager.GetSelectedItem(itemIsInUse);
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
        Item receivedItem = inventoryManager.GetSelectedItem(itemIsInUse);
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
        Item receivedItem = inventoryManager.GetSelectedItem(itemIsInUse);
        if (receivedItem != null) {
            Debug.Log("USED ITEM: " + receivedItem);
        }
        else {
            Debug.Log("No item selected");
        }
    }
}
