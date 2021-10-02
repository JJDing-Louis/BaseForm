using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseForm
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 表單關閉後，開始進行觸發事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("BaseForm已經關閉!");
        }

        /// <summary>
        /// 表單開始關閉時，進行觸發事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("BaseForm開始關閉!");
        }

        /// <summary>
        /// 表單進行載入時觸發事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show("BaseForm開始載入!");
        }

        /// <summary>
        /// 表單載入後進行觸發事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseForm_Shown(object sender, EventArgs e)
        {
            MessageBox.Show("BaseForm開始完畢!");
        }
    }
}