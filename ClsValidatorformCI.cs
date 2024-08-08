using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace K5GLONLINE
{
    class ClsValidatorformCI
    {
        private DataGridView dgv2 = null;
        private string ValidControlCode;
        private string ValidChassisNo;
        private string ValidUnitDesc;
        private string ValidtxtUnitCost;
        private string ValidtxtUnitPrice;

        private string[] errors = new string[6];
        private string errorMsg = "";

        public ClsValidatorformCI(DataGridView dgv)
        {
            dgv2 = dgv;
        }

        public ClsValidatorformCI() { }

        public void values(string[] values)
        {
            ValidControlCode = values[0];
            ValidChassisNo = values[1];
            ValidUnitDesc = values[2];
            ValidtxtUnitCost = values[3];
            ValidtxtUnitPrice = values[4];
        }
/*###### VALIDATIONS #####*/
 
        private void checkControlCode()
        {
            if (string.IsNullOrEmpty(ValidControlCode))
                errors[0] = "Please enter Engine No.";
            else
                errors[0] = "";
        }

        private void checkChassisNo()
        {
            if (string.IsNullOrEmpty(ValidChassisNo))
                errors[1] = "Please enter Chassis No.";
            else
                errors[1] = "";
        }

        private void checkUnitDesc()
        {
            if (string.IsNullOrEmpty(ValidUnitDesc))
                errors[2] = "Please enter Unit Description.";
            else
                errors[2] = "";
        }

        private void checktxtUnitCost()
        {
            if (string.IsNullOrEmpty(ValidtxtUnitCost))
                errors[3] = "Please enter unit cost";
            else
                errors[3] = "";
        }

        private void checktxtUnitPrice()
        {
            if (string.IsNullOrEmpty(ValidtxtUnitPrice))
                errors[4] = "Please enter unit price";
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

            checkControlCode();
            checkChassisNo();
            checkUnitDesc();
            checktxtUnitCost();
            checktxtUnitPrice();
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
