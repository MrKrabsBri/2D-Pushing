using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    public bool isOpened = false;
    public Item itemData1;
    public Item itemData2;
    //public string[] rewards = { "a", "b" };
    //public List<Item> rewardsList = new List<Item> {itemData1, itemData2};
    public List<Item> rewardsList = new List<Item>();
    //public int randomDrop = Random.Range(0, rewardsList.);
    [SerializeField] private InventoryManager inventoryManager; // todo: change from public

    void Start() // Or OnEnable()
{
        rewardsList = new List<Item> { itemData1, itemData2 };
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.CompareTag("Player")){
            // Add the Item to inventory
            Item randomReward = rewardsList[Random.Range(0, rewardsList.Count)];

            InventoryManager.Instance.AddItemToNextEmptySlot(randomReward);
        }

    }

}
