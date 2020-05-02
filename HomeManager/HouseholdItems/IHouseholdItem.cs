﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HomeManager.HouseholdItems
{
    public interface IHouseholdItem
    {
        public string GetName { get; }
        public void SetConnect(EquipmentControlPanel deviceOwner);
        public void DropConnect(EquipmentControlPanel controller);
        public bool ToRespond();
        public void TurnOn();
        public void TurnOff();
        public string GetString();
    }
}
