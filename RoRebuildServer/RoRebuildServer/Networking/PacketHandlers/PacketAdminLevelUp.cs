﻿using RebuildSharedData.Enum;
using RebuildSharedData.Networking;
using RoRebuildServer.EntitySystem;

namespace RoRebuildServer.Networking.PacketHandlers
{
    [ClientPacketHandler(PacketType.AdminLevelUp)]
    public class PacketAdminLevelUp : IClientPacketHandler
    {
        public void Process(NetworkConnection connection, InboundMessage msg)
        {
            if (connection.Character == null || !connection.Character.IsActive || connection.Character.Map == null
                || !connection.Entity.IsAlive() || connection.Character.State == CharacterState.Dead)
                return;

            var lvTarget = (int)msg.ReadByte();
            var character = connection.Character;
            var bs = character.CombatEntity.BaseStats;

            if (bs.Level >= 99)
                return;

            if (lvTarget == 0)
                lvTarget = bs.Level + 1;

            for (var i = bs.Level; i < lvTarget; i++)
            {
                character.Player.LevelUp();
            }

            character.Map.GatherPlayersForMultiCast(ref character.Entity, character);
            CommandBuilder.LevelUp(character, bs.Level);
            CommandBuilder.SendHealMulti(character, 0, HealType.None);
            CommandBuilder.ClearRecipients();
        }
    }
}