using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace K5GLONLINE
{
    class ClsValidatorformVAT
    {
        private DataGridView dgv1 = null;
        private string Validtxtpa;
        private string Validcbopa;
        private string Validtxtgross;
        private string Validtxtvat;
        private string Validtxtnet;

        private string[] errors = new string[6];
        private string errorMsg = "";

         public ClsValidatorformVAT(DataGridView dgv)
        {
            dgv1 = dgv;
        }

        public ClsValidatorformVAT() { }

        public void values(string[] values)
        {
            Validtxtpa = values[0];
            Validcbopa = values[1];
            Validtxtgross = values[2];
            Validtxtvat = values[3];
            Validtxtnet = values[4];
        }

        /*###### VALIDATIONS #####*/
        private void checktxtpa()
        {
            if (new ClsValidation().emptytxt(Validtxtpa))
                errors[0] = "Please enter account title";
            else
                errors[0] = "";
        }

        private void checkcbopa()
        {
            if (new ClsValidation().emptytxt(Validcbopa))
                errors[1] = "Please enter account title";
            else
                errors[1] = "";
        }

        private void checktxtgross()
        {
            if (new ClsValidation().emptytxt(Validtxtgross))
                errors[2] = "Please enter gross";
            else
                errors[2] = "";
        }

        private void checktxtvat()
        {
            if (new ClsValidation().emptytxt(Validtxtvat))
                errors[3] = "Please enter vat";
            else
                errors[3] = "";
        }

        private void checktxtnet()
        {
            if (new ClsValidation().emptytxt(Validtxtnet))
                errors[4] = "Please enter net";
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
            checktxtpa();
            checkcbopa();
            checktxtgross();
            checktxtvat();
            checktxtnet();
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
