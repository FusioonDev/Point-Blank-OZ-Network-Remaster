﻿/*
 * C# Server Emulator Project Blackout / PointBlank
 * Authors: the__all
 * Copyright (C) 2015 | OZ-Network
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Game.Network;

namespace Core.Model
{
    public class Player
    {
        public static int MAX_NAME_SIZE = 33;
        public ulong PlayerID;
        public ulong AccountID;
        public string PlayerName = "";
        public int GP;
        public int Money;
        public int Rank;
        public int PC_Cafe;
        public int Emblem;
        public int Exp;
        public int ChannelId;
        public int ClanID;
        public int changeSlot = 1;
        public Room room;
        public int SlotID;
        public Channel channel;
        private string addrEndPoint;
        private GameNetwork _Client;
        public Clan Clan;


        public GameNetwork getClient()
        {
            return _Client;
        }

        public void setClient(GameNetwork _Client)
        {
            this._Client = _Client;
        }

        public string getName()
        {
            return PlayerName;
        }

        public void setName(string PlayerName)
        {
            this.PlayerName = PlayerName;
        }

        public int getRank()
        {
            return Rank;
        }

        public void setRank(int Rank)
        {
            this.Rank = Rank;
        }

        public int getPCCafe()
        {
            return PC_Cafe;
        }

        public void setPCCafe(int PC_Cafe)
        {
            this.PC_Cafe = PC_Cafe;
        }

        public int getEmblem()
        {
            return Emblem;
        }

        public void setEmblem(int Emblem)
        {
            this.Emblem = Emblem;
        }

        public int getExp()
        {
            return Exp;
        }

        public void setExp(int Exp)
        {
            this.Exp = Exp;
        }

        public int getGp()
        {
            return GP;
        }

        public void setGp(int GP)
        {
            this.GP = GP;
        }

        public int getMoney()
        {
            return Money;
        }

        public void setMoney(int Money)
        {
            this.Money = Money;
        }

        public List<Item> getInvetoryOnly(int type) 
        { 
            return Inventory.getAllItemsOnType(type, PlayerID); 
        }
        public Item getEquipFromSlot(int slot)
        {
            return Inventory.getEquip(slot, PlayerID);
        }

        public Room getRoom()
        {
            return room;
        }

        public void setRoom(Room room)
        {
            this.room = room;
        }

        public void setSlot(int SlotID)
        {
            this.SlotID = SlotID;
        }

        public int getSlot()
        {
            return SlotID;
        }

        public Channel getChannel()
        {
            return channel;
        }

        public void setChannel(Channel channel)
        {
            this.channel = channel;
        }

        public int getClanID()
        {
            return ClanID;
        }

        public void setClanId(int ClanID)
        {
            this.ClanID = ClanID;
        }

        public Clan getClan()
        {
            return this.Clan;
        }

        public void setClan(Clan var1)
        {
            this.Clan = var1;
        }

        public void setAddress(string addrEndPoint)
        {
            this.addrEndPoint = addrEndPoint;
        }

        public byte[] getAddress()
        {
            return IPAddress.Parse(addrEndPoint).GetAddressBytes();
        }

        public Item getItemById(long id)
        {
            return Inventory.getItemById(id, PlayerID);
        }

    }
}
