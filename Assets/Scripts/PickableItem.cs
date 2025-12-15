using UnityEngine;

public class PickableItem : MonoBehaviour {
    [SerializeField] private InventoryManager inventoryManager; // todo: change from public
    public Item itemData;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
           // if (!inventoryManager.InventoryIsFull()) {
                InventoryManager.Instance.AddItemToNextEmptySlot(itemData);
                Destroy(gameObject);
           // }

        }
    }
}
