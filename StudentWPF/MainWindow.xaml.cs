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
using System.Windows.Navigation;
using System.Windows.Shapes;
using StudentWPF.APIMethods;
using StudentWPF.Models;

namespace StudentWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public double GPA { get; set; }
        public string LetterGrade { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Student stud = new Student();
            GPA = stud.GPA;
            LetterGrade = stud.LetterGrade;
        }
        public void UpdateValues() 
        {
            
            FirstName = txtFirstName.Text;
            LastName = txtLastName.Text;
            Age = int.Parse(txtAge.Text);
            
           
        }
        public void ClearText() 
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtAge.Clear();
           
            
        }

        private async void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UpdateValues();
            }
            catch (Exception)
            {
                txtResult.Text = "Enter numbers only for age";
                ClearText();
            }
                
            if (txtFirstName.Text != "" && txtLastName.Text != "" && txtAge.Text !="")
            {
                ApiMethods method = new ApiMethods();
                await method.Create(FirstName, LastName, Age, GPA, LetterGrade);
            }
            else 
            {
                txtResult.Text = "Please make sure you fill out the prompts.";
            }
      
            ClearText();
        }
    }
}
