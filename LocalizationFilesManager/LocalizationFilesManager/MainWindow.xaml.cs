﻿using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LocalizationFilesManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable Data = new DataTable();

        public static RoutedCommand shortcutSave = new RoutedCommand();
        public static RoutedCommand shortcutLoad = new RoutedCommand();

        public MainWindow()
        {
            InitializeComponent();

            shortcutSave.InputGestures.Add(new KeyGesture(Key.S, ModifierKeys.Control));

            CommandBindings.Add(new CommandBinding(shortcutSave, MenuItemSaveClick));

            Data.Columns.Clear();
            DataColumn column = Data.Columns.Add("ID");
            dataGrid.ColumnWidth = new DataGridLength(100,DataGridLengthUnitType.Star);

            dataGrid.ItemsSource = Data.DefaultView;
        }

        private void Button_new_Langage(object sender, RoutedEventArgs e)
        {
            WindowDialogBox dialogBox = new WindowDialogBox();

            if(dialogBox.ShowDialog() == true)
            {
                AddNewLangage(dialogBox.Answer);
            }
        }

        
    }
}
