using BusinnessLayer;
using Csla.Rules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Example1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private ClientRoot _clientRoot;

        public MainPage()
        {
            InitializeComponent();

            
            DatePicker.MaximumDate = DateTime.Today;
            DatePicker.MinimumDate = DateTime.Today.AddMonths(-1);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                _clientRoot = ClientRoot.NewEditableClientRoot();
                _clientRoot.Name = TxtEmail.Text;
                _clientRoot.Email = TxtEmail.Text;

                _clientRoot = _clientRoot.Save();

                Indicator.IsRunning = true;
            }
            catch(ValidationException)
            {
                DisplayAlert("Validation Error", string.Join("\n", _clientRoot.BrokenRulesCollection.ToList()), "Cancel");
            }
        }
    }
}
