using System.Windows.Forms;

namespace NoisyMouse
{
    public partial class SelectExposalBracketingParameters : Form
    {
        public SelectExposalBracketingParameters()
        {
            InitializeComponent();
        }

        public int Step
        {
            get { return (int) stepNumericUpDown.Value; }
        }

        public int Count
        {
            get { return (int) countNumericUpDown.Value; }
        }
    }
}
