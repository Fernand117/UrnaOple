using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Urna.UI.Views.Votaciones.TiposVotaciones.Ayuntamiento
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class AyuntamientoPage : Page
    {

        public class Student
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        private List<Student> listOfStudents = new List<Student>();

        public AyuntamientoPage()
        {
            this.InitializeComponent();

            listOfStudents.Add(new Student { Name = "John", Age = 20 });
            listOfStudents.Add(new Student { Name = "Bob", Age = 21 });
            listOfStudents.Add(new Student { Name = "Steve", Age = 19 });
            listOfStudents.Add(new Student { Name = "Marko", Age = 18 });
            listOfStudents.Add(new Student { Name = "Igor", Age = 20 });
            listOfStudents.Add(new Student { Name = "Ivan", Age = 20 });
            listOfStudents.Add(new Student { Name = "Nina", Age = 21 });
            listOfStudents.Add(new Student { Name = "Paul", Age = 20 });
            listOfStudents.Add(new Student { Name = "Ana", Age = 23 });
            listOfStudents.Add(new Student { Name = "Ivana", Age = 20 });

            StudentsList.ItemsSource = listOfStudents;
        }
    }
}
