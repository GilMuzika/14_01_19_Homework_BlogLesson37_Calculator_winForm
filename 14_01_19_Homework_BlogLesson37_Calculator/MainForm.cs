using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _14_01_19_Homework_BlogLesson37_Calculator
{
    public partial class MainForm : Form
    {        
        public MainForm()
        {
            InitializeComponent();
            InitialiseCalcButtons();
            currentSimpleCalculator.exportMessage += (object sender, MessageEventArgs e) => { displayLabel.Text = e.StringMessage; };

        }
    }
}
