using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        bool bW, bH;

        public MainPage()
        {
            InitializeComponent();
            SetupDefaults();
            
        }

        private void SetupDefaults()
        {
            //ctrl + . generate method
            bW = false;
            bH = false;
            btnBodyFatPage.IsEnabled = false;
            //show image on screen, chart.png
            var assembly = typeof(MainPage);
            string fileName = "App1.Assets.Images.chart.png";
            chart.Source = ImageSource.FromResource(fileName, assembly);
        }

        private void btnCalculate_Clicked(object sender, EventArgs e)
        {
            //calculate BMI for h/w entered by user
            //include checks for h/w
            double bmi;
            bmi = (Convert.ToDouble(entWeight.Text) / (Convert.ToDouble(entHeight.Text) * Convert.ToDouble(entHeight.Text)));
            lblAnswer.Text = "Your BMI is : " + bmi.ToString("0.00");
            btnBodyFatPage.IsEnabled = true;
        }

        private void entWeight_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (entWeight.Text == "")
            {
                btnCalculate.IsEnabled = false;
                lblAnswer.Text = "Your BMI is : ";
                bW = false;

            }
            else
            {
                bW = true;

            }

            //check other bool

            if (bW == true)

            {
                if (bH == true) btnCalculate.IsEnabled = true;

            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            ResetFieldsGeneral();
        }

        private void ResetFieldsGeneral()
        {
            bW = bH = false;
            entHeight.Text = "";
            entWeight.Text = "";
            btnCalculate.IsEnabled = false;
        }

        private void btnBodyFatPage_Clicked(object sender, EventArgs e)
        {
            //navigates to body fat page
            
            Navigation.PushAsync(new Page1());
        }

        private void entHeight_TextChanged(object sender, TextChangedEventArgs e)
        {

            //check entry boxes are full
            if(entHeight.Text=="")
            {
                btnCalculate.IsEnabled = false;
                lblAnswer.Text = "Your BMI is : ";
                bH = false;

            }
            else
            {
                bH = true;

            }

            //check other bool

            if (bH == true)

            {
                if (bW == true) btnCalculate.IsEnabled = true;

            }
            

        }
    }
   



}
