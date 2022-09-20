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
using Entity;
using Business;

namespace Semana05
{
    /// <summary>
    /// Lógica de interacción para ListaCategoria.xaml
    /// </summary>
    public partial class ListaCategoria : Window
    {
        public ListaCategoria()
        {
            InitializeComponent();
        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            Cargar();
        }
        private void Cargar()
        {
            BCategoria BCategoria = null;
            try
            {
                //0: Listar todas las categorias
                BCategoria = new BCategoria();
                dgvCategoria.ItemsSource = BCategoria.Listar(0);
            }
            catch (Exception)
            {
                MessageBox.Show("Comunicarse con el Administrador");
            }
            finally
            {
                BCategoria = null;
            }
        }

        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            //Coloco 0 porque es uno nuevo
            ManCategoria manCategoria = new ManCategoria(0);
            manCategoria.ShowDialog();
            Cargar();
        }

        private void DgvCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idCategoria;
            var item = (Categoria)dgvCategoria.SelectedItem;
            if (null == item) return;
            idCategoria = Convert.ToInt32(item.IdCategoria);
            //Coloco 0 porque es uno nuevo
            ManCategoria manCategoria = new ManCategoria(idCategoria);
            manCategoria.ShowDialog();
            Cargar();
        }
    }
}   
