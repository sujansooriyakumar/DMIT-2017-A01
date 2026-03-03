using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Dictionary<InventoryItemSO, InventoryItemData> inventory = new Dictionary<InventoryItemSO, InventoryItemData>();
    public InventoryItemSO tmp;

    private void Start()
    {
        AddItem(tmp);
        AddItem(tmp);

        Debug.Log(inventory[tmp].quantity);
    }
    public void AddItem(InventoryItemSO itemToAdd_)
    {
        if(!inventory.TryAdd(itemToAdd_, itemToAdd_.CreateRuntimeData())){
            inventory[itemToAdd_].quantity++;
        }
    }

    public void RemoveItem(InventoryItemSO itemToRemove_)
    {
        //if(inventory.TryGetValue(itemToRemove_, out ))
        if (inventory[itemToRemove_].quantity > 1)
        {
            inventory[itemToRemove_].quantity--;
            return;
        }
        inventory.Remove(itemToRemove_);
    }
}
