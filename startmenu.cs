using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird1
{
    public partial class startmenu : Form
    {
        public startmenu()
        {
            InitializeComponent();
        }

        private void GameLoad(object sender, EventArgs e)
        {
            game gamewindow = new game();
            gamewindow.Show();
        }
    }
}
