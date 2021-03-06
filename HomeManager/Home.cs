﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using HomeManager.HouseholdItems;
using HomeManager.HouseholdItems.Actions;

namespace HomeManager
{
    public class Home
    {
        private List<IHouseholdItem> allHomeItems;
        public List<IHouseholdItem> GetHomeItems { get => allHomeItems; }

        public Home()
        {
            allHomeItems = new List<IHouseholdItem>();
        }
        public Home(List<IHouseholdItem> homeItems)
        {
            allHomeItems = homeItems;
        }

        public void AddNewHomeItem(IHouseholdItem item)
        {
            allHomeItems.Add(item);

        }


        public void SwitchOffElectricity()
        {
            foreach (var item in allHomeItems)
            {
                item.TurnOff();
                Thread.Sleep(500);
            }
        }

        public void SwitchOnElectricity()
        {
            foreach (var item in allHomeItems)
            {
                item.TurnOn();
                Thread.Sleep(500);
            }
        }

        public void SwitchOffElectricityAsync(CancellationToken token)
        {
            foreach (var item in allHomeItems)
            {
                if (token.IsCancellationRequested)
                {
                    return;
                }
                item.TurnOff();
                Thread.Sleep(500);
            }
        }

        public void SwitchOnElectricityAsync(CancellationToken token)
        {
            foreach (var item in allHomeItems)
            {
                if (token.IsCancellationRequested)
                {
                    return;
                }
                item.TurnOn();
                Thread.Sleep(500);
            }
        }
    }
}
