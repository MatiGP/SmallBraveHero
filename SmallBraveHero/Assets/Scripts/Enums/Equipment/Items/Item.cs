using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Equipment.Items
{
    public abstract class Item : ScriptableObject
    {
        [SerializeField] protected Sprite itemSprite;
        public Sprite ItemSprite { get => itemSprite; }

        [SerializeField] protected string itemName;
        public string ItemName { get => itemName; }

        public abstract void Use(Inventory inventory);
    }
    
    
}
