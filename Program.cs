using System;
using Gtk;
using System.Runtime.InteropServices;

class Program
{
    // Declarar la función externa desde la librería C
    [DllImport("libsuma.so", CallingConvention = CallingConvention.Cdecl)]
    public static extern double suma(double a, double b);

    static void Main(string[] args)
    {
        // Inicializar GTK
        Application.Init();

        // Crear la ventana principal
        Window window = new Window("Suma de dos números");
        window.SetSizeRequest(300, 200);
        window.DeleteEvent += (o, args) => Application.Quit();

        // Crear los componentes de la interfaz
        VBox vbox = new VBox();
        
        // Etiqueta para el título
        Label label = new Label("Ingresa dos números");
        vbox.PackStart(label, false, false, 10);
        
        // Caja para los números de entrada
        HBox hbox = new HBox();
        Entry entry1 = new Entry();
        Entry entry2 = new Entry();
        hbox.PackStart(entry1, true, true, 5);
        hbox.PackStart(entry2, true, true, 5);
        
        // Botón para calcular la suma
        Button button = new Button("Sumar");
        button.Clicked += (sender, e) => 
        {
            double num1 = double.Parse(entry1.Text);
            double num2 = double.Parse(entry2.Text);
            double resultado = suma(num1, num2);
            label.Text = $"Resultado: {resultado}";
        };

        // Empacar los componentes en la ventana
        vbox.PackStart(hbox, false, false, 10);
        vbox.PackStart(button, false, false, 10);
        vbox.PackStart(label, false, false, 10);
        
        window.Add(vbox);

        // Mostrar todo
        window.ShowAll();

        // Iniciar la aplicación GTK
        Application.Run();
    }
}
