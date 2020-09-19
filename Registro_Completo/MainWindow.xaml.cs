using System.Windows;
using Registro_Completo.BLL;
using Registro_Completo.Entidades;

namespace Registro_Completo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Personas Persona = new Personas();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = Persona;


        }

        private void Limpiar(){
            this.Persona = new Personas();
            this.DataContext = Persona;
        }

        private bool Validar(){
            bool esValido = true;

            if (NombreTextBox.Text.Length == 0){   
                esValido = false;
                MessageBox.Show("Transaccion Fallida","Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e){
            var persona = BLLPersonas.Buscar(Utilidades.ToInt(IDTextBox.Text));

            if (persona != null)
                this.Persona = persona;
            else    
                this.Persona = new Personas();

                this.DataContext = this.Persona;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e){
            Limpiar();
        }

     private void GuardarButton_Click(object sender, RoutedEventArgs e){
            
            if(!Validar()){
                return;
            }
            var paso = BLLPersonas.Guardar(Persona);

            if(paso){
                Limpiar();
                MessageBox.Show("Transaccion exitosa!" , "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else{
                MessageBox.Show("Transaccion Fallida", "Fallo",  MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e){
            if (BLLPersonas.Eliminar(Utilidades.ToInt(IDTextBox.Text))){
                Limpiar();
                MessageBox.Show("Registro Eliminado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }



        
    }

}
