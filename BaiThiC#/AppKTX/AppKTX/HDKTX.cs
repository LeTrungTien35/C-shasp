using System;
using System.Drawing;
using System.Windows.Forms;
namespace AppKTX
{

    public partial class HDKTX : Form
    {
        public HDKTX()
        {
            InitializeComponent();
        }
       

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd=new OpenFileDialog() {ValidateNames=true ,Multiselect=false,Filter="PDF|*.pdf"})
            {
                if(ofd.ShowDialog()==DialogResult.OK)
                {
                    axAcroPDF1.src = ofd.FileName;
                }
            }
        }

        }
      
    }

