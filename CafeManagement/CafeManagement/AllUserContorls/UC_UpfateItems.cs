﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeManagement.AllUserContorls
{
    public partial class UC_UpfateItems : UserControl
    {
        function fn = new function();
        string query;

        public UC_UpfateItems()
        {
            InitializeComponent();
        }

        private void UC_UpfateItems_Load(object sender, EventArgs e)
        {
            
            loadData();
        }

        public void loadData()
        {
            query = "select * from items";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void txtSearchItem_TextChanged(object sender, EventArgs e)
        {
            query = "select * from items where name like '" + txtSearchItem.Text + "%'";
            loadData();
        }

        int id;
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            string category = guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            string name = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            int price = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());

            TxtCategory.Text = category;
            txtName.Text = name;
            txtPrice.Text = price.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            query = "update items set name = '" + txtName.Text + "',category = '" + TxtCategory.Text + "',price = " + txtPrice + " where id = " + id + " ";
            fn.setData(query);
            loadData();

            txtName.Clear();
            TxtCategory.Clear();
            txtPrice.Clear();
        }
    }
}
