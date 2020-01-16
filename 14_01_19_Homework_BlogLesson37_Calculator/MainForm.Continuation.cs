using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _14_01_19_Homework_BlogLesson37_Calculator
{
    partial class MainForm
    {
        private SimpleCalculator currentSimpleCalculator = new SimpleCalculator();
        private Panel buttonsPanel = new Panel();
        private Panel displayPanel = new Panel();
        private Label displayLabel = new Label();

        private const int BUTTON_WIDTH = 40;
        private const int BUTTON_HEIGHT = 40;
        private const int DISTANSE_BETWEEN_BUTTONS = 20;
        private const int BUTTON_INDENTION = 50;

        private int buttonCount = 1;
        private void InitialiseCalcButtons()
        {

            string[] operations = new string[] { "+", "-", "*", "/", "=" };
            Button[,] buttons = new Button[3,3];

            buttonsPanel.Height = (operations.GetLength(0) + 1) * BUTTON_HEIGHT + DISTANSE_BETWEEN_BUTTONS * (operations.GetLength(0) + 1);
            buttonsPanel.Width = (buttons.GetLength(1) + 1) * BUTTON_WIDTH + DISTANSE_BETWEEN_BUTTONS * (buttons.GetLength(1) + 1); 
            buttonsPanel.Location = new System.Drawing.Point(10,60);
            buttonsPanel.drawBorder(1, Color.Black);
            this.Controls.Add(buttonsPanel);

            this.Width = buttonsPanel.Width + 35;

            displayLabel.AutoSize = true;
            displayLabel.Location = new Point(5, 5);

            displayPanel.Width = buttonsPanel.Width;
            displayPanel.Height = 45;
            displayPanel.Location = new Point(10, 10);
            displayPanel.drawBorder(1, Color.Black);
            displayPanel.Controls.Add(displayLabel);
            this.Controls.Add(displayPanel);

            for(int i = 0; i < buttons.GetLength(0); i++)
            {
                for (int j = 0; j < buttons.GetLength(1); j++)
                {
                    Button butt = new Button();
                    butt.Text = buttonCount.ToString();                    
                    butt.Click += new EventHandler((object sender, EventArgs e) => { currentSimpleCalculator.NumberGetterButtonClick((sender as Button).Text); }); //currentSimpleCalculator.NumberGetterButtonClick
                    butt.Width = BUTTON_WIDTH; butt.Height = BUTTON_HEIGHT;
                    butt.Location = new System.Drawing.Point(j* BUTTON_INDENTION + DISTANSE_BETWEEN_BUTTONS, i* BUTTON_INDENTION + DISTANSE_BETWEEN_BUTTONS);
                    //butt.drawBorder(20, Color.Blue);
                    buttons[i, j] = butt;
                    buttonsPanel.Controls.Add(butt);
                    buttonCount++;
                }
            }
            Button butt2 = new Button();
            butt2.Text = "0";
            butt2.Click += new EventHandler((object sender, EventArgs e) => { currentSimpleCalculator.NumberGetterButtonClick((sender as Button).Text); }); //currentSimpleCalculator.NumberGetterButtonClick
            butt2.Width = BUTTON_WIDTH; butt2.Height = BUTTON_HEIGHT;
            butt2.Location = new System.Drawing.Point(buttons[2, 1].Location.X , buttons[2, 1].Location.Y + butt2.Height + DISTANSE_BETWEEN_BUTTONS/2);
            //butt2.drawBorder(20, Color.Red);
            buttonsPanel.Controls.Add(butt2);

            Button butt3 = new Button();
            butt3.Text = ".";
            butt3.Click += new EventHandler((object sender, EventArgs e) => { currentSimpleCalculator.NumberGetterButtonClick((sender as Button).Text); }); //currentSimpleCalculator.NumberGetterButtonClick
            butt3.Width = BUTTON_WIDTH; butt3.Height = BUTTON_HEIGHT;
            butt3.Location = new System.Drawing.Point(buttons[2, 0].Location.X, buttons[2, 0].Location.Y + butt3.Height + DISTANSE_BETWEEN_BUTTONS / 2);
            //butt3.drawBorder(20, Color.Maroon);
            buttonsPanel.Controls.Add(butt3);

            Button butt4 = new Button();
            butt4.Text = "NEG\n-";
            butt4.Click += new EventHandler((object sender, EventArgs e) => { currentSimpleCalculator.NumberGetterButtonClick("-"); }); //currentSimpleCalculator.NumberGetterButtonClick
            butt4.Width = BUTTON_WIDTH; butt4.Height = BUTTON_HEIGHT;
            butt4.Location = new System.Drawing.Point(butt3.Location.X, butt3.Location.Y + butt4.Height + DISTANSE_BETWEEN_BUTTONS / 2);            
            //butt4.drawBorder(20, Color.Maroon);
            buttonsPanel.Controls.Add(butt4);

            for (int i = 0; i < operations.Length; i++)
            {
                Button butt = new Button();
                butt.Text = operations[i];
                butt.Width = BUTTON_WIDTH; butt.Height = BUTTON_HEIGHT;
                butt.Click += new EventHandler((object sender, EventArgs e) => { currentSimpleCalculator.OperationGetterButtonClick((sender as Button).Text); }); //currentSimpleCalculator.OperationGetterButtonClick
                butt.Location = new System.Drawing.Point(buttons[2,2].Location.X + BUTTON_WIDTH + DISTANSE_BETWEEN_BUTTONS, buttons[0, 0].Location.Y+i * BUTTON_INDENTION);
                //butt.drawBorder(20, Color.Green);
                if (i == (operations.Count() - 1))
                {
                    butt.Location = new System.Drawing.Point(butt2.Location.X + BUTTON_WIDTH + DISTANSE_BETWEEN_BUTTONS/2, butt2.Location.Y);
                    //butt.Click += (object sender, EventArgs e) => { MessageBox.Show(currentSimpleCalculator.Calculate().ToString()); };
                    butt.Click += (object sender, EventArgs e) => { currentSimpleCalculator.Calculate(); };
                }
                buttonsPanel.Controls.Add(butt);


            }
        }

    }
}
