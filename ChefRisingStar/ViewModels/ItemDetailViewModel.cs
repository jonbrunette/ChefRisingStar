﻿using ChefRisingStar.Models;
using ChefRisingStar.Services;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace ChefRisingStar.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseDataViewModel<Item, string>
    {
        private string itemId;
        private string text;
        private string description;
        public string Id { get; set; }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public override IDataStore<Item, string> DataStore { get; protected set; }

        public ItemDetailViewModel()
        {
            DataStore = DependencyService.Get<IDataStore<Item, string>>();
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Text = item.Text;
                Description = item.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
