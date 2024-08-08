using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace K5GLONLINE
{
    class ClsVariousFormula
    {
        public double pldtotalactdisc;
        private double privdd1, privdd2, privdd3;
        public double pldbVAT;

        public void getActDisct(double grossamt, double vardd1, double vardd2, double vardd3)
        {
            privdd1 = grossamt * vardd1;
            privdd2 = (grossamt - privdd1)*vardd2;
            privdd3 = (grossamt - (privdd1 + privdd2))*vardd3;
            pldtotalactdisc = privdd1 + privdd2 + privdd3;
        }

        public void getVATAmt(bool varVAT, double varVATRate, double varNetSalesAmt)
        {
            if (varVAT == false)
            {
                pldbVAT = 0;
            }
            else
            {
                double varPrincipal = varNetSalesAmt / (varVATRate);
                pldbVAT = varNetSalesAmt - varPrincipal;
            }
        }
      
    }
}
