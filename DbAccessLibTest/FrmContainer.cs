using System.Threading;
using System.Windows.Forms;

namespace DbAccessLibTest
{
    public partial class FrmContainer : Form
    {
        public FrmContainer()
        {
            InitializeComponent();
            Hide();
        }

        private void FrmContainer_Load(object sender, System.EventArgs e)
        {
            while (new FrmDbAccessTest().ShowDialog() == DialogResult.OK)
            {
                
            }
            Close();
        }
    }
}
