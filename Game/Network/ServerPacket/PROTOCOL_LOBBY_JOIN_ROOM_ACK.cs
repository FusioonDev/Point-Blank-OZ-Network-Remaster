﻿/*
 * C# Server Emulator Project Blackout / PointBlank
 * Authors: the__all
 * Copyright (C) 2015 | OZ-Network
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Model;

namespace Game.Network.ServerPacket
{
    class PROTOCOL_LOBBY_JOIN_ROOM_ACK : SendPacket
    {
        private Room room;
        private int slodId;
        private uint error;
        public PROTOCOL_LOBBY_JOIN_ROOM_ACK(Room room, int slodId, uint error)
        {
            this.room = room;
            this.slodId = slodId;
            this.error = error;
        }
        public override void WriteImpl()
        {
            WriteH(0xC0A);
            WriteD((int)error);
            if (error >= 0)
            {
                WriteD(slodId);
                WriteD(room.getId());
                WriteS(room.getName(), 23);
                WriteC((byte)room.getMapId());
                WriteC(0);
                WriteC(0);
                WriteC((byte)room.getType());
                WriteC(5);
                WriteC((byte)room.getPlayers().Count);
                WriteC((byte)room.getSlots());
                WriteC(5); // ping ?!
                WriteC((byte)room.getAllWeapons());
                WriteC((byte)room.getRandomMap());
                WriteC((byte)room.getSpecial());
                WriteS(room.getLeader().getName(), Player.MAX_NAME_SIZE);
                WriteC((byte)room.getKillMask());
                WriteC(0);
                WriteC(0);
                WriteC(0);
                WriteC((byte)room.getLimit());
                WriteC((byte)room.getSeeConf());
                WriteH((byte)room.getAutobalans());
                WriteD(0);
                WriteC(0);
                WriteD(room.getRoomSlotByPlayer(room.getLeader()).getId());

                Logger.Info("S {0}", room.getRoomSlots().Count());

                foreach (SLOT slot in room.getRoomSlots())
                {

                    if (slot.getPlayer() == null)
                    {
                        WriteC((byte)(int)slot.getState());
                        WriteB(new byte[9]);
                        WriteC(255);
                        WriteC(255);
                        WriteC(255);
                        WriteC(255);
                        WriteC(0);
                        WriteB(new byte[27]);
                    }
                    else
                    {
                        WriteC((byte)(int)slot.getState());
                        WriteC((byte)slot.getPlayer().getRank());
                        WriteD(0);
                        WriteD(0);
                        WriteC(slot.getPlayer() == null || slot.getPlayer().ClanID == 0 ? (byte)255 : (byte)slot.getPlayer().Clan.Logo1);
                        WriteC(slot.getPlayer() == null || slot.getPlayer().ClanID == 0 ? (byte)255 : (byte)slot.getPlayer().Clan.Logo2);
                        WriteC(slot.getPlayer() == null || slot.getPlayer().ClanID == 0 ? (byte)255 : (byte)slot.getPlayer().Clan.Logo3);
                        WriteC(slot.getPlayer() == null || slot.getPlayer().ClanID == 0 ? (byte)255 : (byte)slot.getPlayer().Clan.Logo4);
                        WriteC(0);
                        WriteB(new byte[6]);
                        WriteS(slot.getPlayer() == null || slot.getPlayer().getClan() == null ? "" : slot.getPlayer().getClan().getName(), Clan.CLAN_NAME_SIZE);
                        WriteD(0);
                    }
                }

                WriteC((byte)room.getPlayers().Count);
                foreach (Player player in room.getPlayers().Values)
                {
                    WriteC((byte)room.getRoomSlotByPlayer(player).getId());
                    WriteC((byte)Player.MAX_NAME_SIZE);
                    WriteS(player.getName(), Player.MAX_NAME_SIZE);
                    WriteC(0); //player.getColor()
                }

                WriteC((byte)room.getAiCount()); // aiCount
                WriteC((byte)room.getAiLevel()); // aiLevel

            }
        }
    }
}