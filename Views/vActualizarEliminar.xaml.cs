using glasluisaS6B.Models;
using System.Net;

namespace glasluisaS6B.Views;

public partial class vActualizarEliminar : ContentPage
{
	public vActualizarEliminar(Estudiante datos)
	{
		InitializeComponent();
        txtCodigo.Text= datos.codigo.ToString();
        txtNombre.Text = datos.nombre.ToString();
        txtApellido.Text = datos.apellido.ToString();
        txtEdad.Text = datos.edad.ToString();
    }

    private async void btnActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("codigo", txtCodigo.Text);  // Código del estudiante a actualizar
            parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);

            cliente.UploadValues("http://192.168.1.3/wsestudiantes/estudiante.php", "PUT", parametros);
            Navigation.PushAsync(new vEstudiante());
        }
        catch (Exception ex)
        {
            DisplayAlert("ERROR", ex.Message, "Cerrar");
        }

    }

    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("codigo", txtCodigo.Text); // Aquí debes tener el código del estudiante a eliminar

            cliente.UploadValues("http://192.168.1.3/wsestudiantes/estudiante.php?codigo=" + txtCodigo.Text, "DELETE", parametros);
            Navigation.PushAsync(new vEstudiante());
        }
        catch (Exception ex)
        {
            DisplayAlert("ERROR", ex.Message, "Cerrar");
        }

    }
}