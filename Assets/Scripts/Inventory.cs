using System.Collections.Generic;


public class Inventory
{
    public List<Item> items;

    public Inventory() {
        items = new List<Item>();
    }
    public List<Item> GetItems() {
        return items;
    }
    public int GetCount() {
        return items.Count;
    }
    public void AddItem(Item item) {
        items.Add(item);
    }
    public void RemoveItem(Item item) {
        items.Remove(item);
    }
    public void FlushInventory() {
        items.Clear();
    }
    public Item GetItem(int index) {
        return items[index];
    }
}
