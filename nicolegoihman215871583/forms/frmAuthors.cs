using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using nicolegoihman215871583.data;
using nicolegoihman215871583.utilities;
using System.Diagnostics;

namespace nicolegoihman215871583.forms
{
    public partial class frmAuthors : Form
    {
        DataTable TAuthors;
        int count;
        public frmAuthors()
        {
            InitializeComponent();
            TAuthors = data.Class1.OpenTable("authors");

            DisplayUtilities.FillDataGrid(dataGridView1, TAuthors);
            DisplayRecords(0);

        }

        private void Authors_Load(object sender, EventArgs e)
        {

        } 
        /// //////////////////// TO DO //////////////////////////
        // maybe instead of boxtext3 change to date time picker- to see how to change in table and in accses
        // to change all id's to numbers- and change everything needed to numbers

        //giving an Syntax error in UPDATE statement when trying to update
        //when clicking on table, not changing in text box
        //link only working for authors who were created from the frogram' and not from acces
        //make btn imgs smaller


        /// //////////////////// TABLE //////////////////////////
        private void DisplayRecords(int currentRow)
        {
            textBox1.Text = dataGridView1.Rows[currentRow].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[currentRow].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[currentRow].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[currentRow].Cells[3].Value.ToString();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }


        /// //////////////////// BTN //////////////////////////
         // back btn
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            count = utilities.GeneralUtilities.MovePrev(TAuthors, count);
            DisplayRecords(count);
        }

        //refresh
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            TAuthors = data.Class1.OpenTable("authors");
            DisplayUtilities.FillDataGrid(dataGridView1, TAuthors);
            DisplayRecords(0);
            button5.Enabled = false;
            button6.Enabled = false;
            button8.Enabled = false;
        }

        //front btn
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            count = utilities.GeneralUtilities.MoveNext(TAuthors, count);
            DisplayRecords(count);
        }

        //ADD A NEW AUTHOR- done
        private void button4_Click(object sender, EventArgs e)
        {
            //enableing save new author btn
            button5.Enabled = true;
            //enableing cancel a new author btn
            button6.Enabled = true;
            textBox1.Text = (TAuthors.Rows.Count + 1).ToString();
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;

        }

        //SAVE NEW AUTHOR
        private void button5_Click(object sender, EventArgs e)
        {
            //enabled - false until press create a new author
            Author author = new Author();
            if(CheckInput(author))
            {
                string sqlStr = $"INSERT INTO authors VALUES('{author.AuthorId}'," +

                    $" '{author.FullName}'," + 
                    $" '{author.Birthday}'," +
                    $" '{author.LinkToInfo}')";

                GeneralUtilities.AddRecd(TAuthors, sqlStr);
                TAuthors = data.Class1.OpenTable("authors");
                DisplayUtilities.FillDataGrid(dataGridView1, TAuthors);

            }
            button5.Enabled = false;
            button6.Enabled = false;
        }

        //CANCEL A NEW AUTHOR
        private void button6_Click(object sender, EventArgs e)
        {
            //enabled - false until press create a new author
            TAuthors = data.Class1.OpenTable("authors");
            DisplayUtilities.FillDataGrid(dataGridView1, TAuthors);
            DisplayRecords(0);
            button5.Enabled = false;
            button6.Enabled = false;

        }

        //UPDATE AN AUTHOR
        private void button7_Click(object sender, EventArgs e)
        {
            //enableing cancel update author btn
            button8.Enabled = true;
            //textBox4.Visible = true;
            Author author = new Author();
            if (CheckInput(author))
            {
                string sqlStr = $"UPDATE authors SET " +

                             $" [authorName]='{author.FullName}'," +
                             $" [authorBirthday]='{author.Birthday}'," +
                             $" [linkToInfo]='{author.LinkToInfo}'," +
                             $" WHERE [authorId]='{author.AuthorId}'";
                GeneralUtilities.UpDateRecd(TAuthors, sqlStr);
                TAuthors = data.Class1.OpenTable("authors");
                DisplayUtilities.FillDataGrid(dataGridView1, TAuthors);

            }
        }

        // CANCEL EDIT
        private void button8_Click(object sender, EventArgs e)
        {
            //enabled - false until press update an author
            TAuthors = data.Class1.OpenTable("authors");
            DisplayUtilities.FillDataGrid(dataGridView1, TAuthors);
            DisplayRecords(0);
            button8.Enabled = false;
        }


        /// //////////////////// SEARCH //////////////////////////

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string txt = textBox5.Text;
            string sqlStr = $"SELECT * FROM authors WHERE authorId LIKE '%{txt}%' OR authorName LIKE '%{txt}%' OR authorBirthday LIKE '%{txt}%' OR linkToInfo LIKE '%{txt}%'";
            //%% string
            //nothing-int
            TAuthors = Class1.OpenTableWithCondition(sqlStr);
            DisplayUtilities.FillDataGrid(dataGridView1, TAuthors);
            DisplayRecords(0);
        }


        /// //////////////////// OTHER //////////////////////////
        private bool CheckInput(Author author)
        {
            bool flag = true;
            author.AuthorId =textBox1.Text;
                //Convert.ToInt32(textBox1.Text);
            //author name   
            try
            {
                author.FullName = textBox2.Text;
                errorProvider1.SetError(textBox2, "");

                flag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
                errorProvider1.SetError(textBox2, ex.Message);
            }

            //author birthday   
            try
            {
                author.Birthday = textBox3.Text;
                errorProvider1.SetError(textBox3, "");

                flag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
                errorProvider1.SetError(textBox3, ex.Message);
            }

            //link to info    
            try
            {
                author.LinkToInfo = textBox4.Text;

                errorProvider1.SetError(textBox4, "");

                flag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
                errorProvider1.SetError(textBox4, ex.Message);
            }

            return flag;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        //link to info
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(textBox4.Text);
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        //change link of an author
        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.Visible = true;
        }

        private void dataGridView1_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

    }
}




