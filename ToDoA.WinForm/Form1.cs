using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ToDoA.Data.Database;
using ToDoA.Data.Entity;

namespace ToDoA.WinForm
{
    public partial class Form1 : Form
    {
        private IDataRepository<Memento> _data;

        public Form1()
        {
            InitializeComponent();
        }

        public Form1(IDataRepository<Memento> data)
        {
            _data = data;
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

        private void button3_Click(object sender, EventArgs e)
        {
            var memo = _data.GetMemo(2);
            textBox1.Text = memo.Text;
            textBox1.Tag = memo.Id;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Memento memo = new Memento();
            memo.Text = textBox1.Text;
            memo.Id = (int)textBox1.Tag;
            _data.UpdateMemo(memo);
        }
    }
}
