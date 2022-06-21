using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System_Escola.Models;

namespace System_Escola.Views
{
    /// <summary>
    /// Lógica interna para ListarEscola.xaml
    /// </summary>
    public partial class ListarEscola : Window
    {
        public ListarEscola()
        {
            InitializeComponent();
            Loaded += ListaEscola_Loaded;
        }

        private void ListaEscola_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            try
            {
                var dao = new EscolaDAO();


                dataGrid.ItemsSource = dao.List();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            var escolaSelected = dataGrid.SelectedItem as Escola;

            var result = MessageBox.Show($"Deseja realmente remover a escola `{escolaSelected.Nome}`?", "Confirmação de Exclusão",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new EscolaDAO();
                    dao.Delete(escolaSelected);
                    LoadDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Update_Click(object sender, RoutedEventArgs e)
        {
            var escolaSelected = dataGrid.SelectedItem as Escola;
            var window = new Cadastro(escolaSelected);
            window.ShowDialog();
            LoadDataGrid();
        }
    }
}
