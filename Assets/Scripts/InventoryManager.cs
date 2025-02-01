using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using System.IO;


public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem; //prefab

    public InventoryItemController[] InventoryItems;

    private string savePath;
    public void Initialize()
    {
        Instance = this;
    }
 
    public void Add(Item item)
    {

        if (item.stackable)
        {
            bool exists = Items.Exists(i => i.itemName == item.itemName);
            Items.Add(item);
            if (!exists)
            {
                DisplayItem(item, 1);
            }
            else
            {
                UpdateStackableItem(item);
            }

        }
        else
        {
            Items.Add(item);
            DisplayItem(item, 0);
        }

        SetInventoryItems();

    }

    public void Remove(Item item)
    {
        Items.Remove(item);
        ListItems();
    }

    public void ListItems()
    {
        for (int i = ItemContent.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(ItemContent.GetChild(i).gameObject);
        }

        HashSet<string> processedItems = new HashSet<string>(); // "Черный список"

        foreach (var item in Items)
        {
            if (!processedItems.Contains(item.itemName)) // Проверяем, обрабатывали ли этот предмет
            {
                CheckStackable(item);
                if (item.stackable)
                {
                    processedItems.Add(item.itemName); // Добавляем в черный список
                }
            }
        }

        SetInventoryItems();
    }

    public void CheckStackable (Item item)
    {
        if (item.stackable)
        {
            
            int count = 0;
            foreach (var stackableItem in Items)
            {
                if (stackableItem.itemName == item.itemName)
                { count++; }
             //   Debug.Log("Настакано = " + count);
            }
          //  Debug.Log("Display item by CheckStackable");
            DisplayItem(item, count);
        }
        else
        {
            DisplayItem(item, 0);
        }
    }
    public void DisplayItem  (Item item, int quantity)
    {
        GameObject obj = Instantiate(InventoryItem, ItemContent);
        var itemName = obj.transform.Find("ItemName").GetComponent<TMP_Text>();
        var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
        var itemQuantity = obj.transform.Find("ItemQuantity").GetComponent<TMP_Text>();

        itemName.text = item.itemName;
        itemIcon.sprite = item.icon;
        if (quantity > 0)
        { itemQuantity.text = quantity.ToString(); }
    }

    public void UpdateStackableItem(Item item)
    {
        InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>(false);
        var existingItem = InventoryItems.FirstOrDefault(inventoryItem => inventoryItem.item.itemName == item.itemName);
        var itemQuantity = existingItem.transform.Find("ItemQuantity").GetComponent<TMP_Text>();
        itemQuantity.text = (int.Parse(itemQuantity.text) + 1).ToString();
    }

    public void SetInventoryItems()
    {
        //Debug.Log($"ItemContent has {ItemContent.transform.childCount} children");

/*        foreach (Transform child in ItemContent.transform)
        {
            Debug.Log($"Child: {child.name}, Active: {child.gameObject.activeSelf}, Instance ID: {child.GetInstanceID()}");
        }*/
        //InventoryItems = new InventoryItemController[0];
        InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>(false);
       // Debug.Log("Items count = " + Items.Count);

        int uniqueStackableCount = Items
        .Where(i => i.stackable) // Фильтруем только stackable-предметы
        .GroupBy(i => i.itemName) // Группируем по названию
        .Count(); // Считаем количество уникальных stackable-предметов
        int nonStackableCount = Items
         .Where(i => !i.stackable) // Фильтруем только не стакающиеся предметы
          .Count(); // Считаем количество таких предметов
        int uniqueCount = nonStackableCount + uniqueStackableCount;

       // Debug.Log("unique Items count = " + uniqueCount);

        for (int i =0; i < uniqueCount; i++)
        {
            InventoryItems[i].AddItem(Items[i]);
          //  Debug.Log(i);
           // Debug.Log(Items[i].name);
        }
    }

    public void SaveInventory (string path)
    {
        InventoryData data = new InventoryData();
        foreach (var item in Items)
        {
            data.itemIDs.Add(item.id);
        }

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);


        Debug.Log($"Инвентарь сохранен в: {path}");
    }
    public void LoadInventory(string path)
    {
        if (!File.Exists(path))
        {
            Debug.LogWarning($"Файл сохранения не найден: {path}");
            return;
        }
        string json = File.ReadAllText(path);
        InventoryData data = new InventoryData();
        data = JsonUtility.FromJson<InventoryData>(json);
        foreach (var id in data.itemIDs)
        {
            Item loadedItem = FindItemByID(id);
            if (loadedItem != null)
            {
                Items.Add(loadedItem);
            }
        }

        Debug.Log($"Инвентарь загружен из: {path}");

    }

    private Item FindItemByID(int id)
    {
        Item[] allItems = Resources.LoadAll<Item>("Items");

        foreach (var item in allItems)
        {
            if (item.id == id)
                return item;
        }
        Debug.LogWarning($"Предмет с ID {id} не найден!");
        return null;
    }
}
