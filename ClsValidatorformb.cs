using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace K5GLONLINE
{
    class ClsValidatorformb
    {
        private DataGridView dgv2 = null;
        private string validdgv2StockNumber;
        private string validdgv2Item;
        private string validdgv2ChickIn;
        private string validdgv2ChickOut;
        private string validdgv2In;
        private string validdgv2Out;
        private string validdgv2UM;
        private string validdgv2UC;
        private string validdgv2Cost;

        private string[] errors = new string[10];
        private string errorMsg = "";

        public ClsValidatorformb(DataGridView dgv)
        {
            dgv2 = dgv;
        }

        public ClsValidatorformb() { }

        public void values(string[] values)
        {
            validdgv2StockNumber = values[0];
            validdgv2Item = values[1];
            validdgv2ChickIn = values[2];
            validdgv2ChickOut = values[3];
            validdgv2In = values[4];
            validdgv2Out = values[5];
            validdgv2UM = values[6];
            validdgv2UC = values[7];
            validdgv2Cost = values[8];

        }
/*###### VALIDATIONS #####*/

        private void checkdgv2StockNumber()
        {
            if (string.IsNullOrEmpty(validdgv2StockNumber))
                errors[0] = "Please enter stock number.";
            else
                errors[0] = "";
        }

        private void checkdgv2Item()
        {
            if (string.IsNullOrEmpty(validdgv2Item))
                errors[1] = "Please enter description.";
            else
                errors[1] = "";
        }

        private void checkdgv2ChickIn()
        {
            if (string.IsNullOrEmpty(validdgv2ChickIn))
                errors[2] = "Please enter qty-in.";
            else
                errors[2] = "";
        }

        private void checkdgv2ChickOut()
        {
            if (string.IsNullOrEmpty(validdgv2ChickOut))
                errors[3] = "Please enter qty-out.";
            else
                errors[3] = "";
        }

        private void checkdgv2In()
        {
            if (string.IsNullOrEmpty(validdgv2In))
                errors[4] = "Please enter weight/qty-in.";
            else
                errors[4] = "";
        }

        private void checkdgv2Out()
        {
            if (string.IsNullOrEmpty(validdgv2Out))
                errors[5] = "Please enter weight/qty-out.";
            else
                errors[5] = "";
        }

        private void checkdgv2UM()
        {
            if (string.IsNullOrEmpty(validdgv2UM))
                errors[6] = "Please enter um.";
            else
                errors[6] = "";
        }

        private void checkdgv2UC()
        {
            if (string.IsNullOrEmpty(validdgv2UC))
                errors[7] = "Please enter unit cost.";
            else
                errors[7] = "";
        }

        private void checkdgv2Cost()
        {
            if (string.IsNullOrEmpty(validdgv2Cost))
                errors[8] = "Please enter total cost.";
            else
                errors[8] = "";
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

            checkdgv2StockNumber ();
            checkdgv2Item ();
            checkdgv2ChickIn();
            checkdgv2ChickOut ();
            checkdgv2In();
            checkdgv2Out ();
            checkdgv2UM ();
            checkdgv2UC ();
            checkdgv2Cost ();
            errors[9] = "";


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
