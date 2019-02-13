using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ToDoA.Data.Database;
using ToDoA.Data.Entity;

namespace ToDoA.WinForm
{
    public partial class Form1 : Form
    {
        DataRepository _data = new DataRepository();

        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            List<Memento> list = new List<Memento>();
            list = _data.GetAll().ToList();

            foreach (var item in list)
            {
                listBox1.Items.Add(item.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _data.AddMemo(new Memento(){Text = "Super"});
        }
    }
}
