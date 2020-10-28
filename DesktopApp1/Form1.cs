using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace DesktopApp1
{
    public partial class Form1 : Form
    {
        ErrorHandling error = new ErrorHandling();
        Controller controller = new Controller();
        public Form1()
        {
            InitializeComponent();
            ShowSearch();
            PopulateCbxTrainer();
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Click on the link below to continue learning how to build a desktop app using WinForms!
            System.Diagnostics.Process.Start("http://aka.ms/dotnet-get-started-desktop");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thanks!");
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void ComboBoxTId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ButtonTestTrainer_Click(object sender, EventArgs e)
        {
            FormTrainer formTrainer = new FormTrainer();
            formTrainer.ShowDialog();
            
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {

        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            string nickname = textBoxNickname.Text;
            string type = textBoxType.Text;
            int? trainerId = (int?)comboBoxTrainer.SelectedValue;
            int level = (int)Math.Round(numericUpDownLevel.Value, 0);
            Console.WriteLine(name + nickname + type);
            Console.WriteLine(trainerId);
            Console.WriteLine(level);
            try
            {
                controller.CreatePokemon(name, nickname, level, type, trainerId);
            }
            catch (Exception ex)
            {
                String errormessage = error.GetMessage(ex);
                String caption = "Error occured";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(errormessage, caption, buttons);
                
            }
            
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            ShowSearch();
        }

        private void ShowSearch()
        {

            if (radioBtnSearchPokemon.Checked == true)
            {
                dataGridView.DataSource = controller.FindAllPokemons();
                dataGridView.Columns.Remove("Trainer");
                dataGridView.Columns["pId"].HeaderText = "Pok�monId";
                dataGridView.Columns["tId"].HeaderText = "TrainerId";

            }
            else if (radioBtnSearchTrainer.Checked == true)
            {
                dataGridView.DataSource = controller.FindAllTrainers();
                dataGridView.Columns.Remove("Pok�mon");
                dataGridView.Columns["tId"].HeaderText = "TrainerId";
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void PopulateCbxTrainer()
        {
            comboBoxTrainer.DataSource = controller.FindAllTrainers();
            comboBoxTrainer.DisplayMember = "tName";
            comboBoxTrainer.ValueMember = "tId";
        }
    }
}
