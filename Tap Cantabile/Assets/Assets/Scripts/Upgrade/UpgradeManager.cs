﻿using UnityEngine;

namespace Idle
{
    public class UpgradeManager : MonoBehaviour
    {

        [Header("Components")]
        public CityUpgrade cityUpgrade;
        public ResidentsUpgrade residentsUpgrade;
        public ComfortUpgrade comfortUpgrade;
        public AutomationUpgrade automationUpgrade;

        private void Awake()
        {
            //load saves from file
            UpgradeLoad();
        }

        ////////////////////////////////// Start: Calls upgrades from buttons
        public void CityUpgrage(int itemId)
        {
            cityUpgrade.UpgradeItem(itemId); //Call the upgrade method in the City Upgrade script (whose ID item is the upgrade)
        }

        public void ResidentsUpgrade(int itemId)
        {
            residentsUpgrade.UpgradeItem(itemId);
        }

        public void ComfortUpgrade(int itemId)
        {
            comfortUpgrade.UpgradeItem(itemId);
        }

        public void AutomationUpgrade(int itemId)
        {
            automationUpgrade.UpgradeItem(itemId);
        }
        ////////////////////////////////// End


        //Update UI
        public void UpdateUI()
        {
            cityUpgrade.UpdateUI();
            residentsUpgrade.UpdateUI();
            comfortUpgrade.UpdateUI();
            automationUpgrade.UpdateUI();
        }

        //saving upgrade data to file
        public void UpgradeSave()
        {
            //We clear the list of all items, in order to avoid writing
            UpgradeListClear();

            //Write items to the cleared list
            for (int i = 0; i < cityUpgrade.items.Count; i++)
            {
                DataManager.upgradeData.cityItems.Add(cityUpgrade.items[i].itemData);
            }
            for (int i = 0; i < residentsUpgrade.items.Count; i++)
            {
                DataManager.upgradeData.residentsItems.Add(residentsUpgrade.items[i].itemData);
            }
            for (int i = 0; i < comfortUpgrade.items.Count; i++)
            {
                DataManager.upgradeData.comfortItems.Add(comfortUpgrade.items[i].itemData);
            }
            for (int i = 0; i < automationUpgrade.items.Count; i++)
            {
                DataManager.upgradeData.automationItems.Add(automationUpgrade.items[i].itemData);
            }

            //save all data
            DataManager.SaveData();
        }
        //load data
        public void UpgradeLoad()
        {
            if (DataManager.upgradeData.cityItems.Count > 0)
                for (int i = 0; i < cityUpgrade.items.Count; i++)
                {
                    //write item from file to item on scene
                    cityUpgrade.items[i].itemData = DataManager.upgradeData.cityItems[i];
                }
            if (DataManager.upgradeData.residentsItems.Count > 0)
                for (int i = 0; i < residentsUpgrade.items.Count; i++)
                {
                    residentsUpgrade.items[i].itemData = DataManager.upgradeData.residentsItems[i];
                }
            if (DataManager.upgradeData.comfortItems.Count > 0)
                for (int i = 0; i < comfortUpgrade.items.Count; i++)
                {
                    comfortUpgrade.items[i].itemData = DataManager.upgradeData.comfortItems[i];
                }
            if (DataManager.upgradeData.automationItems.Count > 0)
                for (int i = 0; i < automationUpgrade.items.Count; i++)
                {
                    automationUpgrade.items[i].itemData = DataManager.upgradeData.automationItems[i];
                }

        }

        //Сlear method
        void UpgradeListClear()
        {
            DataManager.upgradeData.cityItems.Clear();
            DataManager.upgradeData.residentsItems.Clear();
            DataManager.upgradeData.comfortItems.Clear();
            DataManager.upgradeData.automationItems.Clear();
        }
    }
}