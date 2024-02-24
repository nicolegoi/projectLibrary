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


namespace nicolegoihman215871583.forms
{
    public partial class frmBooks : Form
    {
        DataTable Tcust, TAuthor;
        int count;
        public frmBooks()
        {
            InitializeComponent();
            Tcust = data.Class1.OpenTable("books");

            DisplayUtilities.FillDataGrid(dataGridView1, Tcust);
            DisplayRecords(0);
           
        }

        private void frmBooks_Load(object sender, EventArgs e)
        {

        }

        private void DisplayRecords(int currentRow)
        {
            textBox1.Text = dataGridView1.Rows[currentRow].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[currentRow].Cells[1].Value.ToString();
            cmbId.Text = dataGridView1.Rows[currentRow].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[currentRow].Cells[3].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[currentRow].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[currentRow].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.Rows[currentRow].Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.Rows[currentRow].Cells[7].Value.ToString();
            textBox9.Text = dataGridView1.Rows[currentRow].Cells[8].Value.ToString();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            cmbId.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }

        private void SetButtonStates()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.GetType() == typeof(Button))
                {
                    Button btn = (Button)ctrl;

                    btn.Enabled = !btn.Enabled;
                }
            }
        }

        /// /////////////////////// btn ///////////////////////////////


        //new book btn
        private void btnNewItem_Click(object sender, EventArgs e)
        {
           // SetButtonStates();
            //ClearControls();
            textBox1.Text = (Tcust.Rows.Count+1).ToString();
            textBox2.Text = String.Empty;
           // textBox3.Text = String.Empty;
            //textBox4.Text = String.Empty;
            //textBox5.Text = String.Empty;
            textBox6.Text = String.Empty;
            textBox7.Text = String.Empty;
            textBox8.Text = String.Empty;
            textBox9.Text = String.Empty;
            btnSaveAllChange.Enabled = true;
            btnCancel.Enabled = true;

            TAuthor = data.Class1.OpenTable("authors");
            DisplayUtilities.FillCombo(TAuthor, 1, cmbname);
            DisplayUtilities.FillCombo(TAuthor, 0, cmbId);
        }

        //update btn
        private void btnUpdateItem_Click(object sender, EventArgs e)
        {
            
            
            Book book = new Book();
            if (CheckInput(book))
            {
                string sqlStr = $"UPDATE books SET " +
                            $" [bookName]='{book.BookName}'," +
                            $" [numOfCopies]={book.NumOfCopies}," +
                            $" [author]='{book.Author}'," +
                            $" [genre]='{book.Genre}'," +
                            $" [appropriateAge]='{book.AppropriateAge}'," +
                            $" [placeInLibrary]='{book.PlaceInLibrary}'," +
                            $" [publishing]='{book.Publishing}'," +
                            $" [numOfAvilibleCopies]='{book.NumOfAvailableCopies}'" +
                            $" WHERE [bookId]={book.BookId}";

                button5.Enabled = true;
                GeneralUtilities.UpDateRecd(Tcust, sqlStr);
                Tcust = Class1.OpenTable("books");
                DisplayUtilities.FillDataGrid(dataGridView1, Tcust);
            }


        }

        //cancel an update
        private void button5_Click(object sender, EventArgs e)
        {
            Tcust = data.Class1.OpenTable("books");
            DisplayUtilities.FillDataGrid(dataGridView1, Tcust);
            DisplayRecords(0);
            button5.Enabled = false;
        }

        //refresh btn
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Tcust = data.Class1.OpenTable("books");
            DisplayUtilities.FillDataGrid(dataGridView1, Tcust);
            DisplayRecords(0);
            btnSaveAllChange.Enabled = false;
            btnCancel.Enabled = false;
            button5.Enabled = false;
        }

        //save new book btn
        private void btnSaveAllChange_Click(object sender, EventArgs e)
        {
            Book book = new Book();
            //book.NumOfAvailableCopies;
            if (CheckInput(book))
            {
                string sqlStr = $"INSERT INTO books VALUES({book.BookId}," +
                   
                    $" {book.NumOfCopies}," + //
                    $" '{book.Author}'," +
                    $" '{book.Genre}'," + //
                    $" '{book.AppropriateAge}'," + //
                    $" '{book.PlaceInLibrary}'," +
                    $" '{book.Publishing}'," +
                    $" '{book.NumOfAvailableCopies}'," +
                    $" '{book.BookName}')";

                GeneralUtilities.AddRecd(Tcust, sqlStr);
                Tcust = Class1.OpenTable("books");
                DisplayUtilities.FillDataGrid(dataGridView1, Tcust);
            }
        }

        //cancel btn if want to cancel making a new book
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Tcust = data.Class1.OpenTable("books");
            DisplayUtilities.FillDataGrid(dataGridView1, Tcust);
            DisplayRecords(0);
            btnSaveAllChange.Enabled = false;
            btnCancel.Enabled = false;

        }

        //next btn
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            count = utilities.GeneralUtilities.MoveNext(Tcust, count);
            DisplayRecords(count);
        }

        //prv btn
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            count = utilities.GeneralUtilities.MovePrev(Tcust, count);
            DisplayRecords(count);
        }


        /// ///////////// filter /////////////////////////////////

        /// //FANTASY filter
        private void button1_Click(object sender, EventArgs e)
        {
            string sqlStr = "SELECT * FROM books WHERE genre = 'fantasy' ";
            //%% string
            //nothing-int
            Tcust = Class1.OpenTableWithCondition(sqlStr);
            DisplayUtilities.FillDataGrid(dataGridView1, Tcust);
            DisplayRecords(0);
        }

        //romance filter
        private void button2_Click(object sender, EventArgs e)
        {
            string sqlStr = "SELECT * FROM books WHERE genre = 'romance' ";
            //%% string
            //nothing-int
            Tcust = Class1.OpenTableWithCondition(sqlStr);
            DisplayUtilities.FillDataGrid(dataGridView1, Tcust);
            DisplayRecords(0);
        }

        //horror filter
        private void button3_Click(object sender, EventArgs e)
        {
            string sqlStr = "SELECT * FROM books WHERE genre = 'horror' ";
            //%% string
            //nothing-int
            Tcust = Class1.OpenTableWithCondition(sqlStr);
            DisplayUtilities.FillDataGrid(dataGridView1, Tcust);
            DisplayRecords(0);
        }

        //sifi filter
        private void button4_Click(object sender, EventArgs e)
        {
            string sqlStr = "SELECT * FROM books WHERE genre = 'si-fi' ";
            //%% string
            //nothing-int
            Tcust = Class1.OpenTableWithCondition(sqlStr);
            DisplayUtilities.FillDataGrid(dataGridView1, Tcust);
            DisplayRecords(0);
        }

        
        /// //////////////////////others//////////////////////
        private bool CheckInput(Book b)
        {
            bool flag = true;
            b.BookId = Convert.ToInt32(textBox1.Text);
            //num of copies    
            try
            {
                b.NumOfCopies = Convert.ToInt32(textBox2.Text);
                errorProvider1.SetError(textBox2, "");

                flag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
                errorProvider1.SetError(textBox2, ex.Message);
            }

            //author    
            try
            {
                b.Author = cmbId.Text;
                errorProvider1.SetError(cmbId, "");

                flag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
                errorProvider1.SetError(cmbId, ex.Message);
            }

            //genre    
            try
            {

                //b.Genre = textBox4.Text;
                b.Genre = comboBox1.Text;

                errorProvider1.SetError(comboBox1, "");

                flag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
                errorProvider1.SetError(comboBox1, ex.Message);
            }

            //appropiate age    
            try
            {
                b.AppropriateAge = comboBox2.Text;
                errorProvider1.SetError(comboBox2, "");

                flag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
                errorProvider1.SetError(comboBox2, ex.Message);
            }

            //place in library    
            try
            {
                b.PlaceInLibrary = textBox6.Text;
                errorProvider1.SetError(textBox6, "");

                flag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
                errorProvider1.SetError(textBox6, ex.Message);
            }

            //publishing    
            try
            {
                b.Publishing = textBox7.Text;
                errorProvider1.SetError(textBox7, "");

                flag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
                errorProvider1.SetError(textBox7, ex.Message);
            }

            //num of avaliable copies    
            try
            {
                b.NumOfAvailableCopies = textBox8.Text;
                errorProvider1.SetError(textBox8, "");

                flag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
                errorProvider1.SetError(textBox8, ex.Message);
            }

            //book names   
            try
            {
                b.BookName = textBox9.Text;
                errorProvider1.SetError(textBox9, "");

                flag = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
                errorProvider1.SetError(textBox9, ex.Message);
            }





            return flag;
        }

        //free search
        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            string txt = textBox10.Text;
            //string sqlStr = $"SELECT * FROM books WHERE bookId LIKE '{txt}' OR numOfCopies LIKE '{txt}' OR author LIKE '%{txt}%' OR genre LIKE '%{txt}%' OR appropriateAge LIKE '%{txt}%' OR placeInLibrary LIKE '%{txt}%' OR publishing LIKE '%{txt}%' OR numOfAvilibleCopies LIKE '%{txt}%' OR bookName LIKE '%{txt}%'";

            string sqlStr = $"SELECT * FROM books WHERE bookId LIKE '{txt}' OR author LIKE '%{txt}%' OR genre LIKE '%{txt}%' OR appropriateAge LIKE '%{txt}%' OR placeInLibrary LIKE '%{txt}%' OR publishing LIKE '%{txt}%' OR bookName LIKE '%{txt}%'";
            //%% string
            //nothing-int
            Tcust = Class1.OpenTableWithCondition(sqlStr);
            DisplayUtilities.FillDataGrid(dataGridView1, Tcust);
            DisplayRecords(0);
            //{ book.BookId}," +

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            cmbId.Text = " ";
            cmbname.Text = " ";
            TAuthor = data.Class1.OpenTableWithCondition("SELECT * FROM authors WHERE authorId='"  + textBox1.Text + "'");
            DisplayUtilities.FillCombo(TAuthor, 1, cmbname);
            DisplayUtilities.FillCombo(TAuthor, 0, cmbId);
        }

        //free search
        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            string txt = textBox10.Text;
            //string sqlStr = $"SELECT * FROM books WHERE bookId LIKE '{txt}' OR numOfCopies LIKE '{txt}' OR author LIKE '%{txt}%' OR genre LIKE '%{txt}%' OR appropriateAge LIKE '%{txt}%' OR placeInLibrary LIKE '%{txt}%' OR publishing LIKE '%{txt}%' OR numOfAvilibleCopies LIKE '%{txt}%' OR bookName LIKE '%{txt}%'";

            string sqlStr = $"SELECT * FROM books WHERE bookId LIKE '{txt}' OR author LIKE '%{txt}%' OR genre LIKE '%{txt}%' OR appropriateAge LIKE '%{txt}%' OR placeInLibrary LIKE '%{txt}%' OR publishing LIKE '%{txt}%' OR bookName LIKE '%{txt}%'";
            //%% string
            //nothing-int
            Tcust = Class1.OpenTableWithCondition(sqlStr);
            DisplayUtilities.FillDataGrid(dataGridView1, Tcust);
            DisplayRecords(0);
        }

        private void cmbId_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbname.SelectedIndex = cmbId.SelectedIndex;

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbname_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbId.SelectedIndex = cmbname.SelectedIndex;
        }



        /// /////////////TO DO LIST///////////////////////////////////
        
    }

}
