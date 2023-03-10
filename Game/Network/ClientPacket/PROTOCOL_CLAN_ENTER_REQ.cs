/*
 * C# Server Emulator Project Blackout / PointBlank
 * Authors: the__all
 * Copyright (C) 2015 | OZ-Network
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game.Network.ServerPacket;
using Core.Model;

namespace Game.Network.ClientPacket
{
    class PROTOCOL_CLAN_ENTER_REQ : ReceivePacket
    {
        public PROTOCOL_CLAN_ENTER_REQ(GameNetwork Client, byte[] data)
        {
            makeme(Client, data);
        }

        public override void ReadImpl()
        {
        }

        public override void RunImpl()
        {
            Room room = getClient().getPlayer().getRoom();
            if (room != null)
            {
                getClient().getPlayer().getRoom().getRoomSlotByPlayer(getClient().getPlayer()).setState(SLOT_STATE.SLOT_STATE_CLAN);
                foreach (Player member in getClient().getPlayer().getRoom().getPlayers().Values)
                {
                    member.getClient().SendPacket(new PROTOCOL_ROOM_INFO_ACK(room));
                }
            }

            Clan clan = getClient().getPlayer().Clan;
            if (clan == null)
            {
                getClient().SendPacket(new PROTOCOL_CLAN_ENTER_ACK(getClient().getPlayer()));
            }
            else
            {
                getClient().SendPacket(new PROTOCOL_CLAN_ENTER_ACK(getClient().getPlayer()));
                getClient().SendPacket(new PROTOCOL_CLAN_INFO_ACK(getClient().getPlayer()));
            }
        }
    }
}
