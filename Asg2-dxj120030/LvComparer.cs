using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// COURTESY OF PROF. COLE

namespace Asg2_dxj120030
{
    /**************************************************************************
     * Class for comparing listview items in general on the selected column.
     **************************************************************************/
    public class LvComparer : IComparer
    {
        private int col;
        private SortOrder _order;
        public LvComparer()
        {
            col = 0;
        }

        public LvComparer(int pCol)
        {
            col = pCol;
        }

        public int Compare(object l1, object l2)
        {
            int retVal = -1;
            // Make sure we actually have in the items the columns being compared.
            if (((ListViewItem)l1).SubItems.Count > col && ((ListViewItem)l2).SubItems.Count > col)
            {
                // If the text is right-aligned, this is a numeric column and must be
                // compared as decimal.
                if (((ListViewItem)l1).ListView.Columns[col].TextAlign == HorizontalAlignment.Right)
                {
                    Decimal d1, d2;
                    if (!decimal.TryParse(((ListViewItem)l1).SubItems[col].Text.Replace(",", "").Replace("$", ""), out d1))
                        d1 = 0;
                    if (!decimal.TryParse(((ListViewItem)l2).SubItems[col].Text.Replace(",", "").Replace("$", ""), out d2))
                        d2 = 0;
                    retVal = decimal.Compare(d1, d2);
                }
                else if (((ListViewItem)l1).ListView.Columns[col].Text.ToLower().Contains("date"))
                {
                    DateTime dt1, dt2;
                    dt1 = Convert.ToDateTime(((ListViewItem)l1).SubItems[col].Text);
                    dt2 = Convert.ToDateTime(((ListViewItem)l2).SubItems[col].Text);
                    retVal = DateTime.Compare(dt1, dt2);
                }
                else
                {
                    // Compare any other alignment as string.
                    retVal = string.Compare(((ListViewItem)l1).SubItems[col].Text, ((ListViewItem)l2).SubItems[col].Text);
                }
            }
            if (_order == SortOrder.Ascending)
                retVal = retVal * -1;
            return retVal;
        }

        public int SortColumn
        {
            set { col = value; }
            get { return col; }
        }

        public SortOrder Order
        {
            set { _order = value; }
            get { return _order; }
        }
    }
}