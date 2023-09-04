using System.Collections.Generic;
using UnityEngine;

public class ServicePool<T> : MonoSingletonGeneric<ServicePool<T>>where T : class
{
    private List<PooledItem<T>> pooledItems=new List<PooledItem<T>>();

    public virtual T GetItem()
    {
        if(pooledItems.Count> 0)
        {
            PooledItem<T> Item = pooledItems.Find(i => i.IsUsed==false);
            if(Item != null)
            {
                Debug.Log("Item is Used" + pooledItems.Count);
                Item.IsUsed = true;
                return Item.item;
            }
        }
        return CreateNewItem();
    }

    private T CreateNewItem()
    {
    
        Debug.Log("New Item is Created" + pooledItems.Count);
        PooledItem<T> newItem = new PooledItem<T>();
        newItem.item = CreateItem();
        newItem.IsUsed = true;
        pooledItems.Add(newItem);
        return newItem.item;
    }
    public virtual void ReturnItem(T _item)
    {
        Debug.Log("Item is Returned" + pooledItems.Count);
        PooledItem<T> UsedItem=pooledItems.Find(i=>i.item.Equals(_item));
        UsedItem.IsUsed = false;
    }
    protected virtual T CreateItem()
    {
        return (T)null;
    }

    private class PooledItem<T>
    {
        public T item;
        public bool IsUsed;
    }
}

