using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace K5GLONLINE
{
    public class moveNextCellDataGridView : DataGridView
    {
        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                moveToNextCell();
                return true;
            }
            return base.ProcessDataGridViewKey(e);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                moveToNextCell();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        public void moveToNextCell()
        {
            int currentRowIndex = this.CurrentCell.RowIndex;
            int currentColumnIndex = this.CurrentCell.ColumnIndex;

            if (currentColumnIndex == Columns.Count - 1 && currentRowIndex != Rows.Count - 1)
            {
                base.ProcessDataGridViewKey(new KeyEventArgs(Keys.Home));
                base.ProcessDataGridViewKey(new KeyEventArgs(Keys.Down));
            }
            else
                base.ProcessDataGridViewKey(new KeyEventArgs(Keys.Right));
        }
    }
}
