using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyFirstApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public int CurrentState { get; set; } = 1;

        public string MathOperator { get; set; }

        public double FirstNumber { get; set; }

        public double SecondNumber { get; set; }

        public void OnSelectNumber (object sender, EventArgs e)
        {
            if (CurrentState < 0 )
            {
                CurrentState = CurrentState * -1;
            }

            Button clicked = (Button)sender;
            string number;

            if(CurrentState == 1)
            {
                number = FirstNumber.ToString();
                number = number + clicked.Text;
                FirstNumber = double.Parse(number);
                ResultText.Text = FirstNumber.ToString();
            }
            else
            {
                number = SecondNumber.ToString();
                number = number + clicked.Text;
                SecondNumber = double.Parse(number);
                ResultText.Text = SecondNumber.ToString();
            }
        }

        public void OnSelectOperator (object sender, EventArgs e)
        {
            Button operatorClicked = (Button)sender;
            MathOperator = operatorClicked.Text;
            CurrentState = -2;
        }

        public void OnClear(object sender, EventArgs e)
        {
            CurrentState = 1;
            FirstNumber = 0;
            SecondNumber = 0;
            MathOperator = "";
            ResultText.Text = "0";
        }

        public void OnCalculate(object sender, EventArgs e)
        {
            double res = 0;

            switch(MathOperator)
            {
                case "+":
                    res = FirstNumber + SecondNumber;
                    break;
                case "-":
                    res = FirstNumber - SecondNumber;
                    break;
                case "/":
                    res = FirstNumber / SecondNumber;
                    break;
                case "X":
                    res = FirstNumber * SecondNumber;
                    break;
            }

            ResultText.Text = res.ToString();
            CurrentState = -2;
            SecondNumber = 0;
            FirstNumber = res;
        }

        async void OnPageChangeClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AnotherPage());
        }
    }
}
