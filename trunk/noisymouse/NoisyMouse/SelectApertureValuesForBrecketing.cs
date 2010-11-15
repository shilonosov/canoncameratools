using System;
using System.Linq;
using System.Windows.Forms;
using Source;

namespace NoisyMouse
{
    public partial class SelectApertureValuesForBrecketing : Form
    {
        public SelectApertureValuesForBrecketing(EnumValueCollection anAvailableApertureValues)
        {
            InitializeComponent();
            checkedListBox1.Items.AddRange(anAvailableApertureValues.ToArray());
        }

        public Aperture[] Apertures
        {
            get
            {
                Aperture[] result = new Aperture[checkedListBox1.CheckedItems.Count];
                for(int i = 0; i < result.Length; ++i)
                {
                    result[i] = (Aperture)checkedListBox1.CheckedItems[i];
                }
                return result;
            }
        }

        private void SelectApertureValuesForBrecketing_Load(object sender, EventArgs e)
        {
        }
    }
}
