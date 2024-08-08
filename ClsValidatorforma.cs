using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace K5GLONLINE
{
    class ClsValidatorforma
    {
        private DataGridView dgv1 = null;
        private string Validcbopa;
        private string Validtxtrefer;
        private string Validtxtactremarks;
        private string Validtxtdr;
        private string Validtxtcr;

        private string[] errors = new string[6];
        private string errorMsg = "";

        public ClsValidatorforma(DataGridView dgv)
        {
            dgv1 = dgv;
        }

        public ClsValidatorforma() { }

        public void values(string[] values)
        {
            Validcbopa = values[0];
            Validtxtrefer = values[1];
            Validtxtactremarks = values[2];
            Validtxtdr = values[3];
            Validtxtcr = values[4];
            
        }
/*###### VALIDATIONS #####*/
        private void checkcbopa()
        {
            if (new ClsValidation().emptytxt(Validcbopa))
                errors[0] = "Please enter account title";
            else
                errors[0] = "";
        }

        private void checktxtrefer()
        {
            if (new ClsValidation().emptytxt(Validtxtrefer))
                errors[1] = "Please enter reference";
            else
                errors[1] = "";
        }

        private void checktxtactremarks()
        {
            if (new ClsValidation().emptytxt(Validtxtactremarks))
                errors[2] = "Please enter remarks";
            else
                errors[2] = "";
        }

        private void checktxtdr()
        {
            if (new ClsValidation().emptytxt(Validtxtdr))
                errors[3] = "Please enter debit";
            else
                errors[3] = "";
        }

        private void checktxtcr()
        {
            if (new ClsValidation().emptytxt(Validtxtcr))
                errors[4] = "Please enter credit";
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

            checkcbopa();
            checktxtrefer();
            checktxtactremarks();
            checktxtdr();
            checktxtcr();
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
