﻿/*
 * C# Server Emulator Project Blackout / PointBlank
 * Authors: the__all
 * Copyright (C) 2015 | OZ-Network
 */
using Core.Model;
using Core.Database.Tables;
using Game;
using Game.Network;
using Game.Network.ServerPacket;
using System;

namespace Game.Network.ClientPacket
{
    internal class PROTOCOL_INVENTORY_USE_ITEM_REQ : ReceivePacket
    {
        public PROTOCOL_INVENTORY_USE_ITEM_REQ(GameNetwork Client, byte[] data)
        {
            makeme(Client, data);
        }

        private long ID;

        public override void ReadImpl()
        {
            ID = ReadQ();
        }

        public override void RunImpl()
        {
            //меджик формула :  itemid - 30 + 1000000000
            Item item = getClient().getPlayer().getItemById(ID);
            int oldID = item.Id;
            ItemsTable.DelItem(oldID);
            int NewID = oldID - 30 + 1000000000;
            int CouponTime = Convert.ToInt32(DateTime.Now.ToString("yyMMddHHmm") + "0000070000");//актуальное время + 7 дней(для теста)
            ItemsTable.AddItem(getClient().getPlayer().PlayerID, NewID, 10, 3, CouponTime);

            getClient().SendPacket((SendPacket)new PROTOCOL_INVENTORY_DELET_ITEM_ACK(ID));
            getClient().SendPacket((SendPacket)new PROTOCOL_INVENTORY_ADD_ITEM_ACK(NewID));
        }
    }
}
