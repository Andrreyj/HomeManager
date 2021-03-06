﻿using System;
using System.Collections.Generic;
using System.Text;
using HomeManager.Exceptions;
using HomeManager.HouseholdItems.Actions;


namespace HomeManager.HouseholdItems
{
    public abstract class BaseHouseholdItem : IHouseholdItem
    {
        protected string name;
        protected object deviceOwner;
        protected bool isActive = true;

        public string GetName => name;
        public string GetInfo => GetString();

        public bool ToRespond => isActive;

        protected void CheckDeviceIsNull()
        {
            if (this.deviceOwner is null)
            {
                throw new DeviceOwnerIsNullException();
            }
        }
        protected void CheckDeviceOwnerEquals(EquipmentControlPanel controller)
        {
            if (!controller.Equals(this.deviceOwner))
            {
                throw new ControllerIsNotEqualDeviceOwnerException();
            }
        }

        public abstract List<IAction> SetConnect(EquipmentControlPanel deviceOwner);
        
        public void DropConnect(EquipmentControlPanel controller)
        {
            CheckDeviceIsNull();
            CheckDeviceOwnerEquals(controller);

            this.deviceOwner = null;
        }

        public void TurnOn()
        {
            isActive = true;
        }
        public void TurnOff()
        {
            isActive = false;
        }

        public abstract string GetString();

    }
}
