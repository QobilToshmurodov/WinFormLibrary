using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Kurs_ishi
{
    public partial class Form1 : Form
    {
        OleDbConnection Con = new OleDbConnection();
        public Form1()
        {
            InitializeComponent();
            Con.ConnectionString= @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Kurs ishi.accdb";
        }
        void tozalash()
        {
            
            textBox2.Clear();
            textBox7.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox15.Clear();
            textBox16.Clear();
            textBox17.Clear();
            label4.Text = string.Empty;
            label10.Text = string.Empty;
            label16.Text = string.Empty;
        }

        void korsat(string sorov,DataGridView datagrid)
        {
            try
            {
                Con.Open();
               
                OleDbDataAdapter da = new OleDbDataAdapter(sorov,Con);
                OleDbCommandBuilder cb = new OleDbCommandBuilder();
                DataSet ds = new DataSet();
                da.Fill(ds);
                datagrid.DataSource = ds.Tables[0];
                Con.Close();
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        void filter(string sorov, DataGridView datagrid)
        {
            try
            {
                Con.Open();
                string query = "Select id As [Tartib raqami],  nomi As [Kinoteatr nomi], adres As [Kinoteatr adresi], Orin_soni As [O\'rinlar soni], zal_soni As [Zallar soni],grafik As [Grafik]  from Kinoteatr WHERE nomi Like '%" +textBox2.Text + "%' ";
                OleDbDataAdapter da = new OleDbDataAdapter(sorov, Con);
                OleDbCommandBuilder cb = new OleDbCommandBuilder();
                DataSet ds = new DataSet();
                da.Fill(ds);
                datagrid.DataSource = ds.Tables[0];
                Con.Close();
            }
            catch
            { }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                korsat("Select id As [Tartib raqami],  nomi As [Kinoteatr nomi], adres As [Kinoteatr adresi], Orin_soni As [O\'rinlar soni], zal_soni As [Zallar soni],grafik As [Grafik]  from Kinoteatr", dataGridView1);
                korsat("Select id As [Tartib raqami], nomi As [Film nomi], rejissor As [Rejissor],operator As [Operator], akt_royhat As [Aktiyorlar ro\'yhati],janr As [Janr],rej_id As [Rejissor raqami] from film", dataGridView2);
                korsat("Select id As [Tartib raqami], sanasi As [Sanasi],seans As [Seans],narxi As [Narxi], bosh_joy As [Bo\'sh joy] from Repertuar", dataGridView3);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
              
                korsat("Select  Kinoteatr.nomi As [Kinoteatr nomi],"+ 
                "adres As [Kinoteatr adresi], Orin_soni As [O\'rinlar soni], zal_soni As [Zallar soni],"+
                "grafik As [Grafik], film.nomi As [Film nomi], rejissor As [Rejissor], operator As [Operator], " +
                "akt_royhat As [Aktiyorlar ro\'yhati], janr As [Janr], rej_id As [Rejissor raqami]," +
                "sanasi As [Sanasi],seans As [Seans],narxi As [Narxi], bosh_joy As [Bo\'sh joy] from Kinoteatr, film , Repertuar where " +
                " Kinoteatr.id=film.rej_id and " + "Kinoteatr.Orin_soni=Repertuar.bosh_joy", dataGridView4);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
               try
            {
              
                filter("Select  Kinoteatr.nomi As [Kinoteatr nomi],"+ 
                "adres As [Kinoteatr adresi], Orin_soni As [O\'rinlar soni], zal_soni As [Zallar soni],"+
                "grafik As [Grafik], film.nomi As [Film nomi], rejissor As [Rejissor], operator As [Operator], " +
                "akt_royhat As [Aktiyorlar ro\'yhati], janr As [Janr], rej_id As [Rejissor raqami]," +
                "sanasi As [Sanasi],seans As [Seans],narxi As [Narxi], bosh_joy As [Bo\'sh joy] from Kinoteatr, film , Repertuar where " +
                " Kinoteatr.id=film.rej_id and " + "Kinoteatr.Orin_soni=Repertuar.bosh_joy and Kinoteatr.nomi Like '%" + textBox1.Text + "%' ", dataGridView4);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                filter("Select id As [Tartib raqami],  nomi As [Kinoteatr nomi], adres As [Kinoteatr adresi], Orin_soni As [O\'rinlar soni], zal_soni As [Zallar soni],grafik As [Grafik]  from Kinoteatr WHERE nomi Like '%" + textBox2.Text + "%'", dataGridView1);
                filter("Select id As [Tartib raqami], nomi As [Film nomi], rejissor As [Rejissor],operator As [Operator], akt_royhat As [Aktiyorlar ro\'yhati],janr As [Janr],rej_id As [Rejissor raqami] from film WHERE nomi Like '%" + textBox8.Text + "%'", dataGridView2);
                filter("Select id As [Tartib raqami], sanasi As [Sanasi],seans As [Seans],narxi As [Narxi], bosh_joy As [Bo\'sh joy] from Repertuar WHERE sanasi Like '%" + dateTimePicker1.Value + "%'", dataGridView3);
           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click_1(object sender, EventArgs e)
        {

        }

        private void label21_Click_2(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        { 
            try
            {
                qoshish("Delete From Kinoteatr  where id="+label16.Text+" ");
                MessageBox.Show("Ma\'lumot o\'chirildi");
                korsat("Select id As [Tartib raqami], nomi As [Kinoteatr nomi], adres As [Kinoteatr adresi], Orin_soni As [O\'rinlar soni], zal_soni As [Zallar soni], grafik As [Grafik]  from Kinoteatr", dataGridView1);
                tozalash(); 
            }
            catch { MessageBox.Show("Ma\'lumot xato kritildi"); }
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                qoshish("Insert into  film(nomi, rejissor, operator, akt_royhat, janr, rej_id) values ('" + textBox8.Text + "', '" + textBox9.Text + "', '" + textBox10.Text + "', '" + textBox11.Text + "', '" + textBox12.Text + "', '" + textBox7.Text + "')");
                korsat("Select id As [Tartib raqami], nomi As [Film nomi], rejissor As [Rejissor],operator As [Operator], akt_royhat As [Aktiyorlar ro\'yhati],janr As [Janr], rej_id As [Rejissor raqami] from film", dataGridView2);
              
                MessageBox.Show("Ma\'lumot qo\'shildi");
                tozalash();
            }
            catch { MessageBox.Show("Ma\'lumot xato kritildi"); }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                qoshish("Update Repertuar set sanasi='" + Convert.ToDateTime(dateTimePicker1.Value) + "', seans='" + int.Parse(textBox15.Text) + "', narxi='" + int.Parse(textBox16.Text) + "', bosh_joy ='" + int.Parse(textBox17.Text) + "' where id="+label4.Text+"");
                MessageBox.Show("Ma\'lumot o\'zgartirildi");
                korsat("Select id As [Tartib raqami], sanasi As [Sanasi],seans As [Seans],narxi As [Narxi], bosh_joy As [Bo\'sh joy] from Repertuar", dataGridView3);
        tozalash();
            }
            catch { MessageBox.Show("Ma\'lumot xato kritildi"); }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                qoshish("Insert into Repertuar(sanasi, seans, narxi, bosh_joy) values ('" +Convert.ToDateTime(dateTimePicker1.Value) + "', '" + int.Parse(textBox15.Text) + "', '" + int.Parse(textBox16.Text) + "', '" + int.Parse(textBox17.Text) + "')");
                korsat("Select id As [Tartib raqami], sanasi As [Sanasi], seans As [Seans], narxi As [Narxi], bosh_joy As [Bo\'sh joy] from Repertuar", dataGridView3); 
                MessageBox.Show("Ma\'lumot qo\'shildi");
                tozalash();
            }
            catch { MessageBox.Show("Ma\'lumot xato kritildi"); }
        }
        void qoshish(string insert)
        {
            try
            {
                Con.Open();
                OleDbCommand com = new OleDbCommand(insert, Con);
                com.ExecuteNonQuery();
                Con.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                qoshish("Insert into Kinoteatr(nomi, adres, Orin_soni, zal_soni, grafik) values ('" + textBox2.Text + "', '" + textBox3.Text + "', '" + int.Parse(textBox4.Text) + "', '" + int.Parse(textBox5.Text) + "', '" + textBox6.Text + "')");
                korsat("Select id As [Tartib raqami], nomi As [Kinoteatr nomi], adres As [Kinoteatr adresi], Orin_soni As [O\'rinlar soni], zal_soni As [Zallar soni], grafik As [Grafik]  from Kinoteatr", dataGridView1);
                MessageBox.Show("Ma\'lumot qo\'shildi");
                tozalash();
            }
            catch  { MessageBox.Show("Ma\'lumot xato kritildi"); }

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                label16.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                label10.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox8.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox9.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox10.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox11.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox12.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
                textBox7.Text = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                qoshish("Update  film set nomi='" + textBox8.Text + "' , rejissor='" + textBox9.Text + "', operator='" + textBox10.Text + "', akt_royhat='" + textBox11.Text + "', janr='" + textBox12.Text + "', rej_id='" + textBox7.Text + "' where id=" + label10.Text + "");
                MessageBox.Show("Ma\'lumot o\'zgartirildi");
                korsat("Select id As [Tartib raqami], nomi As [Film nomi], rejissor As [Rejissor],operator As [Operator], akt_royhat As [Aktiyorlar ro\'yhati],janr As [Janr], rej_id As [Rejissor raqami] from film", dataGridView2);
                tozalash();
            }
            catch { MessageBox.Show("Ma\'lumot xato kritildi"); }

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                label4.Text = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
                dateTimePicker1.Text = dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox15.Text = dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox16.Text = dataGridView3.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox17.Text = dataGridView3.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                qoshish("Update Kinoteatr set nomi='" + textBox2.Text + "', adres='" + textBox3.Text + "', Orin_soni='" + int.Parse(textBox4.Text) + "', zal_soni='" + int.Parse(textBox5.Text) + "', grafik='" + textBox6.Text + "' where id="+label16.Text+" ");
                MessageBox.Show("Ma\'lumot o\'zgartirildi");
                korsat("Select id As [Tartib raqami], nomi As [Kinoteatr nomi], adres As [Kinoteatr adresi], Orin_soni As [O\'rinlar soni], zal_soni As [Zallar soni], grafik As [Grafik]  from Kinoteatr", dataGridView1);
                tozalash(); 
            }
            catch { MessageBox.Show("Ma\'lumot xato kritildi"); }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                qoshish("Delete From  film  where id=" + label10.Text + "");
                MessageBox.Show("Ma\'lumot o\'chirildi");
                korsat("Select id As [Tartib raqami], nomi As [Film nomi], rejissor As [Rejissor],operator As [Operator], akt_royhat As [Aktiyorlar ro\'yhati],janr As [Janr],rej_id As [Rejissor raqami] from film", dataGridView2);
                tozalash();
            }
            catch { MessageBox.Show("Ma\'lumot xato kritildi"); }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                qoshish("Delete From Repertuar   where id=" + label4.Text + "");
                MessageBox.Show("Ma\'lumot o\'chirildi");
                korsat("Select id As [Tartib raqami], sanasi As [Sanasi],seans As [Seans],narxi As [Narxi], bosh_joy As [Bo\'sh joy] from Repertuar", dataGridView3);
                tozalash();
            }
            catch { MessageBox.Show("Ma\'lumot xato kritildi"); }
        }

       

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {

                filter("Select id As [Tartib raqami],  nomi As [Kinoteatr nomi], adres As [Kinoteatr adresi], Orin_soni As [O\'rinlar soni], zal_soni As [Zallar soni],grafik As [Grafik]  from Kinoteatr WHERE nomi Like '%" + textBox2.Text + "%'", dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {

                filter("Select id As [Tartib raqami],  nomi As [Kinoteatr nomi], adres As [Kinoteatr adresi], Orin_soni As [O\'rinlar soni], zal_soni As [Zallar soni],grafik As [Grafik]  from Kinoteatr WHERE adres Like '%" + textBox3.Text + "%'", dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                filter("Select id As [Tartib raqami],  nomi As [Kinoteatr nomi], adres As [Kinoteatr adresi], Orin_soni As [O\'rinlar soni], zal_soni As [Zallar soni],grafik As [Grafik]  from Kinoteatr WHERE Orin_soni Like '%" + textBox4.Text + "%'", dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                filter("Select id As [Tartib raqami],  nomi As [Kinoteatr nomi], adres As [Kinoteatr adresi], Orin_soni As [O\'rinlar soni], zal_soni As [Zallar soni],grafik As [Grafik]  from Kinoteatr WHERE zal_soni Like '%" + textBox5.Text + "%'", dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                filter("Select id As [Tartib raqami],  nomi As [Kinoteatr nomi], adres As [Kinoteatr adresi], Orin_soni As [O\'rinlar soni], zal_soni As [Zallar soni],grafik As [Grafik]  from Kinoteatr WHERE grafik Like '%" + textBox6.Text + "%'", dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                filter("Select id As [Tartib raqami], sanasi As [Sanasi],seans As [Seans],narxi As [Narxi], bosh_joy As [Bo\'sh joy] from Repertuar WHERE sanasi Like '%" + dateTimePicker1.Value + "%'", dataGridView3);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button10_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                filter("Select id As [Tartib raqami], sanasi As [Sanasi],seans As [Seans],narxi As [Narxi], bosh_joy As [Bo\'sh joy] from Repertuar WHERE seans Like '%" + textBox15.Text + "%'", dataGridView3);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        private void button24_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 5;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
               
                filter("Select id As [Tartib raqami], nomi As [Film nomi], rejissor As [Rejissor],operator As [Operator], akt_royhat As [Aktiyorlar ro\'yhati], janr As [Janr], rej_id As [Rejissor raqami] from film WHERE rej_id Like '%" + textBox7.Text + "%'", dataGridView2);
            
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button23_Click(object sender, EventArgs e)
        {
            try
            {

                filter("Select  Kinoteatr.nomi As [Kinoteatr nomi]," +
                "adres As [Kinoteatr adresi], Orin_soni As [O\'rinlar soni], zal_soni As [Zallar soni]," +
                "grafik As [Grafik], film.nomi As [Film nomi], rejissor As [Rejissor], operator As [Operator], " +
                "akt_royhat As [Aktiyorlar ro\'yhati], janr As [Janr], rej_id As [Rejissor raqami]," +
                "sanasi As [Sanasi],seans As [Seans],narxi As [Narxi], bosh_joy As [Bo\'sh joy] from Kinoteatr, film , Repertuar where " +
                " Kinoteatr.id=film.rej_id and " + "Kinoteatr.Orin_soni=Repertuar.bosh_joy and Kinoteatr.nomi Like '%" + textBox1.Text + "%' ", dataGridView4);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
} 
