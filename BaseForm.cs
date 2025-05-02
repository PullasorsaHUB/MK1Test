using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MyMK1
{
    public class BaseForm : Form
    {
        public BaseForm()
        {

            if(AppSession.LastFormLocation != Point.Empty)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Load += BaseForm_Load;
            }
            else
            {
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            this.FormClosed += BaseForm_FormClosed;
        }
        private void BaseForm_Load(object sender, EventArgs e)
        {
            this.Location = AppSession.LastFormLocation;
        }
        private void BaseForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AppSession.LastFormLocation = this.Location;
        }
    }
}
