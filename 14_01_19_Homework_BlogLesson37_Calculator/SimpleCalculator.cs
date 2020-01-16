using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_01_19_Homework_BlogLesson37_Calculator
{
    class SimpleCalculator
    { 
        
        public event EventHandler<MessageEventArgs> exportMessage;
        private void OnButtonClickedMessage(string message)
        {
            if(exportMessage != null)
            {
                exportMessage.Invoke(this, new MessageEventArgs(message));
            }
        }

        private List<Dictionary<string, float>> numbersAndOperations = new List<Dictionary<string, float>>();       

        private Dictionary<string, float> numberOperationPair;
        private float numberGetterButtonClick_clicking;
        private string numberGetterButtonClick_clickingAsString = string.Empty;
        private string allUntilEqualSign = string.Empty;

        private float intermediateResultCalculateMethod = 0;

        private Dictionary<string, Func<float, float, float>> storedOperationFunctions = new Dictionary<string, Func<float, float, float>>();
        public SimpleCalculator()
        {
            storedOperationFunctions.Add("+", (float n1, float n2) => { return n1 + n2; });
            storedOperationFunctions.Add("-", (float n1, float n2) => { return n1 - n2; });
            storedOperationFunctions.Add("*", (float n1, float n2) => { return n1 * n2; });
            storedOperationFunctions.Add("/", (float n1, float n2) => { return n1 / n2; });
            //because of the statement "i < numbersAndOperations.Count - 1" in the 'for' loop the dictionary with the delegate of the "=" sign never will be used, because of it's last posiition in the "numbersAndOperations" list.
            //storedOperationFunctions.Add("=", (float n1, float n2) => { return intermediateResultCalculateMethod; });                            
        }

        public void NumberGetterButtonClick(string whatOnButton)
        {           
            numberGetterButtonClick_clickingAsString += whatOnButton;            
            float.TryParse(numberGetterButtonClick_clickingAsString, out numberGetterButtonClick_clicking);

            allUntilEqualSign = numberGetterButtonClick_clickingAsString;
            OnButtonClickedMessage(allUntilEqualSign);
        }
        public void OperationGetterButtonClick(string whatOnButton)
        {
            if (String.IsNullOrEmpty(numberGetterButtonClick_clickingAsString))
                numberGetterButtonClick_clicking = intermediateResultCalculateMethod;

            numberGetterButtonClick_clickingAsString = string.Empty;

            numberOperationPair = new Dictionary<string, float>();
            numberOperationPair.Add(whatOnButton, numberGetterButtonClick_clicking);
            numbersAndOperations.Add(numberOperationPair);
            //if (operationButonClickedMoreThanOnce && whatOnButton != "=") OnButtonClickedMessage($"You're clicked on a math operation button more than once.\n Only the last clicking value will be used.\n The last value is {whatOnButton}");//MessageBox.Show($"You're clicked on a math operation button more than once.\n Only the last clicking value will be used.\n The last value is {(sender as Button).Text}");
            allUntilEqualSign += whatOnButton;
            OnButtonClickedMessage(allUntilEqualSign);

        }

        
        public void Calculate()
        {
            

            float intermediateRez = 0;
            for (int i = 0; i < numbersAndOperations.Count - 1; i++)
            {
                float input;
                if (i == 0) input = numbersAndOperations[i].Values.First();
                else input = intermediateRez;

                intermediateRez = storedOperationFunctions[numbersAndOperations[i].Keys.First()](input, numbersAndOperations[i + 1].Values.First());
                intermediateResultCalculateMethod = intermediateRez;

            }

            //DisplaynumbersAndOperations();       
            numbersAndOperations.Clear();
            //return intermediateRez;
            OnButtonClickedMessage(intermediateRez.ToString());
            
        }

        private void DisplaynumbersAndOperations()
        {
            string str = string.Empty;
            foreach (Dictionary<string, float> s in numbersAndOperations)
            {
                foreach (KeyValuePair<string, float> ss in s)
                {
                    str += $"{ss.Key}: {ss.Value}\n";
                }
                str += "--------------------\n";
            }
            OnButtonClickedMessage(str);
        }

    }
}
