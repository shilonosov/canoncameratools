using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace CommonUI
{
    public class UIHelper
    {
        public static void FillComboBoxWith(ComboBox aComboBox, IEnumerable aValues, object aDefaultValue)
        {
            aComboBox.BeginUpdate();
            aComboBox.Items.Clear();

            foreach (object obj in aValues)
            {
                aComboBox.Items.Add(obj);
            }

            aComboBox.Enabled = (aComboBox.Items.Count > 0);
            aComboBox.SelectedItem = aDefaultValue;

            aComboBox.EndUpdate();
        }
    }
}
