using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calci
{
    public partial class MainPage : ContentPage
    {
        int current = 1;
        string operation;
        double first, second;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressedButton = button.Text;

            if(this.result.Text=="0" || current<0 )
            {
                this.result.Text = "";

                if(current<0)
                {
                    current *= -1;
                }
            }

            this.result.Text += pressedButton;

            double num;
            if(double.TryParse(this.result.Text, out num))
            {
                if(current==1)
                {
                    first = num;
                }
                else
                {
                    second = num;
                }
            }
        }

        private void Operator_Clicked(object sender, EventArgs e)
        {
            current = -2;

            Button button = (Button)sender;
            string pressedButton = button.Text;

            this.result.Text += pressedButton;

            operation = pressedButton;
        }

        private void Clear_Clicked(object sender, EventArgs e)
        {
            first = 0;
            second = 0;
            this.result.Text = "0";
            current = 1;
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            if (this.result.Text != string.Empty)
            {
                int txtLength = this.result.Text.Length;
                if (txtLength != 1)
                {
                    this.result.Text = this.result.Text.Remove(txtLength - 1);
                }
                else
                {
                    this.result.Text = 0.ToString();
                }
            }
        }

        private void Calculate_Clicked(object sender, EventArgs e)
        {
            if (current == 2)
            {
                var resultOperation = Operator.Calculate(first, second, operation);

                this.result.Text = resultOperation.ToString();
                first = resultOperation;
                current = -1;
            }
        }
    }
}