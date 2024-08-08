using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
//using K5GLV3.FldrVoucher;

namespace K5GLONLINE

{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void nameAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerNameAdd frmCustomerNameAdd1 = new frmCustomerNameAdd();
            frmCustomerNameAdd1.Show();
        }

        private void nameEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerNameEdit frmCustomerNameEdit1 = new frmCustomerNameEdit();
            frmCustomerNameEdit1.Show();
        }



        private void userAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserAdd frmUserAdd1 = new frmUserAdd();
            frmUserAdd1.Show();
        }

        private void gRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmusergroup frmusergroup1 = new frmusergroup();
            frmusergroup1.Show();
        }

        private void membershipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmusermembership frmusermembership1 = new frmusermembership();
            frmusermembership1.Show();
        }

        private void permissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmuserpermission frmuserpermission1 = new frmuserpermission();
            frmuserpermission1.Show();
        }


        private void clientAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerNameAdd frmCustomerNameAdd1 = new frmCustomerNameAdd();
            frmCustomerNameAdd1.Show();
        }

        private void clientEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerNameEdit frmCustomerNameEdit1 = new frmCustomerNameEdit();
            frmCustomerNameEdit1.Show();
        }




        private void checkVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVoucherCV frmVoucherCV1 = new frmVoucherCV();
            frmVoucherCV1.Show();
        }


        private void journalVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVoucherJV frmVoucherJV1 = new frmVoucherJV();
            frmVoucherJV1.Show();
        }

        private void accountsPayableVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVoucherAPV frmVoucherAPV1 = new frmVoucherAPV();
            frmVoucherAPV1.Show();
        }

        private void variousDocumentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVoucherARV frmVoucherARV1 = new frmVoucherARV();
            frmVoucherARV1.Show();
        }



        private void viewHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }




        private void subsidiaryLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }




        private void othersAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOtherNameAdd frmOtherNameAdd1 = new frmOtherNameAdd();
            frmOtherNameAdd1.Show();
        }

        private void othersEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOtherNameEdit frmOtherNameEdit1 = new frmOtherNameEdit();
            frmOtherNameEdit1.Show();
        }

        private void postingAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCAPAAdd frmCAPAAdd1 = new frmCAPAAdd();
            frmCAPAAdd1.Show();
        }

        private void department2AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCADept2 frmCADept21 = new frmCADept2();
            frmCADept21.Show();
        }

        private void accountTitleAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCAMainAcctAdd frmCAMainAcctAdd1 = new frmCAMainAcctAdd();
            frmCAMainAcctAdd1.Show();
        }

        private void accounTitleEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCAMainAcctEdit frmCAMainAcctEdit1 = new frmCAMainAcctEdit();
            frmCAMainAcctEdit1.Show();
        }

        private void postingAccountEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCAPAEdit frmCAPAEdit1 = new frmCAPAEdit();
            frmCAPAEdit1.Show();
        }

        private void departToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCADept2Edit frmCADept2Edit1 = new frmCADept2Edit();
            frmCADept2Edit1.Show();
        }

        private void department1AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCADept1Add frmCADept1Add1 = new frmCADept1Add();
            frmCADept1Add1.Show();
        }

        private void department2EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCADept1Edit frmCADept1Edit1 = new frmCADept1Edit();
            frmCADept1Edit1.Show();
        }

        private void bookOfAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void trialBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmrptFS frmrptFS1 = new frmrptFS();
            //frmrptFS1.Show();
        }

        private void checkWriterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCheckWriter frmCheckWriter1 = new frmCheckWriter();
            frmCheckWriter1.Show();
        }

        private void viewMainAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCAViewMainAccount frmCAViewMainAccount1 = new frmCAViewMainAccount();
            frmCAViewMainAccount1.Show();
        }

        private void viewSubAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCAViewSubAccount frmCAViewSubAccount1 = new frmCAViewSubAccount();
            frmCAViewSubAccount1.Show();
        }




        private void chargeInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVoucherCI frmVoucherCI1 = new frmVoucherCI();
            frmVoucherCI1.Show();
        }

        private void inventorySummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cashSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVoucherCS frmVoucherCS1 = new frmVoucherCS();
            frmVoucherCS1.Show();
        }

        private void officialReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVoucherOR frmVoucherOR1 = new frmVoucherOR();
            frmVoucherOR1.Show();
        }

        private void agingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmrptAging frmrptAging1 = new frmrptAging();
            frmrptAging1.Show();
        }

        private void returnSlipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVoucherRS frmVoucherRS1 = new frmVoucherRS();
            frmVoucherRS1.Show();
        }

        private void transferFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVoucherTF frmVoucherTF1 = new frmVoucherTF();
            frmVoucherTF1.Show();
        }

        private void salesOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVoucherSO frmVoucherSO1 = new frmVoucherSO();
            frmVoucherSO1.Show();
        }

        private void adjustmentSlipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVoucherAS frmVoucherAS1 = new frmVoucherAS();
            frmVoucherAS1.Show();
        }

        private void pickListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmrptPickList frmrptPickList1 = new frmrptPickList();
            frmrptPickList1.Show();
        }

        private void purchaseDeliveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVoucherPD frmVoucherPD1 = new frmVoucherPD();
            frmVoucherPD1.Show();
        }

        private void individualLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void remittanceVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVoucherRV frmVoucherRV1 = new frmVoucherRV();
            frmVoucherRV1.Show();
        }

        private void actualInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVoucherAI frmVoucherAI1 = new frmVoucherAI();
            frmVoucherAI1.Show();
        }

        private void salesmanCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void applyRemittancToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        private void journalVoucherToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmEditVouchers frmEditVouchers1 = new frmEditVouchers();
            frmEditVouchers1.Show();
        }



        private void internetResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReset frmReset1 = new frmReset();
            frmReset1.Show();
        }

        private void salesmanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmrptSalesRpt frmrptSalesRpt1 = new frmrptSalesRpt();
            frmrptSalesRpt1.Show();
        }

        private void customerCellphoneNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerNameCellNo frmCustomerNameCellNo1 = new frmCustomerNameCellNo();
            frmCustomerNameCellNo1.Show();
        }

        private void salesmanIncludeSkyTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEntrySalesmanSkytextInclude frmEntrySalesmanSkytextInclude1 = new frmEntrySalesmanSkytextInclude();
            frmEntrySalesmanSkytextInclude1.Show();
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmrptSalesSupplier frmrptSalesSupplier1 = new frmrptSalesSupplier();
            frmrptSalesSupplier1.Show();
        }

        private void principalToIncludeSFATransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTransferSFAPrincipal frmTransferSFAPrincipal1 = new frmTransferSFAPrincipal();
            frmTransferSFAPrincipal1.Show();
        }

        private void salesmanSFACodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTransferSFASalesmanCode frmTransferSFASalesmanCode1 = new frmTransferSFASalesmanCode();
            frmTransferSFASalesmanCode1.Show();
        }

        private void principalSasidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTransferSFAPrincipalSasid frmTransferSFAPrincipalSasid1 = new frmTransferSFAPrincipalSasid();
            frmTransferSFAPrincipalSasid1.Show();
        }

        private void movementToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listOfCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmrptCustomerList frmrptCustomerList1 = new frmrptCustomerList();
            frmrptCustomerList1.Show();
        }

        private void returnToSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVoucherTRS frmVoucherTRS1 = new frmVoucherTRS();
            frmVoucherTRS1.Show();
        }

        private void expandedWithheldTaxToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmrptSalesCustomer frmrptSalesCustomer1 = new frmrptSalesCustomer();
            frmrptSalesCustomer1.Show();
        }

        private void truckAuditToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblVer.Text = "Version " + Form1.glblLblVer.Text;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void shrinkageDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void supplierEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSupplierEdit frmSupplierEdit1 = new frmSupplierEdit();
            frmSupplierEdit1.Show();
        }

        private void financialStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmrptFS frmrptFS1 = new frmrptFS();
            frmrptFS1.Show();
        }

        private void subsidiaryLedgerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmrptSubsidiaryLedger frmrptSubsidiaryLedger1 = new frmrptSubsidiaryLedger();
            frmrptSubsidiaryLedger1.Show();

        }

        private void individualLedgerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmrptIndLedger frmrptIndLedger1 = new frmrptIndLedger();
            frmrptIndLedger1.Show();
        }

        private void individualVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmrptVoucher frmrptVoucher1 = new frmrptVoucher();
            frmrptVoucher1.Show();
        }

        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmrptBooks frmrptBooks1 = new frmrptBooks();
            frmrptBooks1.Show();
        }

        private void salesmanCollectionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmrptSalesmanCollect frmrptSalesmanCollect1 = new frmrptSalesmanCollect();
            frmrptSalesmanCollect1.Show();
        }

        private void applyRemittanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRemittanceApply frmRemittanceApply1 = new frmRemittanceApply();
            frmRemittanceApply1.Show();
        }

        private void creditableWithheldTaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEWT frmEWT1 = new frmEWT();
            frmEWT1.Show();
        }

        private void truckAuditToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmrptTruckAudit frmrptTruckAudit1 = new frmrptTruckAudit();
            frmrptTruckAudit1.Show();

        }

        private void shrinkageDetailsInASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmrptShrinkageAS frmrptShrinkageAS1 = new frmrptShrinkageAS();
            frmrptShrinkageAS1.Show();
        }

        private void movementToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmrptMovement frmrptMovement1 = new frmrptMovement();
            frmrptMovement1.Show();
        }

        private void returnPerCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmrptReturnCustomer frmrptReturnCustomer1 = new frmrptReturnCustomer();
            frmrptReturnCustomer1.Show();
        }

        private void productAvailableForSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductAFS frmProductAFS1 = new frmProductAFS();
            frmProductAFS1.Show();
        }

        private void gridFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmrptSalesCustomer2().Show();
        }

        private void productSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmProductSetup().Show();
        }

        private void warehouseEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmWarehouseEdit().Show();
        }

        private void inventorySummaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmrptInventory frmrptInventory1 = new frmrptInventory();
            frmrptInventory1.Show();
        }

        private void inventoryExpirationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmrptInventoryExpiration frmrptInventoryExpiration1 = new frmrptInventoryExpiration();
            frmrptInventoryExpiration1.Show();

        }

        private void recToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmrptReceivableStatus frmrptReceivableStatus1 = new frmrptReceivableStatus();
            frmrptReceivableStatus1.Show();
        }

        private void claimSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmrptClaimSummary frmrptClaimSummary1 = new frmrptClaimSummary();
            frmrptClaimSummary1.Show();
        }

        private void manifestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
            frmVoucherManifest frmVoucherManifest1 = new frmVoucherManifest();
            frmVoucherManifest1.Show();
        }

        private void pickListToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmVoucherPLNo frmVoucherPLNo1 = new frmVoucherPLNo();
            frmVoucherPLNo1.Show();
        }

        private void pickListNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmrptPickListNumber frmVoucherPLNo1 = new frmrptPickListNumber();
            frmVoucherPLNo1.Show();
        }

        private void dailySalesAndCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVoucherDSCR frmVoucherDSCR1 = new frmVoucherDSCR();
            frmVoucherDSCR1.Show();
        }

        private void salesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmrptDoleSales frmrptDoleSales1 = new frmrptDoleSales();
            frmrptDoleSales1.Show();

        }

        private void inventoryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmDoleInventory frmDoleInventory1 = new frmDoleInventory();
            frmDoleInventory1.Show();

        }

        private void suggestedOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmrptSuggestedOrder frmrptSuggestedOrder1 = new frmrptSuggestedOrder();
            frmrptSuggestedOrder1.Show();
        }

        private void shrinkageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmrptShrinkageDetails frmrptShrinkageDetails1 = new frmrptShrinkageDetails();
            frmrptShrinkageDetails1.Show();
        }

        private void productBlockingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEntryProductBlocking frmEntryProductBlocking1 = new frmEntryProductBlocking();
            frmEntryProductBlocking1.Show();
        }

        private void salesOrderEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVoucherSOEdit frmVoucherSOEdit1 = new frmVoucherSOEdit();
            frmVoucherSOEdit1.Show();
        }

        private void bOSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmrptBOSumm frmrptBOSumm1 = new frmrptBOSumm();
            frmrptBOSumm1.Show();
        }

        private void salesmanCustomReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmrptSalesmanCustom frmrptSalesmanCustom1 = new frmrptSalesmanCustom();
            frmrptSalesmanCustom1.Show();
        }

        private void dOLEInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoleInventory frmDoleInventory1 = new frmDoleInventory();
            frmDoleInventory1.Show();
        }

        private void updatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdates frmUpdates1 = new frmUpdates();
            frmUpdates1.Show();
        }

        private void salesForceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmrptSalesForce frmrptSalesForce1 = new frmrptSalesForce();
            frmrptSalesForce1.Show();
        }

        private void checkSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCheckSearch frmCheckSearch1 = new frmCheckSearch();
            frmCheckSearch1.Show();
        }

        private void geographicalAreaEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGAEdit frmGAEdit1 = new frmGAEdit();
            frmGAEdit1.Show();
        }

        private void salesmanProductBlockingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEntrySMProductBlocking frmEntrySMProductBlocking1 = new frmEntrySMProductBlocking();
            frmEntrySMProductBlocking1.Show();
        }

        private void salesmanEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSMEdit frmSMEdit1 = new frmSMEdit();
            frmSMEdit1.Show();
        }

        private void searchEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSearchEntry frmSearchEntry1 = new frmSearchEntry();
            frmSearchEntry1.Show();
        }

        private void unservedReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmprptUnserveRepo().Show();
        }
    }
}
