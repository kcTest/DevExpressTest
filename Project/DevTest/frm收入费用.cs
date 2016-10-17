﻿using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevTest
{
    public partial class frm收入费用 : XtraForm
    {
        public frm收入费用()
        {
            InitializeComponent();
        }
        public string str类别;
        public string str名称;
        public string str金额;
        public string str期数;
        public string str状态;
        private void frm收入费用_Load(object sender, EventArgs e)
        {
            cmb类别.Properties.Items.Add(new string[] { "1","收入"});
            cmb类别.Properties.Items.Add(new string[] { "-1", "费用" });
            chk状态.Checked = false;
            if (!string.IsNullOrEmpty(str类别))
            {
                cmb类别.EditValue = str类别;
            }
            if (!string.IsNullOrEmpty(str名称))
            {
                txt名称.EditValue = str名称;
            }
            if (!string.IsNullOrEmpty(str金额))
            {
                txt金额.Text = str金额;
            }
            if (!string.IsNullOrEmpty(str期数))
            {
                txt期数.EditValue = str类别;
            }
            if (!string.IsNullOrEmpty(str状态))
            {
                if (str状态.Equals("0"))
                    chk状态.EditValue = 0;
                else
                    chk状态.EditValue = 1;
            }
        }

        private void btn添加_Click(object sender, EventArgs e)
        {
            pc名称.Visible = false;
            pc期数.Visible = false;
            pc类别.Visible = false;
            pc金额.Visible = false;
            if (string.IsNullOrEmpty(cmb类别.Text.ToString().Trim()))
            {
                cmb类别.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Error;
                cmb类别.ToolTip = "选择类别！";
                cmb类别.Focus();
                pc类别.Visible = true;
                return;
            }
             if (string.IsNullOrEmpty(txt名称.Text.ToString().Trim()))
            {
                txt名称.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Error;
                txt名称.ToolTip = "名称不能为空！";
                txt名称.Focus();
                pc名称.Visible = true;
                return;
            }
             if (string.IsNullOrEmpty(txt期数.Text.ToString().Trim()))
            {
                txt期数.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Error;
                txt期数.ToolTip = "期数不能为空！";
                txt期数.Focus();
                pc期数.Visible = true;
                return;
            }

             if (string.IsNullOrEmpty(txt金额.Text.ToString().Trim()))
            {
                txt金额.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Error;
                txt金额.ToolTip = "金额不能为空！";
                txt金额.Focus();
                pc金额.Visible = true;
                return;
            }
             if (Convert.ToDecimal(txt金额.Text.ToString().Trim()) <= 0)
            {
                txt金额.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Error;
                txt金额.ToolTip = "金额必须为正数！";
                txt金额.Focus();
                pc金额.Visible = true;
                return;
            }
             if (cmb类别.Text.Equals("费用") && !txt期数.Text.Trim().Equals("1"))
            {
                txt期数.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Error;
                txt期数.ToolTip = "费用项目期数必须为1！";
                txt期数.Focus();
                pc期数.Visible = true;
                return;
            }
             if (cmb类别.Text.Equals("收入") && Convert.ToInt32(txt期数.Text.Trim()) <= 0)
            {
                txt期数.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Error;
                txt期数.ToolTip = "收入项目期数为正数！";
                txt期数.Focus();
                pc期数.Visible = true;
                return;
            }
            else
            {
                frm添加合约.sDt收入费用.Rows.Add(-1,cmb类别.EditValue.ToString(), txt名称.Text.Trim(), txt金额.Text.Trim(), txt期数.Text.Trim(), chk状态.EditValue.ToString().Trim());
                this.DialogResult = DialogResult.OK;
            }
        }

        private void cmb类别_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmb类别.Text))
            {
                pc类别.Visible = false;
                cmb类别.ShowToolTips = false;
            }
            if (cmb类别.EditValue.ToString().Equals("费用"))
            {
                txt期数.EditValue = 1;
                txt期数.Enabled = false;
            }
            else
            {
                txt期数.Enabled = true;
                txt期数.Text = "";
            }
        }

        private void chk状态_CheckedChanged(object sender, EventArgs e)
        {
            if (chk状态.Checked)
                chk状态.EditValue = 1;
            else
                chk状态.EditValue = 0;
        }

        private void txt名称_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt名称.Text.Trim()))
            {
                pc名称.Visible = false;
                txt名称.ShowToolTips = false;
            }
        }

        private void txt金额_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt金额.Text.Trim()))
            {
                pc金额.Visible = false;
                txt金额.ShowToolTips = false;
            }
        }

        private void txt期数_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt期数.Text.Trim()))
            {
                pc期数.Visible = false;
                txt期数.ShowToolTips = false;
            }
        }
    }
}
