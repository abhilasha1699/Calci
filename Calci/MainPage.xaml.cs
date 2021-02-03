using System;
using Xamarin.Forms;

namespace Calci
{
    public partial class MainPage : ContentPage
    {
        private int current = 1;
        private string operation;
        private double firstNumber, secondNumber;

        #region consructor
        public MainPage()
        {
            InitializeComponent();
        }
        #endregion

        #region NumericButton
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
                    firstNumber = num;
                }
                else
                {
                    secondNumber = num;
                }
            }
        }
        #endregion

        #region OperationButton
        private void Operator_Clicked(object sender, EventArgs e)
        {
            current = -2;

            Button button = (Button)sender;
            string pressedButton = button.Text;

            this.result.Text += pressedButton;

            operation = pressedButton;
        }
        #endregion

        #region ClearValue
        private void Clear_Clicked(object sender, EventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            this.result.Text = "0";
            current = 1;
        }
        #endregion

        #region DeleteNumber
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
        #endregion

        #region EvaluateButton
        private void Calculate_Clicked(object sender, EventArgs e)
        {
            if (current == 2)
            {
                var resultOperation = Operator.Calculate(firstNumber, secondNumber, operation);

                this.result.Text = resultOperation.ToString();
                firstNumber = resultOperation;
                current = -1;
            }
        }
        #endregion
    }
}