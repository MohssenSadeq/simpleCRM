﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace HejAndOmra
{
        public partial class Haj : Form
        {

     string ss;
        public static Haj Me;
        public  int op;
       public int d;
      Services m = new Services();

            DataTable dtable = new DataTable();

            SqlDataAdapter adp1;
        New_Haj k = new New_Haj();
        DataTable dt = new DataTable();
        DataTable dt10 = new DataTable();
        DataTable dt11 = new DataTable();
        DataTable dt1 = new DataTable();
            SqlConnection conn = new SqlConnection(connectionstring.con);
            public Haj()
            {
            InitializeComponent();
            Me = this;
            }
       
            public void price()
            {

                if (checkBox7.Checked == true)
                {
                    if (radioButton4.Checked == true) { Box28.Text = Class2.m; }
                    else { Box28.Text = Class2.j; }

                    label8.Text = checkBox7.Text;
                }
                else
                {
                    Box28.Text = "0";
                    label8.Text = "Unchecked";
                }
                if (checkBox3.Checked == true)
                {
                    if (radioButton4.Checked == true) { Box29.Text = Class2.k; }
                    else { Box29.Text = Class2.h; }
                    label9.Text = checkBox3.Text;
                }
                else
                {
                    Box29.Text = "0";
                    label9.Text = "Unchecked";
                }
                if (checkBox4.Checked == true)
                {
                    label14.Text = checkBox4.Text;
                    if (radioButton4.Checked == true) { Box30.Text = Class2.l; }
                    else { Box30.Text = Class2.g; }
                }
                else
                {
                    Box30.Text = "0";
                    label14.Text = "Unchecked";
                }

                if (radioButton4.Checked == true) { label13.Text = radioButton4.Text; }
                else { label13.Text = radioButton3.Text; }

            }
            public void travelcombobox()
            {
                dt1.Clear();
                adp1 = new SqlDataAdapter("Select* From Travels", conn);
                adp1.Fill(dt1);
                Box31.DataSource = dt1;
                Box31.DisplayMember = "travel_number";
                Box31.ValueMember = "travel_number";
            }
       void Dgv()
        {
            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }

            dt10.Clear();
            SqlCommand kk = new SqlCommand("select*from customers_view", conn);
            SqlDataAdapter ddd = new SqlDataAdapter(kk);
            ddd.Fill(dt10);
            EmployeeDataGridView.DataSource = dt10;
            conn.Close();
        }
        void DgvF()
        {
            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }

            dt11.Clear();
            SqlCommand kk = new SqlCommand("select*from fellow_v", conn);
            SqlDataAdapter ddd = new SqlDataAdapter(kk);
            ddd.Fill(dt11);
            EmployeeDataGridView.DataSource = dt11;
            conn.Close();
        }
        private void Haj_Load(object sender, EventArgs e)
            {
            //panel6.Visible = Class2._4;
            //panel5.Visible = 
            //panel1.Visible = 
            //panel2.Enabled = 
             
            label12.Text = radioButton1.Text;
                panel1.Visible = false;
                panel6.Visible = false;
                price();
                Box2.Focus();
            cus_ID();
            Fellow_ID();
            Dgv();
            travelcombobox();
        }
          
        
            private void radioButton1_Click(object sender, EventArgs e)
            {
                label12.Text = radioButton1.Text;

            }

            private void radioButton2_Click(object sender, EventArgs e)
            {
                label12.Text = radioButton2.Text;

            }

            private void radioButton4_Click(object sender, EventArgs e)
            {
                price();
            }

            private void radioButton3_Click(object sender, EventArgs e)
            {
                price();
            }

            private void checkBox7_CheckedChanged(object sender, EventArgs e)
            {
                price();

            }

            private void checkBox3_CheckedChanged(object sender, EventArgs e)
            {
                price();

            }

            private void checkBox4_CheckedChanged(object sender, EventArgs e)
            {
                price();
            }

            private void radioButton4_CheckedChanged(object sender, EventArgs e)
            {
                price();
            }

            private void browse_Click_1(object sender, EventArgs e)
            {
                try
                {


                    openFileDialog1.Filter = ("Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif; *.ico");

                    //Reset the file name
                    openFileDialog1.FileName = "";

                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        pic1.Image = Image.FromFile(openFileDialog1.FileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Invaild pic", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            private void checkBox7_Click(object sender, EventArgs e)
            {

                price();
            }

            private void Box31_Click(object sender, EventArgs e)
            {
                travelcombobox();
            }

            private void radioButton3_CheckedChanged(object sender, EventArgs e)
            {
                price();
            }

            private void button1_Click_2(object sender, EventArgs e)
            {
         
            relationshipComboBox.Enabled = true;
                New_Haj m = new New_Haj();
                m.ShowDialog();
        }

            private void button6_Click_1(object sender, EventArgs e)
            {
                panel1.Visible = true;
            panel6.Visible = false; panel5.Visible = false;

            }

            private void button8_Click_1(object sender, EventArgs e)
            {
            op = 0;
            d = op;
                panel1.Visible = false; panel6.Visible = false;
                panel5.Visible = true;
            }

            private void button9_Click_1(object sender, EventArgs e)
            {
                panel1.Visible = false; panel6.Visible = false;
                panel5.Visible = true;
            }

        private void button7_Click(object sender, EventArgs e)
        {//اذا هوه فينيش بنسكر الكانسل عند عمل حفظ سوا بالمرافق او الحاج 
         //نعمله بالفاينال
         if (button7.Text == "Finish") {
                op = 0;
                d = op;
                panel1.Visible = false; panel6.Visible = false;
                panel5.Visible = true;
            }
            button7.Enabled = false;
            button4.Enabled = true;
        }
        void service_ID()
        {
            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }
            SqlCommand mn = new SqlCommand("Select*from Service_Type", conn);
            SqlDataReader drm = mn.ExecuteReader();
            while (drm.Read())
            {
                Box24.Text = drm["service_ID"].ToString();
            }
            drm.Close();
            conn.Close();
        }
        void cus_ID()
        {
            if (conn.State == ConnectionState.Closed)
               { conn.Open(); }
                SqlCommand jjj = new SqlCommand("Select *from Customer", conn);
            SqlDataReader kkk = jjj.ExecuteReader();
            while (kkk.Read())
            {
                Box1.Text = kkk["cus_ID"].ToString();
            }
            kkk.Close();
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {//نعمله بالفاينال
            if (Box2.Text == "")
            {
                Box2.BackColor = Color.LightGoldenrodYellow;
                Box2.Focus();
                return;
            }
            else
            {
                Box2.BackColor = Color.FromKnownColor(KnownColor.Window);
            }


            if (Box3.Text == "")
            {
                Box3.BackColor = Color.LightGoldenrodYellow; Box3.Focus();
                return;
            }
            else
            {
                Box3.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box4.Text == "")
            {
                Box4.BackColor = Color.LightGoldenrodYellow; Box4.Focus();
                return;
            }
            else
            {
                Box4.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box5.Text == "")
            {
                Box5.BackColor = Color.LightGoldenrodYellow; Box5.Focus();
                return;
            }
            else
            {
                Box5.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box6.Text == "")
            {
                Box6.BackColor = Color.LightGoldenrodYellow; Box6.Focus();
                return;
            }
            else
            {
                Box6.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box7.Text == "")
            {
                Box7.BackColor = Color.LightGoldenrodYellow; Box7.Focus();
                return;
            }
            else
            {
                Box7.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box8.Text == "")
            {
                Box8.BackColor = Color.LightGoldenrodYellow; Box8.Focus();
                return;
            }
            else
            {
                Box8.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box10.Text == "")
            {
                Box10.BackColor = Color.LightGoldenrodYellow; Box10.Focus();
                return;
            }
            else
            {
                Box10.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box11.Text == "")
            {
                Box11.BackColor = Color.LightGoldenrodYellow; Box11.Focus();
                return;
            }
            else
            {
                Box11.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box12.Text == "")
            {
                Box12.BackColor = Color.LightGoldenrodYellow; Box12.Focus();
                return;
            }
            else
            {
                Box12.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box13.Text == "")
            {
                Box13.BackColor = Color.LightGoldenrodYellow; Box13.Focus();
                return;
            }
            else
            {
                Box13.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box14.Text == "")
            {
                Box14.BackColor = Color.LightGoldenrodYellow; Box14.Focus();
                return;
            }
            else
            {
                Box14.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box15.Text == "")
            {
                Box15.BackColor = Color.LightGoldenrodYellow; Box15.Focus();
                return;
            }
            else
            {
                Box15.BackColor = Color.FromKnownColor(KnownColor.Window);
            }

            if (Box16.Text == "")
            {
                Box16.BackColor = Color.LightGoldenrodYellow; Box16.Focus();
                return;
            }
            else
            {
                Box16.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box17.Text == "")
            {
                Box17.BackColor = Color.LightGoldenrodYellow; Box17.Focus();
                return;
            }
            else
            {
                Box17.BackColor = Color.FromKnownColor(KnownColor.Window);
            }


            if (Box20.Text == "")
            {
                Box20.BackColor = Color.LightGoldenrodYellow; Box20.Focus();
                return;
            }
            else
            {
                Box20.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box21.Text == "")
            {
                Box21.BackColor = Color.LightGoldenrodYellow; Box21.Focus();
                return;
            }
            else
            {
                Box21.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box22.Text == "")
            {
                Box22.BackColor = Color.LightGoldenrodYellow; Box22.Focus();
                return;
            }
            else
            {
                Box22.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box23.Text == "")
            {
                Box23.BackColor = Color.LightGoldenrodYellow; Box23.Focus();
                return;
            }
            else
            {
                Box23.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            ss = Class2.ll;
            op = Convert.ToInt32(Class2.o);
            d = op;
            if (ss == "Haj Mode")
            {

                check();
                try
                {
                    string l = Convert.ToString(Convert.ToInt32(Box28.Text + Box29.Text + Box30.Text));
                    if (conn.State == ConnectionState.Closed)
                    { conn.Open(); }
                    SqlCommand cmd = new SqlCommand("insert into Customer(cus_ID)", conn);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("cusId");
                    cus_ID();
                    cmd = new SqlCommand("insert into informations(cus_ID,first_name,second_name,last_name,nationality,phone_no,address,birth_day,sex,profile_pic) values (" + Box1.Text + ",'" + Box2.Text + "','" + Box6.Text + "','" + Box7.Text + ",'" + Box8.Text + "','" + Box4.Text + "','" + Box5.Text + "','" + Box3.Text + "','" + label12.Text + "',@23)", conn);
                    MemoryStream pp = new MemoryStream();
                    pic1.Image.Save(pp, pic1.Image.RawFormat);
                    Byte[] pdata = pp.GetBuffer();
                    //pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                    SqlParameter ppic = new SqlParameter("@23", System.Data.SqlDbType.Image);
                    ppic.Value = pdata;
                    cmd.Parameters.Add(ppic);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("insert into Passport(cus_ID,passport_no,type,surename,given_name,profession,place_of_birth,date_of_issue,date_of_expiry,issuing_authority) values (" + Box1.Text + "," + Box10.Text + ",'" + Box11.Text + "','" + Box12.Text + ",'" + Box13.Text + "','" + Box17.Text + "','" + Box16.Text + "','" + Box14.Value + "','" + Box15.Value + "','" + Box18.Text + "')", conn);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("insert into Guarantee(cus_ID,guarantee_type,guarantee_period,guarantee_cost,currancy_type) values (" + Box1.Text + "," + Box20.Text + ",'" + Box21.Value + "','" + Box22.Text + ",'" + Box23.Text + "')", conn);
                    cmd.ExecuteNonQuery();
                
                    
                    cmd = new SqlCommand("insert into Services(cus_ID,Transportations,Hotels,Meals,Total_services_price,service_Type) values (" + Box1.Text + ",'" + label8.Text + "','" + label9.Text + "','" + label14.Text + "','" + l + "','" + label13.Text + "')", conn);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("insert into CTravel(cus_ID,travel_number) values (" + Box1.Text + "," + Box31.Text + ")", conn);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Successfully Added", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Throwing Exception - Fronty", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                finally
                {
                    conn.Close();
                    button8.Enabled = false;
                    button7.Enabled = true;
                    button4.Enabled = false;
                    

                }
            }

            else
            {   
                //for (int m = 0; m <= i; m++)
                //while(i>=0)
                //{

                    if (op-d == 0)
                    {
                        if (relationshipComboBox.Text == "")
                        {
                            relationshipComboBox.BackColor = Color.LightGoldenrodYellow;
                            relationshipComboBox.Focus();
                            return;
                        }
                        else
                        {
                            relationshipComboBox.BackColor = Color.FromKnownColor(KnownColor.Window);
                        }
                        check();
                        
                        try
                        {
                            string l = Convert.ToString(Convert.ToInt32(Box28.Text + Box29.Text + Box30.Text));
                            if (conn.State == ConnectionState.Closed)
                            { conn.Open(); }
                            SqlCommand cmd = new SqlCommand("insert into Fellow(relationship)values('"+relationshipComboBox.Text+"')", conn);
                            cmd.ExecuteNonQuery();
                            Fellow_ID();
                            cus_ID();
                            cmd = new SqlCommand("insert into informations(fellow_ID,first_name,second_name,last_name,nationality,phone_no,address,birth_day,sex,profile_pic) values (" + textBox35.Text + ",'" + Box2.Text + "','" + Box6.Text + "','" + Box7.Text + ",'" + Box8.Text + "','" + Box4.Text + "','" + Box5.Text + "','" + Box3.Text + "','" + label12.Text + "',@23)", conn);
                            MemoryStream pp = new MemoryStream();
                            pic1.Image.Save(pp, pic1.Image.RawFormat);
                            Byte[] pdata = pp.GetBuffer();
                            //pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                            SqlParameter ppic = new SqlParameter("@23", System.Data.SqlDbType.Image);
                            ppic.Value = pdata;
                            cmd.Parameters.Add(ppic);
                            cmd.ExecuteNonQuery();
                        cmd = new SqlCommand("insert into Passport(fellow_ID,passport_no,type,surename,given_name,profession,place_of_birth,date_of_issue,date_of_expiry,issuing_authority) values (" + textBox35.Text + "," + Box10.Text + ",'" + Box11.Text + "','" + Box12.Text + ",'" + Box13.Text + "','" + Box17.Text + "','" + Box16.Text + "','" + Box14.Value + "','" + Box15.Value + "','" + Box18.Text + "')", conn);
                        cmd.ExecuteNonQuery();
                            cmd = new SqlCommand("insert into Guarantee(fellow_ID,guarantee_type,guarantee_period,guarantee_cost,currancy_type) values (" + textBox35.Text + "," + Box20.Text + ",'" + Box21.Value + "','" + Box22.Text + ",'" + Box23.Text + "')", conn);
                            cmd.ExecuteNonQuery();
                        cmd = new SqlCommand("insert into Services(fellow_ID,Transportations,Hotels,Meals,Total_services_price,service_Type) values (" + textBox35.Text + ",'" + label8.Text + "','" + label9.Text + "','" + label14.Text + "','" + l + "','" + label13.Text + "')", conn);
                        cmd.ExecuteNonQuery();
                            cmd = new SqlCommand("insert into CTravel(fellow_ID,travel_number) values (" + textBox35.Text + "," + Box31.Text + ")", conn);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Successfully Fellow  Added", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }


                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Throwing Exception - Fronty", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        finally
                        {
                            conn.Close();
                            button7.Enabled = true;
                            button4.Enabled = false;
                            op--;
                        }
                    }
                    else if(op!=0)
                    {

                        check();
                        relationshipComboBox.Enabled = false;
                        try
                        {
                            string l = Convert.ToString(Convert.ToInt32(Box28.Text + Box29.Text + Box30.Text));
                            if (conn.State == ConnectionState.Closed)
                            { conn.Open(); }
                            SqlCommand cmd = new SqlCommand("insert into Customer(fellow_ID)values()"+textBox35.Text+"", conn);
                            cmd.ExecuteNonQuery();
                            cus_ID();
                            cmd = new SqlCommand("insert into informations(cus_ID,first_name,second_name,last_name,nationality,phone_no,address,birth_day,sex,profile_pic) values (" + Box1.Text + ",'" + Box2.Text + "','" + Box6.Text + "','" + Box7.Text + ",'" + Box8.Text + "','" + Box4.Text + "','" + Box5.Text + "','" + Box3.Text + "','" + label12.Text + "',@23)", conn);
                            MemoryStream pp = new MemoryStream();
                            pic1.Image.Save(pp, pic1.Image.RawFormat);
                            Byte[] pdata = pp.GetBuffer();
                            //pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                            SqlParameter ppic = new SqlParameter("@23", System.Data.SqlDbType.Image);
                            ppic.Value = pdata;
                            cmd.Parameters.Add(ppic);
                            cmd.ExecuteNonQuery();
                        cmd = new SqlCommand("insert into Passport(cus_ID,passport_no,type,surename,given_name,profession,place_of_birth,date_of_issue,date_of_expiry,issuing_authority) values (" + Box1.Text + "," + Box10.Text + ",'" + Box11.Text + "','" + Box12.Text + ",'" + Box13.Text + "','" + Box17.Text + "','" + Box16.Text + "','" + Box14.Value + "','" + Box15.Value + "','" + Box18.Text + "')", conn);
                        cmd.ExecuteNonQuery();
                            cmd = new SqlCommand("insert into Guarantee(cus_ID,guarantee_type,guarantee_period,guarantee_cost,currancy_type) values (" + Box1.Text + "," + Box20.Text + ",'" + Box21.Value + "','" + Box22.Text + ",'" + Box23.Text + "')", conn);
                            cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("insert into Services(cus_ID,Transportations,Hotels,Meals,Total_services_price,service_Type) values (" + Box1.Text + ",'" + label8.Text + "','" + label9.Text + "','" + label14.Text + "','" + l + "','" + label13.Text + "')", conn);
                        cmd.ExecuteNonQuery();
                        cmd = new SqlCommand("insert into CTravel(cus_ID,travel_number) values (" + Box1.Text + "," + Box31.Text + ")", conn);
                        cmd.ExecuteNonQuery();

                            MessageBox.Show("Successfully Haj Added", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }


                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Throwing Exception - Fronty", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        finally
                        {
                            conn.Close();
                            button7.Enabled = true;
                            button4.Enabled = false;
                            op--;
                            if (op < 0)
                            {
                                button4.Enabled = false;
                                button7.Enabled = false;
                                button8.Enabled = true;
                                button8.Text = "Finish";

                            }
                            
                        }
                    }
                  
                }
            }
        
        void Fellow_ID()
        {
            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }
            SqlCommand jjj = new SqlCommand("Select *from Fellow", conn);
            SqlDataReader kkk = jjj.ExecuteReader();
            while (kkk.Read())
            {
                textBox35.Text = kkk["fellow_ID"].ToString();
            }
            kkk.Close();
            conn.Close();
        }
     public   void check()
        {
            if (Box2.Text == "")
            {
                Box2.BackColor = Color.LightGoldenrodYellow;
                Box2.Focus();
                return;
            }
            else
            {
                Box2.BackColor = Color.FromKnownColor(KnownColor.Window);
            }


            if (Box3.Text == "")
            {
                Box3.BackColor = Color.LightGoldenrodYellow; Box3.Focus();
                return;
            }
            else
            {
                Box3.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box4.Text == "")
            {
                Box4.BackColor = Color.LightGoldenrodYellow; Box4.Focus();
                return;
            }
            else
            {
                Box4.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box5.Text == "")
            {
                Box5.BackColor = Color.LightGoldenrodYellow; Box5.Focus();
                return;
            }
            else
            {
                Box5.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box6.Text == "")
            {
                Box6.BackColor = Color.LightGoldenrodYellow; Box6.Focus();
                return;
            }
            else
            {
                Box6.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (comboBox1.Text == "")
            {
                comboBox1.BackColor = Color.LightGoldenrodYellow; Box6.Focus();
                return;
            }
            else
            {
                comboBox1.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            }
            if (Box7.Text == "")
            {
                Box7.BackColor = Color.LightGoldenrodYellow; Box7.Focus();
                return;
            }
            else
            {
                Box7.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box8.Text == "")
            {
                Box8.BackColor = Color.LightGoldenrodYellow; Box8.Focus();
                return;
            }
            else
            {
                Box8.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box10.Text == "")
            {
                Box10.BackColor = Color.LightGoldenrodYellow; Box10.Focus();
                return;
            }
            else
            {
                Box10.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box11.Text == "")
            {
                Box11.BackColor = Color.LightGoldenrodYellow; Box11.Focus();
                return;
            }
            else
            {
                Box11.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box12.Text == "")
            {
                Box12.BackColor = Color.LightGoldenrodYellow; Box12.Focus();
                return;
            }
            else
            {
                Box12.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box13.Text == "")
            {
                Box13.BackColor = Color.LightGoldenrodYellow; Box13.Focus();
                return;
            }
            else
            {
                Box13.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box14.Text == "")
            {
                Box14.BackColor = Color.LightGoldenrodYellow; Box14.Focus();
                return;
            }
            else
            {
                Box14.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box15.Text == "")
            {
                Box15.BackColor = Color.LightGoldenrodYellow; Box15.Focus();
                return;
            }
            else
            {
                Box15.BackColor = Color.FromKnownColor(KnownColor.Window);
            }

            if (Box16.Text == "")
            {
                Box16.BackColor = Color.LightGoldenrodYellow; Box16.Focus();
                return;
            }
            else
            {
                Box16.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box17.Text == "")
            {
                Box17.BackColor = Color.LightGoldenrodYellow; Box17.Focus();
                return;
            }
            else
            {
                Box17.BackColor = Color.FromKnownColor(KnownColor.Window);
            }


            if (Box20.Text == "")
            {
                Box20.BackColor = Color.LightGoldenrodYellow; Box20.Focus();
                return;
            }
            else
            {
                Box20.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box21.Text == "")
            {
                Box21.BackColor = Color.LightGoldenrodYellow; Box21.Focus();
                return;
            }
            else
            {
                Box21.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box22.Text == "")
            {
                Box22.BackColor = Color.LightGoldenrodYellow; Box22.Focus();
                return;
            }
            else
            {
                Box22.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box23.Text == "")
            {
                Box23.BackColor = Color.LightGoldenrodYellow; Box23.Focus();
                return;
            }
            else
            {
                Box23.BackColor = Color.FromKnownColor(KnownColor.Window);
                return;
            }
           
        }


        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Box10_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void Box7_TextChanged(object sender, EventArgs e)
        {
            Box13.Text = Box2.Text + " " + Box6.Text + " " + Box7.Text;
        }

        private void Box6_TextChanged(object sender, EventArgs e)
        {
            Box13.Text = Box2.Text + " " + Box6.Text + " " + Box7.Text;

        }

        private void Box2_TextChanged(object sender, EventArgs e)
        {
            Box13.Text = Box2.Text + " " + Box6.Text + " " + Box7.Text;
            
        }


        private void Box4_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (Box2.Text == "")
            {
                Box2.BackColor = Color.LightGoldenrodYellow;
                Box2.Focus();
                return;
            }
            else
            {
                Box2.BackColor = Color.FromKnownColor(KnownColor.Window);
            }


            if (Box3.Text == "")
            {
                Box3.BackColor = Color.LightGoldenrodYellow; Box3.Focus();
                return;
            }
            else
            {
                Box3.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box4.Text == "")
            {
                Box4.BackColor = Color.LightGoldenrodYellow; Box4.Focus();
                return;
            }
            else
            {
                Box4.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box5.Text == "")
            {
                Box5.BackColor = Color.LightGoldenrodYellow; Box5.Focus();
                return;
            }
            else
            {
                Box5.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box6.Text == "")
            {
                Box6.BackColor = Color.LightGoldenrodYellow; Box6.Focus();
                return;
            }
            else
            {
                Box6.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (comboBox1.Text == "")
            {
                comboBox1.BackColor = Color.LightGoldenrodYellow; Box6.Focus();
                return;
            }
            else
            {
                comboBox1.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            }
            if (Box7.Text == "")
            {
                Box7.BackColor = Color.LightGoldenrodYellow; Box7.Focus();
                return;
            }
            else
            {
                Box7.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box8.Text == "")
            {
                Box8.BackColor = Color.LightGoldenrodYellow; Box8.Focus();
                return;
            }
            else
            {
                Box8.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box10.Text == "")
            {
                Box10.BackColor = Color.LightGoldenrodYellow; Box10.Focus();
                return;
            }
            else
            {
                Box10.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box11.Text == "")
            {
                Box11.BackColor = Color.LightGoldenrodYellow; Box11.Focus();
                return;
            }
            else
            {
                Box11.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box12.Text == "")
            {
                Box12.BackColor = Color.LightGoldenrodYellow; Box12.Focus();
                return;
            }
            else
            {
                Box12.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box13.Text == "")
            {
                Box13.BackColor = Color.LightGoldenrodYellow; Box13.Focus();
                return;
            }
            else
            {
                Box13.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box14.Text == "")
            {
                Box14.BackColor = Color.LightGoldenrodYellow; Box14.Focus();
                return;
            }
            else
            {
                Box14.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box15.Text == "")
            {
                Box15.BackColor = Color.LightGoldenrodYellow; Box15.Focus();
                return;
            }
            else
            {
                Box15.BackColor = Color.FromKnownColor(KnownColor.Window);
            }

            if (Box16.Text == "")
            {
                Box16.BackColor = Color.LightGoldenrodYellow; Box16.Focus();
                return;
            }
            else
            {
                Box16.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box17.Text == "")
            {
                Box17.BackColor = Color.LightGoldenrodYellow; Box17.Focus();
                return;
            }
            else
            {
                Box17.BackColor = Color.FromKnownColor(KnownColor.Window);
            }


            if (Box20.Text == "")
            {
                Box20.BackColor = Color.LightGoldenrodYellow; Box20.Focus();
                return;
            }
            else
            {
                Box20.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box21.Text == "")
            {
                Box21.BackColor = Color.LightGoldenrodYellow; Box21.Focus();
                return;
            }
            else
            {
                Box21.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box22.Text == "")
            {
                Box22.BackColor = Color.LightGoldenrodYellow; Box22.Focus();
                return;
            }
            else
            {
                Box22.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box23.Text == "")
            {
                Box23.BackColor = Color.LightGoldenrodYellow; Box23.Focus();
                return;
            }
            else
            {
                Box23.BackColor = Color.FromKnownColor(KnownColor.Window);
              
            }
            ss = Class2.ll;
            if (op == 999)
            {
                op = Convert.ToInt32(Class2.o);
                d = op;
            }
            if (ss == "Haj Mode")
            {
                try
                {
                    string l = Convert.ToString(Convert.ToDouble(Box28.Text + Box29.Text + Box30.Text));
                    if (conn.State == ConnectionState.Closed)
                    { conn.Open(); }
                    SqlCommand cmd = new SqlCommand("insert into Customer(cus_Type)values('"+comboBox1.Text+"')", conn);

                    cmd.ExecuteNonQuery();
                    
                    cus_ID();
                    if (conn.State == ConnectionState.Closed)
                    { conn.Open(); }
                    cmd = new SqlCommand("insert into informations(cus_ID,first_name,second_name,last_name,nationality,phone_no,address,birth_day,sex,profile_pic) values (" + Box1.Text + ",'" + Box2.Text + "','" + Box6.Text + "','" + Box7.Text + "','" + Box8.Text + "','" + Box4.Text + "','" + Box5.Text + "','" + Box3.Value + "','" + label12.Text + "',@23)", conn);
                    MemoryStream pp = new MemoryStream();
                    pic1.Image.Save(pp, pic1.Image.RawFormat);
                    Byte[] pdata = pp.GetBuffer();
                    //pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                    SqlParameter ppic = new SqlParameter("@23", SqlDbType.Image);
                    ppic.Value = pdata;
                    cmd.Parameters.Add(ppic);
                    if (conn.State == ConnectionState.Closed)
                    { conn.Open(); }
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("insert into Passport(cus_ID,passport_no,type,surname,given_name,profession,place_of_birth,date_of_issue,date_of_expiry,issuing_authority) values (" + Box1.Text + ",'" + Box10.Text + "','" + Box11.Text + "','" + Box12.Text + "','" + Box13.Text + "','" + Box17.Text + "','" + Box16.Text + "','" + Box14.Value + "','" + Box15.Value + "','" + Box18.Text + "')", conn);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("insert into Guarantee(cus_ID,guarantee_type,guarantee_period,guarantee_cost,currancy_type) values (" + Box1.Text + ",'" + Box20.Text + "','" + Box21.Value + "','" + Box22.Text + "','" + Box23.Text + "')", conn);
                    cmd.ExecuteNonQuery();
                   
                    cmd = new SqlCommand("insert into Services(cus_ID,Total_services_price,Transportations,Hotels,Meals) values (" + Box1.Text + ",'" + l + "','" + Box28.Text + "','" + Box29.Text + "','" + Box30.Text + "')", conn);
                    cmd.ExecuteNonQuery();
                    cus_ID();
                    if (conn.State == ConnectionState.Closed)
                    { conn.Open(); }
                cmd = new SqlCommand("INSERT INTO CTravel ( cus_ID,travel_No)VALUES (" + Box1.Text + "," + Box31.Text + ")", conn);
                cmd.ExecuteNonQuery();
                   MessageBox.Show("Successfully Added", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message + "hajmodddddddddd", "Throwing Exception - Fronty", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                finally
                {
                    conn.Close();
                    button8.Enabled = false;
                    button7.Enabled = true;
                    button4.Enabled = false;
                }
            }

            else
            {
                //for (int m = 0; m <= i; m++)
                //while(i>=0)
                //{

                if (op - d == 0)
                {
                    if (relationshipComboBox.Text == "")
                    {
                        relationshipComboBox.BackColor = Color.LightGoldenrodYellow;
                        relationshipComboBox.Focus();
                        return;
                    }
                    else
                    {
                        relationshipComboBox.BackColor = Color.FromKnownColor(KnownColor.Window);
                    }
                  

                    try
                    {
                        string l = Convert.ToString(Convert.ToDouble(Box28.Text + Box29.Text + Box30.Text));
                        if (conn.State == ConnectionState.Closed)
                        { conn.Open(); }
                        SqlCommand cmd = new SqlCommand("insert into Fellow(relationship,Fellow_Type)values('" + relationshipComboBox.Text + "','"+comboBox1.Text+"')", conn);
                        cmd.ExecuteNonQuery();
                        Fellow_ID();
                        cus_ID();
                        cmd = new SqlCommand("insert into informations(fellow_ID,first_name,second_name,last_name,nationality,phone_no,address,birth_day,sex,profile_pic) values (" + textBox35.Text + ",'" + Box2.Text + "','" + Box6.Text + "','" + Box7.Text + "','" + Box8.Text + "','" + Box4.Text + "','" + Box5.Text + "','" + Box3.Value + "','" + label12.Text + "',@23)", conn);
                        MemoryStream pp = new MemoryStream();
                        pic1.Image.Save(pp, pic1.Image.RawFormat);
                        Byte[] pdata = pp.GetBuffer();
                        //pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                        SqlParameter ppic = new SqlParameter("@23", System.Data.SqlDbType.Image);
                        ppic.Value = pdata;
                        cmd.Parameters.Add(ppic);
                        if (conn.State == ConnectionState.Closed)
                        { conn.Open(); }
                        cmd.ExecuteNonQuery();
                        cmd = new SqlCommand("insert into Passport(fellow_ID,passport_no,type,surname,given_name,profession,place_of_birth,date_of_issue,date_of_expiry,issuing_authority) values (" + textBox35.Text + ",'" + Box10.Text + "','" + Box11.Text + "','" + Box12.Text + "','" + Box13.Text + "','" + Box17.Text + "','" + Box16.Text + "','" + Box14.Value + "','" + Box15.Value + "','" + Box18.Text + "')", conn);
                        cmd.ExecuteNonQuery();
                        cmd = new SqlCommand("insert into Guarantee(fellow_ID,guarantee_type,guarantee_period,guarantee_cost,currancy_type) values (" + textBox35.Text + ",'" + Box20.Text + "','" + Box21.Value + "','" + Box22.Text + "','" + Box23.Text + "')", conn);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("insert into Services(fellow_ID,Total_services_price,Transportations,Hotels,Meals) values (" + textBox35.Text + ",'" + l + "','" + Box28.Text + "','" + Box29.Text + "','" + Box30.Text + "')", conn);
                        cmd.ExecuteNonQuery();
                        cus_ID();
                        if (conn.State == ConnectionState.Closed)
                        { conn.Open(); }
                        cmd = new SqlCommand("INSERT INTO CTravel ( fellow_ID,travel_No)VALUES ("+ textBox35.Text + "," + Box31.Text + ")",conn);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Successfully Added", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Throwing Exception - Fronty", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    finally
                    {
                        conn.Close();
                        button7.Enabled = true;
                        button4.Enabled = false;
                        relationshipComboBox.Enabled = false;

                    }
                }
                else if (op >= 0)
                {


                    try
                    {
                        string l = Convert.ToString(Convert.ToDouble(Box28.Text + Box29.Text + Box30.Text));
                        if (conn.State == ConnectionState.Closed)
                        { conn.Open(); }
                        SqlCommand cmd = new SqlCommand("insert into Customer(cus_Type,fellow_ID)values('" + comboBox1.Text + "','"+textBox35.Text+"')", conn);

                        cmd.ExecuteNonQuery();

                        cus_ID();
                        if (conn.State == ConnectionState.Closed)
                        { conn.Open(); }
                        cmd = new SqlCommand("insert into informations(cus_ID,first_name,second_name,last_name,nationality,phone_no,address,birth_day,sex,profile_pic) values (" + Box1.Text + ",'" + Box2.Text + "','" + Box6.Text + "','" + Box7.Text + "','" + Box8.Text + "','" + Box4.Text + "','" + Box5.Text + "','" + Box3.Value + "','" + label12.Text + "',@23)", conn);
                        MemoryStream pp = new MemoryStream();
                        pic1.Image.Save(pp, pic1.Image.RawFormat);
                        Byte[] pdata = pp.GetBuffer();
                        //pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                        SqlParameter ppic = new SqlParameter("@23", SqlDbType.Image);
                        ppic.Value = pdata;
                        cmd.Parameters.Add(ppic);
                        if (conn.State == ConnectionState.Closed)
                        { conn.Open(); }
                        cmd.ExecuteNonQuery();
                        cmd = new SqlCommand("insert into Passport(cus_ID,passport_no,type,surname,given_name,profession,place_of_birth,date_of_issue,date_of_expiry,issuing_authority) values (" + Box1.Text + ",'" + Box10.Text + "','" + Box11.Text + "','" + Box12.Text + "','" + Box13.Text + "','" + Box17.Text + "','" + Box16.Text + "','" + Box14.Value + "','" + Box15.Value + "','" + Box18.Text + "')", conn);
                        cmd.ExecuteNonQuery();
                        cmd = new SqlCommand("insert into Guarantee(cus_ID,guarantee_type,guarantee_period,guarantee_cost,currancy_type) values (" + Box1.Text + ",'" + Box20.Text + "','" + Box21.Value + "','" + Box22.Text + "','" + Box23.Text + "')", conn);
                        cmd.ExecuteNonQuery();
                      
                        if (conn.State == ConnectionState.Closed)
                        { conn.Open(); }
                        cmd = new SqlCommand("insert into Services(cus_ID,Total_services_price,Transportations,Hotels,Meals) values (" + Box1.Text + ",'" + l + "','" + Box28.Text + "','" + Box29.Text + "','" + Box30.Text + "')", conn);
                        cmd.ExecuteNonQuery();
                        cus_ID();
                        if (conn.State == ConnectionState.Closed)
                        { conn.Open(); }
                        cmd = new SqlCommand("INSERT INTO CTravel ( cus_ID,travel_No)VALUES (" + Box1.Text + "," + Box31.Text + ")", conn);
                        cmd.ExecuteNonQuery();
                       
                        MessageBox.Show("Successfully Added", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       

                    }
              
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Throwing Exception - Fronty", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
               
                    finally
                    {
                        if (op == 0)
                        {
                            button4.Enabled = false;
                            button8.Enabled = false;
                            button7.Enabled = true;
                            button7.Text = "Finish";
                        }
                        conn.Close();
                        button7.Enabled = true;
                        button4.Enabled = false;
                    }
                   
                }
             

            }
            op--;
            Dgv();

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            //اذا هوه فينيش بنسكر الكانسل عند عمل حفظ سوا بالمرافق او الحاج 
            //نعمله بالفاينال
           
            if (button7.Text == "Finish")
            {
                panel1.Visible = false; panel6.Visible = false;
                panel5.Visible = true;
            }
            button7.Enabled = false;
            button4.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            relationshipComboBox.Enabled = true;
            New_Haj m = new New_Haj();
            m.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel2.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            Box31.Enabled = false;
            panel1.Visible = false;
            panel6.Visible = true; panel5.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            op = 0;
            d = op;
            panel1.Visible = false; panel6.Visible = false;
            panel5.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Box2.Text == "")
            {
                Box2.BackColor = Color.LightGoldenrodYellow;
                Box2.Focus();
                return;
            }
            else
            {
                Box2.BackColor = Color.FromKnownColor(KnownColor.Window);
            }


            if (Box3.Text == "")
            {
                Box3.BackColor = Color.LightGoldenrodYellow; Box3.Focus();
                return;
            }
            else
            {
                Box3.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box4.Text == "")
            {
                Box4.BackColor = Color.LightGoldenrodYellow; Box4.Focus();
                return;
            }
            else
            {
                Box4.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box5.Text == "")
            {
                Box5.BackColor = Color.LightGoldenrodYellow; Box5.Focus();
                return;
            }
            else
            {
                Box5.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box6.Text == "")
            {
                Box6.BackColor = Color.LightGoldenrodYellow; Box6.Focus();
                return;
            }
            else
            {
                Box6.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (comboBox1.Text == "")
            {
                comboBox1.BackColor = Color.LightGoldenrodYellow; Box6.Focus();
                return;
            }
            else
            {
                comboBox1.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            }
            if (Box7.Text == "")
            {
                Box7.BackColor = Color.LightGoldenrodYellow; Box7.Focus();
                return;
            }
            else
            {
                Box7.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box8.Text == "")
            {
                Box8.BackColor = Color.LightGoldenrodYellow; Box8.Focus();
                return;
            }
            else
            {
                Box8.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box10.Text == "")
            {
                Box10.BackColor = Color.LightGoldenrodYellow; Box10.Focus();
                return;
            }
            else
            {
                Box10.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box11.Text == "")
            {
                Box11.BackColor = Color.LightGoldenrodYellow; Box11.Focus();
                return;
            }
            else
            {
                Box11.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box12.Text == "")
            {
                Box12.BackColor = Color.LightGoldenrodYellow; Box12.Focus();
                return;
            }
            else
            {
                Box12.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box13.Text == "")
            {
                Box13.BackColor = Color.LightGoldenrodYellow; Box13.Focus();
                return;
            }
            else
            {
                Box13.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box14.Text == "")
            {
                Box14.BackColor = Color.LightGoldenrodYellow; Box14.Focus();
                return;
            }
            else
            {
                Box14.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box15.Text == "")
            {
                Box15.BackColor = Color.LightGoldenrodYellow; Box15.Focus();
                return;
            }
            else
            {
                Box15.BackColor = Color.FromKnownColor(KnownColor.Window);
            }

            if (Box16.Text == "")
            {
                Box16.BackColor = Color.LightGoldenrodYellow; Box16.Focus();
                return;
            }
            else
            {
                Box16.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box17.Text == "")
            {
                Box17.BackColor = Color.LightGoldenrodYellow; Box17.Focus();
                return;
            }
            else
            {
                Box17.BackColor = Color.FromKnownColor(KnownColor.Window);
            }


            if (Box20.Text == "")
            {
                Box20.BackColor = Color.LightGoldenrodYellow; Box20.Focus();
                return;
            }
            else
            {
                Box20.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box21.Text == "")
            {
                Box21.BackColor = Color.LightGoldenrodYellow; Box21.Focus();
                return;
            }
            else
            {
                Box21.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box22.Text == "")
            {
                Box22.BackColor = Color.LightGoldenrodYellow; Box22.Focus();
                return;
            }
            else
            {
                Box22.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
            if (Box23.Text == "")
            {
                Box23.BackColor = Color.LightGoldenrodYellow; Box23.Focus();
                return;
            }
            else
            {
                Box23.BackColor = Color.FromKnownColor(KnownColor.Window);

            }
            if (radioButton6.Checked == true)
            {

                try
                {
                    string l = Convert.ToString(Convert.ToDouble(Box28.Text + Box29.Text + Box30.Text));
                    if (conn.State == ConnectionState.Closed)
                    { conn.Open(); }
                    SqlCommand addcommand = new SqlCommand("update Customer set cus_Type='" + comboBox1.Text + "' where cus_ID=" + Box1.Text + "", conn);
                    addcommand.ExecuteNonQuery();
                    addcommand = new SqlCommand("Update informations set first_name='" + Box2.Text + "',second_name ='" + Box6.Text + "',last_name='" + Box7.Text + "',nationality='" + Box8.Text + "',phone_no='" + Box4.Text + "',address= '" + Box5.Text + "',birth_day='" + Box3.Value + "',sex='" + label12.Text + "',profile_pic=@23 where cus_ID=" + Box1.Text + "", conn);
                    MemoryStream pp = new MemoryStream();
                    pic1.Image.Save(pp, pic1.Image.RawFormat);
                    Byte[] pdata = pp.GetBuffer();
                    SqlParameter ppic = new SqlParameter("@23", SqlDbType.Image);
                    ppic.Value = pdata;
                    addcommand.Parameters.Add(ppic);
                    addcommand.ExecuteNonQuery();
                    Dgv();
                    if (conn.State == ConnectionState.Closed)
                    { conn.Open(); }
                    addcommand = new SqlCommand("Update Passport set type='" + Box11.Text + "',surname ='" + Box12.Text + "',given_name='" + Box13.Text + "',profession='" + Box17.Text + "',place_of_birth='" + Box16.Text + "',date_of_issue= '" + Box14.Value + "',date_of_expiry='" + Box15.Value + "',issuing_authority='" + Box18.Text + "' where cus_ID=" + Box1.Text + "", conn);
                    addcommand.ExecuteNonQuery();
                    addcommand = new SqlCommand("Update Guarantee set guarantee_type='" + Box20.Text + "',guarantee_periode ='" + Box21.Value + "',guarantee_cost='" + Box22.Text + "',currency_type='" + Box23.Text + "' where cus_ID=" + Box1.Text + "", conn);
                    addcommand.ExecuteNonQuery();
                    //addcommand = new SqlCommand("Update Travels set cus_ID='" + Box1.Text + "'where travel_number=" + Box31.Text + "", conn);
                    //addcommand.ExecuteNonQuery();
                    l = Convert.ToString(Convert.ToDouble(Box28.Text + Box29.Text + Box30.Text));

                    addcommand = new SqlCommand("Update Service_Type set service_Type='" + label13.Text + "',Total_services_price='" + l + "'where service_ID=" + Box20.Text + "", conn);
                    addcommand.ExecuteNonQuery();
                    addcommand = new SqlCommand("Update Services set Transportation='" + label8.Text + "',Hotels='" + label9.Text + "',Meals='" + label14.Text + "'where service_No=" + textBox1.Text + "", conn);
                    addcommand.ExecuteNonQuery();
                    MessageBox.Show("Successfully Updated", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Throwing Exception - Fronty", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                finally
                {
                    conn.Close();
                    Dgv();
                }
            }
            else
            {
                try
                {
                    string l = Convert.ToString(Convert.ToDouble(Box28.Text + Box29.Text + Box30.Text));
                    if (conn.State == ConnectionState.Closed)
                    { conn.Open(); }
                    SqlCommand addcommand = new SqlCommand("update Fellow set fellow_Type='" + comboBox1.Text + "' where cus_ID=" + Box1.Text + ",relationnship='"+relationshipComboBox.Text+"'", conn);
                    addcommand.ExecuteNonQuery();
                    addcommand = new SqlCommand("Update informations set first_name='" + Box2.Text + "',second_name ='" + Box6.Text + "',last_name='" + Box7.Text + "',nationality='" + Box8.Text + "',phone_no='" + Box4.Text + "',address= '" + Box5.Text + "',birth_day='" + Box3.Value + "',sex='" + label12.Text + "',profile_pic=@23 where fellow_ID=" + textBox35.Text + "", conn);
                    MemoryStream pp = new MemoryStream();
                    pic1.Image.Save(pp, pic1.Image.RawFormat);
                    Byte[] pdata = pp.GetBuffer();
                    SqlParameter ppic = new SqlParameter("@23", SqlDbType.Image);
                    ppic.Value = pdata;
                    addcommand.Parameters.Add(ppic);
                    addcommand.ExecuteNonQuery();
                    Dgv();
                    if (conn.State == ConnectionState.Closed)
                    { conn.Open(); }
                    addcommand = new SqlCommand("Update Passport set type='" + Box11.Text + "',surname ='" + Box12.Text + "',given_name='" + Box13.Text + "',profession='" + Box17.Text + "',place_of_birth='" + Box16.Text + "',date_of_issue= '" + Box14.Value + "',date_of_expiry='" + Box15.Value + "',issuing_authority='" + Box18.Text + "' where fellow_ID=" + textBox35.Text + "", conn);
                    addcommand.ExecuteNonQuery();
                    addcommand = new SqlCommand("Update Guarantee set guarantee_type='" + Box20.Text + "',guarantee_periode ='" + Box21.Value + "',guarantee_cost='" + Box22.Text + "',currency_type='" + Box23.Text + "' where fellow_ID=" + textBox35.Text + "", conn);
                    addcommand.ExecuteNonQuery();
                    //addcommand = new SqlCommand("Update Travels set cus_ID='" + Box1.Text + "'where travel_number=" + Box31.Text + "", conn);
                    //addcommand.ExecuteNonQuery();
                    l = Convert.ToString(Convert.ToDouble(Box28.Text + Box29.Text + Box30.Text));

                    addcommand = new SqlCommand("Update Service_Type set service_Type='" + label13.Text + "',Total_services_price='" + l + "'where service_ID=" + Box20.Text + "", conn);
                    addcommand.ExecuteNonQuery();
                    addcommand = new SqlCommand("Update Services set Transportation='" + label8.Text + "',Hotels='" + label9.Text + "',Meals='" + label14.Text + "'where service_No=" + textBox1.Text + "", conn);
                    addcommand.ExecuteNonQuery();
                    MessageBox.Show("Successfully Updated", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Throwing Exception - Fronty", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                finally
                {
                  
                    conn.Close();
                    DgvF();
                }
            }


            }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Box31.Enabled = true;

            panel1.Visible = false; panel6.Visible = false;
            panel5.Visible = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "OMRAH")
            {
                radioButton3.Checked = true;
                radioButton3.Enabled = true;
                radioButton4.Enabled = false;

            }
            else
            {
                
                radioButton4.Checked = true;
                radioButton4.Enabled = true;
                radioButton3.Enabled = false;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
            {
                label17.Text = "This Selected will affected on Fellow Information ";
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked == true)
            {
                label17.Text = "This Selected will affected on Haj Information ";
            }
        }

        private void EmployeeDataGridView_Click(object sender, EventArgs e)
        {
            if (EmployeeDataGridView.CurrentRow != null)
            {

                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = false;
                //Box2.Text = EmployeeDataGridView.CurrentRow.Cells["first_name"].Value.ToString();
                //Box6.Text = EmployeeDataGridView.CurrentRow.Cells["second_name"].Value.ToString();
                //Box7.Text = EmployeeDataGridView.CurrentRow.Cells["last_name"].Value.ToString();
                Box8.Text = EmployeeDataGridView.CurrentRow.Cells["nationality"].Value.ToString();
                Box4.Text = EmployeeDataGridView.CurrentRow.Cells["phone_no"].Value.ToString();
                Box5.Text = EmployeeDataGridView.CurrentRow.Cells["address"].Value.ToString();
                Box9.Text = EmployeeDataGridView.CurrentRow.Cells["passport_ID"].Value.ToString();
                Box10.Text = EmployeeDataGridView.CurrentRow.Cells["passport_no"].Value.ToString();

                Box11.Text = EmployeeDataGridView.CurrentRow.Cells["type"].Value.ToString();
                Box12.Text = EmployeeDataGridView.CurrentRow.Cells["surname"].Value.ToString();
                Box17.Text = EmployeeDataGridView.CurrentRow.Cells["profession"].Value.ToString();

                Box13.Text = EmployeeDataGridView.CurrentRow.Cells["Full_Name"].Value.ToString();
                Box16.Text = EmployeeDataGridView.CurrentRow.Cells["place_of_birth"].Value.ToString();
                Box14.Text = EmployeeDataGridView.CurrentRow.Cells["date_of_issue"].Value.ToString();
                Box15.Text = EmployeeDataGridView.CurrentRow.Cells["date_of_expiry"].Value.ToString();
                Box18.Text = EmployeeDataGridView.CurrentRow.Cells["issuing_authority"].Value.ToString();

                Box19.Text = EmployeeDataGridView.CurrentRow.Cells["guarantee_ID"].Value.ToString();
                Box20.Text = EmployeeDataGridView.CurrentRow.Cells["guarantee_type"].Value.ToString();
                Box21.Text = EmployeeDataGridView.CurrentRow.Cells["guarantee_period"].Value.ToString();
                Box22.Text = EmployeeDataGridView.CurrentRow.Cells["guarantee_cost"].Value.ToString();
                Box23.Text = EmployeeDataGridView.CurrentRow.Cells["guarantee_type"].Value.ToString();
                Box24.Text = EmployeeDataGridView.CurrentRow.Cells["service_ID"].Value.ToString();
                textBox1.Text = EmployeeDataGridView.CurrentRow.Cells["service_No"].Value.ToString();
                //Box28.Text = EmployeeDataGridView.CurrentRow.Cells["Transportations"].Value.ToString();
                //Box29.Text = EmployeeDataGridView.CurrentRow.Cells["Hotels"].Value.ToString();
                //Box30.Text = EmployeeDataGridView.CurrentRow.Cells["Meals"].Value.ToString();
                Box31.Text = EmployeeDataGridView.CurrentRow.Cells["travel_number"].Value.ToString();
                comboBox1.Text = EmployeeDataGridView.CurrentRow.Cells["cus_Type"].Value.ToString();


                if (EmployeeDataGridView.Text == EmployeeDataGridView.CurrentRow.Cells["sex"].Value.ToString()) { radioButton1.Checked = true; } else { radioButton2.Checked = true; }
                DataGridViewRow row;
                row = EmployeeDataGridView.CurrentRow;
                Byte[] picture = (Byte[])row.Cells["profile_pic"].Value;
                MemoryStream ms = new MemoryStream(picture);
                pic1.Image = Image.FromStream(ms);

            }
        }

        private void EmployeeDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    }
