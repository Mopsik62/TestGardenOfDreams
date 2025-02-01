using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    public Item item;

    public void  RemoveItem()
    {
        InventoryManager.Instance.Remove(item);
        if (!item.stackable)
        {
            Destroy(gameObject);
        }
    }
    public void AddItem(Item newItem)
    {
        item = newItem;
    }
}
