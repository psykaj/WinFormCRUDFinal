using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsCRUDPratice4.Model;

namespace WinFormsCRUDPratice4
{
    public partial class Form1 : Form
    {
        Workers wor = new Workers();

        WorkersLogicLayer obj = new WorkersLogicLayer();

        string gender;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = obj.GetWorkers();
        }

        //insert button code
        private void button1_Click(object sender, EventArgs e)
        {
            wor.fullName = textBox1.Text;

            //string gender;
            if(radioButton1.Checked == true)
            {
                wor.gender = "Male";
            }
            else
            {
                wor.gender = "Female";
            }

            wor.states = comboBox1.Text;
            wor.DOB = dateTimePicker1.Value;
            wor.payments = Convert.ToInt32(textBox2.Text);
            wor.addressPlace = richTextBox1.Text;

            int i = obj.insert(wor);

            if(i != 0 || i != -1)
            {
                MessageBox.Show("Data Successfully inserted");

                //to print updated grid view
                dataGridView1.DataSource = obj.GetWorkers();
            }
            else
            {
                MessageBox.Show("Data Not Inserted");
            }
        }

        //check box code
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                wor = obj.getElementById(Convert.ToInt32(textBox5.Text));

                if(wor != null)
                {
                    textBox4.Text = wor.fullName;
                    if(wor.gender == "Male")
                    {
                        radioButton4.Checked.ToString();
                    }
                    else
                    {
                        radioButton3.Checked.ToString();
                    }
                    comboBox2.Text = wor.states;
                    dateTimePicker2.Value = wor.DOB;
                    textBox3.Text = Convert.ToInt32(wor.payments).ToString();
                    richTextBox2.Text = wor.addressPlace;
                }
                else
                {
                    MessageBox.Show("No records Were found");
                }
            }
        }

        //update button code
        private void button2_Click(object sender, EventArgs e)
        {
            wor.fullName = textBox4.Text;

            //string gender;
            if (radioButton1.Checked == true)
            {
                wor.gender = "Male";
            }
            else
            {
                wor.gender = "Female";
            }

            wor.states = comboBox2.Text;
            wor.DOB = dateTimePicker2.Value;
            wor.payments = Convert.ToInt32(textBox3.Text);
            wor.addressPlace = richTextBox2.Text;

            int i = obj.update(wor);

            if (i != 0 || i != -1)
            {
                MessageBox.Show("Data Successfully Updated");

                //to print updated grid view
                dataGridView1.DataSource = obj.GetWorkers();
            }
            else
            {
                MessageBox.Show("Data Not Updated");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i = obj.delete(Convert.ToInt32(textBox6.Text));

            if(i != null)
            {
                MessageBox.Show("Data deleted Successfully");

                //to print updated grid view
                dataGridView1.DataSource = obj.GetWorkers();
            }
            else
            {
                MessageBox.Show("Data Not Deleted");
            }
        }
    }
}
