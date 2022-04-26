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
using MySql.Data.MySqlClient;

namespace ShoolSystemJD.Views
{
    public partial class EscolaFormWindow : Window
    {
        public EscolaFormWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string nomeFantasia = txtNomeFantasia.Text;
            string razaoSocial = txtRazaoSocial.Text;
            var data_criacao = DTcriacao.SelectedDate?.ToString("yyyy-MM-dfd");
            string cnpj = txtCNPJ.Text;
            string Inscricao = txtInscricao.Text;
            string responsavel = txtREsponsavel.Text;
            string nomeIP = txtnomeIp.Text;
            string telefone = txtTelefone.Text;
            string rua = txtRua.Text;
            string bairro = txtBairro.Text;
            string tipo = "Privada";

            ///if ((bool)idTipoPublica.IsChecked)
            tipo = "Pública";


            var conexao = new MySqlConnection("server=localhost;database=bd_escola;port=3360;user=rootpassword=root");

            
            try
            {
                conexao.Open();
                var comando = conexao.CreateCommand();



                comando.CommandText = "insert into Escola values(@nome, @razao)";



                comando.Parameters.AddWithValue("@nome", nomeFantasia);
                comando.Parameters.AddWithValue("@razao", razaoSocial);
                comando.Parameters.AddWithValue("@dataCriacao", data_criacao);
                comando.Parameters.AddWithValue("@cnpj", cnpj);
                comando.Parameters.AddWithValue("@inscricao", Inscricao);
                comando.Parameters.AddWithValue("@responsavel", responsavel);
                comando.Parameters.AddWithValue("@nomeIP", nomeIP);

                var resultado = comando.ExecuteNonQuery();

                if (resultado > 0)
                {
                        MessageBox.Show("Registro Salvo Com Sucesso")
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        
        }
      
      
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
