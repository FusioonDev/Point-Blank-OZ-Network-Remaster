﻿/*
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
    class PROTOCOL_SHOP_LEAVE_REQ : ReceivePacket
    {
        public PROTOCOL_SHOP_LEAVE_REQ(GameNetwork Client, byte[] data)
        {
            makeme(Client, data);
        }

        public override void ReadImpl()
        {
        }
        public override void RunImpl()
        {
            /*Room room = getClient().getPlayer().getRoom();
            if (room != null & room.getPlayers().Count != 1)
            {
                getClient().getPlayer().getRoom().getRoomSlotByPlayer(getClient().getPlayer()).setState(SLOT_STATE.SLOT_STATE_NORMAL);
                foreach (Player member in getClient().getPlayer().getRoom().getPlayers().Values)
                {
                    member.getClient().SendPacket(new PROTOCOL_ROOM_INFO_ACK(room));
                }
            }*/

            getClient().SendPacket(new PROTOCOL_SHOP_LEAVE_ACK());
        }
    }
}
