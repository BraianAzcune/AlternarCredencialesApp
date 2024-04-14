using System.Diagnostics;

namespace WinFormsDemo;

public partial class Main : Form
{
    public Main()
    {
        InitializeComponent();
    }

    string RutaArchivoTemporalTrabajo = "";
    string RutaArchivoTemporalTrabajoPub = "";
    string RutaArchivoTemporalPersonal = "";
    string RutaArchivoTemporalPersonalPub = "";
    string RutaArchivoActual = "";
    string RutaArchivoActualPub = "";
    private void BtnCredenciales_click(object sender, EventArgs e)
    {
        string estadoActual = BtnCredencial.Text;
        BtnCredencial.Text = "Cambiando";
        BtnCredencial.Enabled = false;
        Stopwatch stopwatch = Stopwatch.StartNew();


        if (estadoActual == "Personal")
        {
            CambiarModoTrabajo();
            BtnCredencial.Text = "Trabajo";
        }
        else if (estadoActual == "Trabajo")
        {
            CambiarModoPersonal();
            BtnCredencial.Text = "Personal";
        }
        else
        {
            MessageBox.Show("El boton no posee un estado valido para funcionar",
                "Error en el estado del boton",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        // agregar un poco de delay antes de re-habilitar el boton
        stopwatch.Stop();
        if (stopwatch.ElapsedMilliseconds > 200)
        {
            Thread.Sleep(100);
        }
        else
        {
            Thread.Sleep(500);
        }
        BtnCredencial.Enabled = true;
    }

    private void CambiarModoPersonal()
    {
        // el archivo actual es trabajo, asi que se mueve, (tira error si ya existia)
        File.Move(RutaArchivoActual, RutaArchivoTemporalTrabajo);
        File.Move(RutaArchivoActualPub, RutaArchivoTemporalTrabajoPub);

        File.Move(RutaArchivoTemporalPersonal, RutaArchivoActual);
        File.Move(RutaArchivoTemporalPersonalPub, RutaArchivoActualPub);
    }

    private void CambiarModoTrabajo()
    {
        // el archivo actual es personal
        File.Move(RutaArchivoActual, RutaArchivoTemporalPersonal);
        File.Move(RutaArchivoActualPub, RutaArchivoTemporalPersonalPub);

        File.Move(RutaArchivoTemporalTrabajo, RutaArchivoActual);
        File.Move(RutaArchivoTemporalTrabajoPub, RutaArchivoActualPub);
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        RevisarArchivosInicialesYCargar();
    }

    void RevisarArchivosInicialesYCargar()
    {

        string carpetaUsuario = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        string rutaSSH = Path.Combine(carpetaUsuario, ".ssh");

        RutaArchivoTemporalTrabajo = Path.Combine(rutaSSH, "trabajo-id_rsa");
        RutaArchivoTemporalTrabajoPub = Path.Combine(rutaSSH, "trabajo-id_rsa.pub");
        RutaArchivoTemporalPersonal = Path.Combine(rutaSSH, "braian-id_rsa");
        RutaArchivoTemporalPersonalPub = Path.Combine(rutaSSH, "braian-id_rsa.pub");
        RutaArchivoActual = Path.Combine(rutaSSH, "id_rsa");
        RutaArchivoActualPub = Path.Combine(rutaSSH, "id_rsa.pub");

        if (!VerificarExistenciaArchivos(RutaArchivoActual, RutaArchivoActualPub))
        {
            MessageBox.Show("no existe el archivo id_rsa o su .pub en la carpeta: " + rutaSSH,
                "Error al cargar",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            Process.Start("explorer.exe", rutaSSH);
            Application.Exit();
        }

        if (
            VerificarExistenciaArchivos(RutaArchivoTemporalTrabajo, RutaArchivoTemporalTrabajoPub) &&
            !VerificarExistenciaArchivos(RutaArchivoTemporalPersonal, RutaArchivoTemporalPersonalPub)
            )
        {
            // estamos en modo Personal
            BtnCredencial.Text = "Personal";
        }
        else if (
            VerificarExistenciaArchivos(RutaArchivoTemporalPersonal, RutaArchivoTemporalPersonalPub) &&
            !VerificarExistenciaArchivos(RutaArchivoTemporalTrabajo, RutaArchivoTemporalTrabajoPub)
            )
        {
            // estamos en modo trabajo
            BtnCredencial.Text = "Trabajo";
        }
        else
        {
            // estamos en un modo extraño
            MessageBox.Show("no existe el archivo trabajo-id_rsa ni el archivo braian - id_rsa " +
            "en la carpeta: " + rutaSSH,
            "Error al cargar",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
            Process.Start("explorer.exe", rutaSSH);
            Application.Exit();

        }

    }
    /// <summary>
    /// tienen que existir todos
    /// </summary>
    /// <param name="archivos"></param>
    /// <returns></returns>
    private bool VerificarExistenciaArchivos(params string[] archivos)
    {
        foreach (string archivo in archivos)
        {
            if (!File.Exists(archivo))
            {
                return false;
            }
        }
        return true;
    }

}

