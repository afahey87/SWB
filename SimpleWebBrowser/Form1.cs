using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWebBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// This function is called when the Exit menu item is clicked. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        /// <summary>
        /// This function is called when the About menu item is clicked. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This program was created by Adam Fahey and Mat Rumsey June 2017");
        }



        /// <summary>
        /// On CLick of this button the webControl will display the page requested in the text box. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            NavigateToPage();
        }


        /// <summary>
        /// This is the core function that will perform all navagation and ppost processing.
        /// </summary>
        private void NavigateToPage()
        {
            button1.Enabled = false;
            textBox1.Enabled = false;
            toolStripStatusLabel1.Text = "Navigation has started";

            webBrowser1.Navigate(textBox1.Text);
        }


        /// <summary>
        /// This will fire each time the key is pressed and released.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)ConsoleKey.Enter)
            {
                NavigateToPage();
            }
        }


        /// <summary>
        /// This function enables the buttonts to be clicked once the page has loaded. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            button1.Enabled = true;
            textBox1.Enabled = true;
            toolStripStatusLabel1.Text = "Navigation Complete";
        }


        /// <summary>
        /// This is the web browser progress bar. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if (e.CurrentProgress > 0 && e.MaximumProgress > 0)
            {
                toolStripProgressBar1.ProgressBar.Value = Math.Min((int)(e.CurrentProgress * 100 / e.MaximumProgress), 100);   // using Math.Min to    Set the maximum to not be graeted then 100 if it is greater then 100 it will auto select 100 as the max. 
            }
        }


        /// <summary>
        /// This button will bring you back to the last url.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }


        /// <summary>
        /// This button will bring you one postion forward to a URL you were just at.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();

        }
        /// <summary>
        /// This button will bring the user back to the stock Home page. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Home_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }
    }
}
