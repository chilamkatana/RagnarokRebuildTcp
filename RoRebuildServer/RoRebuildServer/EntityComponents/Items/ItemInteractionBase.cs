﻿namespace RoRebuildServer.EntityComponents.Items;

public interface IItemLoader
{
    public void Load();
}

public class ItemInteractionBase
{
    public virtual void Init(Player player, CombatEntity combatEntity) { }

    public virtual bool OnUse(Player player, CombatEntity combatEntity)
    {
        return true;
    }
    
}