using System;
using System.Windows.Forms;
using System.Data;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        private TextBox textBox;
        private string currentText = string.Empty;

        public Form1()
        {
            InitializeComponent();
            InitializeCalculator();
        }

        private void InitializeCalculator()
        {
            // TextBox for displaying the result
            textBox = new TextBox
            {
                Width = 200,
                Height = 30,
                Font = new System.Drawing.Font("Arial", 14),
                TextAlign = HorizontalAlignment.Right
            };

            // Buttons
            string[] buttons = {
                "7", "8", "9", "/",
                "4", "5", "6", "*",
                "1", "2", "3", "-",
                "0", ".", "=", "+",
                "C", "sin", "cos", "tan",
                "sqrt", "pi", "e", "log", "ln", "^2", "(", ")"
            };

            int row = 1;
            int col = 0;

            foreach (string buttonText in buttons)
            {
                Button button = new Button
                {
                    Text = buttonText,
                    Width = 50,
                    Height = 50,
                    Font = new System.Drawing.Font("Arial", 10)
                };

                button.Click += (sender, e) => OnButtonClick(buttonText);
                Controls.Add(button);
                button.Location = new System.Drawing.Point(col * 50, row * 50 + 30);

                col++;
                if (col > 3)
                {
                    col = 0;
                    row++;
                }
            }

            // Add TextBox to the form
            Controls.Add(textBox);
            textBox.Location = new System.Drawing.Point(0, 0);
            textBox.Width = 200 * 4;
        }

        private void OnButtonClick(string buttonText)
        {
            switch (buttonText)
            {
                case "=":
                    try
                    {
                        // Use DataTable to handle mathematical expressions
                        var dataTable = new DataTable();
                        // Replace special functions before evaluating
                        var expression = currentText
                            .Replace("^2", "^2")
                            .Replace("sqrt", "Math.Sqrt")
                            .Replace("pi", "Math.PI")
                            .Replace("e", "Math.E")
                            .Replace("sin", "Math.Sin")
                            .Replace("cos", "Math.Cos")
                            .Replace("tan", "Math.Tan");

                        var result = dataTable.Compute(expression, "");
                        textBox.Text = result.ToString();
                        currentText = result.ToString();
                    }
                    catch (Exception)
                    {
                        textBox.Text = "Error";
                    }
                    break;
                case "C":
                    textBox.Text = string.Empty;
                    currentText = string.Empty;
                    break;
                default:
                    textBox.Text += buttonText;
                    currentText += buttonText;
                    break;
            }
        }
    }
}


