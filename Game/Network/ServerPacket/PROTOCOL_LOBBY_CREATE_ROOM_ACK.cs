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
    class PROTOCOL_LOBBY_CREATE_ROOM_ACK : SendPacket
    {
        private Room room;
        public PROTOCOL_LOBBY_CREATE_ROOM_ACK(Room room)
        {
            this.room = room;
        }
        public override void WriteImpl()
        {
            WriteH(0xC12);
            WriteD(room.getId());
            WriteD(room.getId());
            WriteS(room.getName(), Room.ROOM_NAME_SIZE);
            WriteC((byte)room.getMapId());
            WriteC(0); // unk
            WriteC((byte)room.getStage4v4());
            WriteC((byte)room.getType());
            WriteC((byte)room.getPlayers().Count);
            WriteC(0);  // unk
            WriteC((byte)room.getSlots());
            WriteC(0); // хз Пинг?
            WriteC((byte)room.getAllWeapons());
            WriteC((byte)room.getRandomMap());
            WriteC((byte)room.getSpecial());
            WriteS(room.getLeader().PlayerName, Player.MAX_NAME_SIZE);
            WriteC((byte)room.getKillMask());
            WriteC(0); // unk
            WriteC(0); // unk
            WriteC(0); // unk
            WriteC((byte)room.getLimit());
            WriteC((byte)room.getSeeConf());
            WriteH((short)room.getAutobalans());
        }
    }
}
