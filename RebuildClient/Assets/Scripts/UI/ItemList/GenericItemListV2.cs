﻿using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    [Flags]
    public enum ItemListDragSettings {
        None,
        CanDropItems = 1,
        CanDragItems = 2,
    }

    [Flags]
    public enum ItemListAcceptFrom
    {
        None,
        Inventory = 1,
        ItemList = 2,
        Cart = 4,
    }
    
    public class GenericItemListV2 : WindowBase
    {
        public ItemListInteractionDropZone DropZone;
        public GameObject ItemListEntryPrefab;
        public Transform ItemListParentBox;
        public ScrollRect ScrollRect;
        public Button OkButton;
        public Button CancelButton;
        public Toggle ToggleBox;
        public TextMeshProUGUI TitleBar;
        public TextMeshProUGUI InfoAreaText;
        public TextMeshProUGUI ToggleText;
        public TextMeshProUGUI OkButtonText;
        public TextMeshProUGUI CancelButtonText;

        public ItemListAcceptFrom AcceptDropsFrom;
        public ItemListDragSettings ItemListDragSettings;
        public bool ShowItemValues;
        public bool HasSubmitButtons;
        public bool HasToggleButton;
        
        [NonSerialized] public List<ItemListEntryV2> ItemListEntries;
        [NonSerialized] public Stack<ItemListEntryV2> UnusedEntries;
        [NonSerialized] public ItemListEntryV2 Selected;
        
        [NonSerialized] public ItemListRole CurrentRole;

        public Action<ItemListEntryV2> OnSelectEntry;
        public Action<ItemListEntryV2> OnUnselectEntry;
        public Action<ItemListEntryV2> OnStartDragEntry;
        public Action<ItemListEntryV2> OnDropEntry;
        public Func<bool> ValidateData;
        
        public Action OnPressOk;
        public Action OnPressCancel;
        
        public void OnSubmit()
        {
            OnPressOk();
        }

        public void OnCancel()
        {
            OnPressCancel();
        }

        public ItemListEntryV2 GetNewEntry()
        {
            if (UnusedEntries == null || !UnusedEntries.TryPop(out var entry))
            {
                var obj = Instantiate(ItemListEntryPrefab, ItemListParentBox);
                entry = obj.GetComponent<ItemListEntryV2>();
            }

            return entry;
        }

        public void Init()
        {
            OkButton.gameObject.SetActive(HasSubmitButtons);
            CancelButton.gameObject.SetActive(HasSubmitButtons);
            ToggleBox.gameObject.SetActive(HasToggleButton);
            ToggleText.gameObject.SetActive(HasToggleButton);
        }
        
        
    }
}