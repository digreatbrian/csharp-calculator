using System;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.IO;


namespace Calculator_GUI
{
    public partial class MainForm : Form
    {
        private string currentNumber = ""; // Stores the current number being entered

        static string JoinPaths(string path1, string path2) {
            if (!path1.EndsWith("\\")) {
                path1 += "\\";
            }

            if (path2.StartsWith("\\")) {
                path2 = path2.TrimStart('\\');
            }
            return path1 + path2;
        }

        public MainForm()
        {
            InitializeComponent();

            // set icon
            string iconPath = JoinPaths(Application.StartupPath, "icon.ico");

            if (File.Exists(iconPath)) {
                this.Icon = new Icon(iconPath);
            }

            // Event bindings
            button1.Click += on_Button_Click;
            button2.Click += on_Button_Click;
            button3.Click += on_Button_Click;
            button4.Click += on_Button_Click;
            button5.Click += on_Button_Click;
            button6.Click += on_Button_Click;
            button7.Click += on_Button_Click;
            button8.Click += on_Button_Click;
            button9.Click += on_Button_Click;
            button10.Click += on_Button_Click;
            button11.Click += on_Button_Click;
            button12.Click += on_Button_Click;
            button13.Click += on_Button_Click;
            button14.Click += on_Button_Click;
            button15.Click += on_Button_Click;
            button16.Click += on_Button_Click;
            button17.Click += on_Button_Click;
            button18.Click += on_Button_Click;
            button19.Click += on_Button_Click;
            button20.Click += on_Button_Click;
        }

        private void on_Button_Click(object sender, EventArgs e)
        {
            string buttonText = ((Button)sender).Text; // Get text from clicked button

            string[] evalChars = { "=", "+", "-", "x", "/", "%" };
            string[] actionChars = { "AC", "<-" };

            if (actionChars.Contains(buttonText))
            {
                if (buttonText == "AC")
                {
                    label.Text = ""; // Clear label on AC
                    currentNumber = ""; // Clear current number
                    label1.Text = ""; // Clear bottom label
                }
                else if (buttonText == "<-")
                {
                    if (currentNumber.Length > 0)
                    {
                        currentNumber = currentNumber.Substring(0, currentNumber.Length - 1); // Remove last character on Backspace
                        label.Text = currentNumber;
                    }

                    if (label1.Text.Length > 0)
                    {
                        // Update bottom label
                        label1.Text = label1.Text.Substring(0, label1.Text.Length - 1); // Remove last character
                    }
                }
            }
            else if (evalChars.Contains(buttonText))
            {
                if (buttonText == "=")
                {
                    try
                    {
                        DataTable table = new DataTable();
                        var result = table.Compute(currentNumber.Replace("x", "*"), string.Empty);
                        label.Text = result.ToString();
                        label1.Text = currentNumber + "=" + result.ToString();
                        currentNumber = result.ToString();
                    }
                    catch
                    {
                        label.Text = "Error";
                        currentNumber = "";
                    }
                }
                else if (buttonText != "%")
                {
                    currentNumber += buttonText;
                    label.Text = currentNumber;
                    label1.Text += buttonText;
                }
                else
                {
                    // Evaluate percentage
                    try
                    {
                        var percentageValue = double.Parse(currentNumber) / 100;
                        label.Text = percentageValue.ToString();
                        label1.Text = currentNumber + "%=" + percentageValue.ToString();
                        currentNumber = percentageValue.ToString();
                    }
                    catch
                    {
                        label.Text = "Error";
                        currentNumber = "";
                    }
                }
            }
            else
            {
                currentNumber += buttonText;
                label.Text = currentNumber;
                label1.Text += buttonText;
            }

            // Calculate the desired font size based on text length, keeping it within 72
            int desiredFontSize = Math.Min((int)label.Font.Size, (int)label.Font.Size - (label.Text.Length / 2));
            int minimumFontSize = 40;

            if (desiredFontSize < minimumFontSize)
            {
                desiredFontSize = minimumFontSize;
            }

            // Apply the desired font size to the label
            label.Font = new Font(label.Font.FontFamily, desiredFontSize, label.Font.Style);
        }

        private void label_Click(object sender, EventArgs e)
        {
            // pass
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // pass
        }
    }
}
