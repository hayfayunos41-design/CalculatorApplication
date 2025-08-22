using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CalculatorApplication
{
    public partial class Form1 : Form
    {
        CalculatorClass cal;
        double num1, num2;
        public Form1()
        {
            InitializeComponent();

            cal = new CalculatorClass();

            cbOperator.Items.Add("+");
            cbOperator.Items.Add("-");
            cbOperator.Items.Add("*");
            cbOperator.Items.Add("/");
            cbOperator.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double num1 = double.Parse(txtBoxInput1.Text);
                double num2 = double.Parse(txtBoxInput2.Text);
                string op = cbOperator.SelectedItem.ToString();

                double result = 0;

                switch (op)
                {
                    case "+":
                        cal.CalculateEvent += new Formula<double>(cal.GetSum);
                        result = cal.GetSum(num1, num2);
                        cal.CalculateEvent -= new Formula<double>(cal.GetSum);
                        break;

                    case "-":
                        cal.CalculateEvent += new Formula<double>(cal.GetDifference);
                        result = cal.GetDifference(num1, num2);
                        cal.CalculateEvent -= new Formula<double>(cal.GetDifference);
                        break;

                    case "*":
                        cal.CalculateEvent += new Formula<double>(cal.GetProduct);
                        result = cal.GetProduct(num1, num2);
                        cal.CalculateEvent -= new Formula<double>(cal.GetProduct);
                        break;

                    case "/":
                        cal.CalculateEvent += new Formula<double>(cal.GetQuotient);
                        result = cal.GetQuotient(num1, num2);
                        cal.CalculateEvent -= new Formula<double>(cal.GetQuotient);
                        break;
                }
                lblDisplayTotal.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }        

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
