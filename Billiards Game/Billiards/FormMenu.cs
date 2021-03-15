using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Billiards
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
           
        }


        private void button_start_Click(object sender, EventArgs e)
        {
            start_GameForm(0);

        }
        private void start_GameForm(int Shot)
        {
            GameForm gameform = new GameForm(Shot);
            gameform.Show();

            DateTime currentUpdateTime;
            DateTime lastUpdateTime;
            TimeSpan frameTime;

            currentUpdateTime = DateTime.Now;
            lastUpdateTime = DateTime.Now;

            while (gameform.Created == true)
            {
                currentUpdateTime = DateTime.Now;
                frameTime = currentUpdateTime - lastUpdateTime;
                if (frameTime.TotalMilliseconds > 10)
                {
                    Application.DoEvents();
                    gameform.UpdateWorld();
                    gameform.Refresh();
                    lastUpdateTime = DateTime.Now;
                }
            }
        }
        private void button_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {

        }

        private void правилоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutProgram about_program = new AboutProgram();
            about_program.ShowDialog();
        }

        private void ОбАвтореToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Разработчик игры студент 1 курса группы ИС-19: Исрафилов Сабухи " +
                "Sabuhi.israfilov2001@gmail.com");
        }

        private void btComp_Click(object sender, EventArgs e)
        {
            start_GameForm(1);
        }

        private void FormMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}

