using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace K5GLONLINE
{
    class ASValidator
    {
        private DataGridView dgv1 = null;
        private string StockNumber;
        private string QIn;
        private string QOut;
        private string Worker;
        private string Palita;

        private string[] errors = new string[6];
        private string errorMsg = "";

        public ASValidator(DataGridView dgv)
        {
            dgv1 = dgv;
        }

        public ASValidator() { }

        public void values(string[] values)
        {
            StockNumber = values[1];
            QIn = values[2];
            QOut = values[3];
            Worker = values[4];
            Palita = values[5];
            
        }
/*###### VALIDATIONS #####*/
        private void checkCode()
        {
            if (string.IsNullOrEmpty(StockNumber))
                errors[0] = "Please enter product name";
            else
                errors[0] = "";
        }

        private void checkQIn()
        {
            if (new ClsValidation().isInt(QIn) == true)
                errors[1] = "Please enter valid integer amount";
            else
                errors[1] = "";
        }

        private void checkQOut()
        {
            if (new ClsValidation().isInt(QOut) == true)
                errors[2] = "Please enter valid integer amount";
            else
                errors[2] = "";
        }
        private void checkworker()
        {
            if (string.IsNullOrEmpty(Worker))
                errors[3] = "Please enter group of workers";
            else
                errors[3] = "";
        }

        private void checkpalita()
        {
            if (string.IsNullOrEmpty(Palita))
                errors[4] = "Please enter palita number";
            else
                errors[4] = "";
        }
        /*###### #############*/

        private void setErrorMessage()
        {

            errorMsg = "";

            for (int x = 0; x < errors.Length; x++)
            {
                if (!errors[x].Equals(""))
                    errorMsg += errors[x] + "\n";
            }
        }
        //VALIDATION FOR ADDING ASSET
        public bool validate()
        {

            checkCode();
            checkQIn();
            checkQOut();
            checkworker();
            checkpalita();
            errors[5] = "";


            setErrorMessage();

            if (!errorMsg.Equals(""))
            {
                MessageBox.Show(errorMsg);
                return false;
            }
            else
                return true;

        }


    }
}
