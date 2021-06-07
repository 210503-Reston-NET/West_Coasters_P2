﻿using System.Collections.Generic;
using Models;

namespace DL
{
    public interface IEquipmentRepo
    {
        public List<Equipment> GetAllEquipments();

        public Equipment AddEquipment(Equipment equipment);
    }
}