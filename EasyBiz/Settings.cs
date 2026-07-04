using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EasyBiz
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            InitFavoritesTab();            
        }

        private void InitFavoritesTab()
        {
            foreach (var module in ModuleRegistry.AllModules)
                clbFavorites.Items.Add(module.DisplayName);
            BtnSaveFavorites.Click += btnSave_Click;
            LoadFavoriteSelections();
        }

        private void LoadFavoriteSelections()
        {
            var favoriteKeys = FavoritesService.GetFavoriteKeys();
            for (int i = 0; i < ModuleRegistry.AllModules.Count; i++)
            {
                if (favoriteKeys.Contains(ModuleRegistry.AllModules[i].Key))
                    clbFavorites.SetItemChecked(i, true);
            }
        }
        public event EventHandler FavoritesUpdated;
        private void btnSave_Click(object sender, EventArgs e)
        {
            var selectedKeys = new List<string>();
            for (int i = 0; i < clbFavorites.Items.Count; i++)
            {
                if (clbFavorites.GetItemChecked(i))
                    selectedKeys.Add(ModuleRegistry.AllModules[i].Key);
            }

            FavoritesService.SaveFavorites(selectedKeys);
            
            MessageBox.Show("Favourites saved.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FavoritesUpdated?.Invoke(this, EventArgs.Empty);
        }
    }
}
