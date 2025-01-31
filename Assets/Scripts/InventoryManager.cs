using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem; //prefab

    public InventoryItemController[] InventoryItems;
    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        Items.Add(item);
        DisplayItem(item);
        SetInventoryItems();
    }
     
    public void Remove(Item item)
    {
        Items.Remove(item);
    }

    public void ListItems()
    {
        foreach (Transform item in ItemContent)
        {
            DestroyImmediate(item.gameObject);
        }
        foreach (var item in Items)
        {
            DisplayItem (item);
        }
        InventoryItems = new InventoryItemController[0];

        SetInventoryItems();
    }

    public void DisplayItem  (Item item)
    {
        GameObject obj = Instantiate(InventoryItem, ItemContent);
        var itemName = obj.transform.Find("ItemName").GetComponent<TMP_Text>();
        var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

        itemName.text = item.itemName;
        itemIcon.sprite = item.icon;
    }

    public void SetInventoryItems()
    {
       /* Debug.Log($"ItemContent has {ItemContent.transform.childCount} children");

        foreach (Transform child in ItemContent.transform)
        {
            Debug.Log($"Child: {child.name}, Active: {child.gameObject.activeSelf}, Instance ID: {child.GetInstanceID()}");
        }*/
        // InventoryItems = new InventoryItemController[0];
        InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>(false);
       // Debug.Log("Items count = " + Items.Count);
        for (int i =0; i < Items.Count; i++)
        {
            InventoryItems[i].AddItem(Items[i]);
          //  Debug.Log(i);
          //  Debug.Log(Items[i].name);
        }
    }
}
