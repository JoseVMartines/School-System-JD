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
using MySql.Data.MySqlClient;

namespace System_Escola.Views
{
    /// <summary>
    /// Lógica interna para CadastroCurso.xaml
    /// </summary>
    public partial class CadastroCurso : Window
    {
        private Curso _cadastro = new Curso();

        public CadastroCurso()
        {
            InitializeComponent();
            Loaded += CadastroCurso_Loaded;
        }

        public CadastroCurso(Curso curso)
        {
            InitializeComponent();
            _cadastro = curso;
            Loaded += CadastroCurso_Loaded;
        }

        private void CadastroCurso_Loaded(object sender, RoutedEventArgs e)
        {
            txtNome.Text = _cadastro.Nome;
            txtDescricao.Text = _cadastro.Descricao;
            txtCargaHoraria.Text = _cadastro.CargaHoraria;
            cbTurno.Text = _cadastro.Turno;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _cadastro.Nome = txtNome.Text;
            _cadastro.Turno = cbTurno.Text;
            _cadastro.CargaHoraria = txtCargaHoraria.Text;
            _cadastro.Descricao = txtDescricao.Text;

            try
            {
                var dao = new CursoDAO();

                if (_cadastro.Id > 0)
                {
                    dao.Update(_cadastro);
                    MessageBox.Show("Registro Atualizado com Sucesso!");
                }
                else
                {
                    dao.Insert(_cadastro);
                    MessageBox.Show("Registro Salvo com Sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            ListaCurso cha = new ListaCurso();
            cha.ShowDialog();
        }
    }
}
