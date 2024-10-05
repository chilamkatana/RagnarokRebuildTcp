﻿using System;
using System.Collections.Generic;
using Assets.Scripts.Network;
using Assets.Scripts.Sprites;
using RebuildSharedData.ClientTypes;
using RebuildSharedData.Data;
using RebuildSharedData.Enum;
using UnityEditor;

namespace Assets.Scripts.PlayerControl
{
    public struct InventoryItem : IEquatable<InventoryItem>
    {
        public int BagSlotId;
        public ItemData ItemData;
        public ItemType Type;
        public RegularItem Item;
        public UniqueItem UniqueItem;

        public int Id => Type == ItemType.RegularItem ? Item.Id : UniqueItem.Id;

        public InventoryItem(RegularItem item)
        {
            BagSlotId = item.Id;
            Type = ItemType.RegularItem;
            Item = item;
            ItemData = ClientDataLoader.Instance.GetItemById(item.Id);
            UniqueItem = default;
        }

        public int Count
        {
            get => Type == ItemType.RegularItem ? Item.Count : UniqueItem.Count;
            set
            {
                if (Type == ItemType.RegularItem) 
                    Item.Count = (short)value; 
                else
                    UniqueItem.Count = (short)value; 
            }
        }

        public static InventoryItem Deserialize(ClientInboundMessage msg, ItemType type, int bagId)
        {
            if (type == ItemType.RegularItem)
                return DeserializeRegular(msg);
            else
                return DeserializeUnique(msg, bagId);
        }

        public static InventoryItem DeserializeRegular(ClientInboundMessage message)
        {
            var item = RegularItem.Deserialize(message);
            
            return new InventoryItem(item);
        }

        public static InventoryItem DeserializeUnique(ClientInboundMessage message, int bagSlotId)
        {
            var item = new InventoryItem
            {
                Type = ItemType.UniqueItem,
                UniqueItem = UniqueItem.Deserialize(message)
            };
            item.BagSlotId = bagSlotId;
            item.ItemData = ClientDataLoader.Instance.GetItemById(item.UniqueItem.Id);
            return item;
        }

        public bool Equals(InventoryItem other)
        {
            return BagSlotId == other.BagSlotId;
        }

        public override bool Equals(object obj)
        {
            return obj is InventoryItem other && Equals(other);
        }

        public override int GetHashCode()
        {
            return BagSlotId;
        }
    }
    
    public class ClientInventory
    {
        private readonly Dictionary<int, InventoryItem> inventoryLookup = new();

        public Dictionary<int, InventoryItem> GetInventoryData() => inventoryLookup;

        public int GetItemCount(int itemId)
        {
            if(inventoryLookup.TryGetValue(itemId, out var item))
                return item.Type == ItemType.RegularItem ? item.Item.Count : item.UniqueItem.Count;
            return 0;
        }

        public bool RemoveItem(int itemId, int count)
        {
            if (!inventoryLookup.TryGetValue(itemId, out var item))
                return false;

            if (item.Count <= count || item.Type == ItemType.UniqueItem)
                inventoryLookup.Remove(itemId);
            else
            {
                item.Count -= count;
                inventoryLookup[itemId] = item;
            }

            return true;
        }

        public void UpdateItem(InventoryItem item)
        {
            inventoryLookup[item.BagSlotId] = item;
        }
        
        public void Deserialize(ClientInboundMessage msg)
        {
            inventoryLookup.Clear();
            var hasBagData = msg.ReadByte();
            if (hasBagData == 0)
                return;
            var regularCount = msg.ReadInt32();
            for (var i = 0; i < regularCount; i++)
            {
                var item = InventoryItem.DeserializeRegular(msg);
                inventoryLookup.Add(item.Item.Id, item);
                // items.Add(item);
            }
            var uniqueCount = msg.ReadInt32();
            for (var i = 0; i < uniqueCount; i++)
            {
                var key = msg.ReadInt32();
                var item = InventoryItem.DeserializeUnique(msg, key);
                inventoryLookup.Add(key, item);
                // items.Add(item);
            }
        }
    }
}