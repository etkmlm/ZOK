﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using ZoomAutoRecorder.Utils;
using System.Text.RegularExpressions;

namespace ZoomAutoRecorder
{
    public partial class Lessons : Form
    {
        Database.Lesson Manager;
        public Lessons()
        {
            InitializeComponent();
            Manager = new Database.Lesson();
        }

        private void RefreshOut()
        {
            Main.Manager.RefLessons();
            (Application.OpenForms["Main"] as Main).RefProgram();
            var addi = Application.OpenForms["AdditionalProgram"] as AdditionalProgram;
            if (addi != null)
            {
                addi.ops.RefreshLessons();
                addi.ops.RefreshList();
            }
        }
        private void Clear()
        {
            lvLessons.Items.Clear();
            txtLessonName.Clear();
            txtLink.Clear();
            txtTeacher.Clear();
            txtZoomID.Clear();
            txtZoomPass.Clear();
        }
        private void Lessons_Load(object sender, EventArgs e)
        {
            Manager.RefreshLessons();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Clear();
            Manager.RefreshLessons();
        }
        private void btnSolve_Click(object sender, EventArgs e)
        {
            try
            {
                string part = txtLink.Text.Split('/')[4];
                string id = part.Split('?')[0];
                string pass = part.Split('?')[1].Replace("pwd=", "");

                txtZoomID.Text = id;
                txtZoomPass.Text = pass;
                txtLink.Clear();
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
        }
        private void lvLessons_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvLessons.SelectedItems.Count <= 0) return;

            txtLessonName.Text = lvLessons.SelectedItems[0].SubItems[1].Text;
            txtZoomID.Text = lvLessons.SelectedItems[0].SubItems[2].Text;
            txtZoomPass.Text = lvLessons.SelectedItems[0].SubItems[3].Text;
            txtTeacher.Text = lvLessons.SelectedItems[0].SubItems[4].Text;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string lesson_name = txtLessonName.Text;
            string zoomid = txtZoomID.Text.Replace(" ", "");
            string zoompass = txtZoomPass.Text;
            string teacher = txtTeacher.Text;
            if (!string.IsNullOrWhiteSpace(lesson_name) && 
                !string.IsNullOrWhiteSpace(zoomid) && 
                !string.IsNullOrWhiteSpace(zoompass) && 
                !string.IsNullOrWhiteSpace(teacher) &&
                Regex.IsMatch(zoomid, @"^\d+$"))
            {
                if (Manager.CheckDup(lesson_name))
                    Main.ShowError("Bu isme sahip bir zoom linki daha var!");
                else
                {
                    Manager.AddLesson(lesson_name, zoomid, zoompass, teacher);
                    Clear();
                    Manager.RefreshLessons();
                    RefreshOut();
                }
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvLessons.SelectedItems.Count <= 0) return;
            int id = int.Parse(lvLessons.SelectedItems[0].SubItems[0].Text);
            Manager.DeleteLesson(id);
            Clear();
            Manager.RefreshLessons();
            RefreshOut();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string lesson_name = txtLessonName.Text;
            string zoomid = txtZoomID.Text.Replace(" ", "");
            string zoompass = txtZoomPass.Text;
            string teacher = txtTeacher.Text;
            if (lvLessons.SelectedItems.Count > 0 && 
                !string.IsNullOrWhiteSpace(lesson_name) && 
                !string.IsNullOrWhiteSpace(zoomid) && 
                !string.IsNullOrWhiteSpace(zoompass) && 
                !string.IsNullOrWhiteSpace(teacher) &&
                Regex.IsMatch(zoomid, @"^\d+$"))
            {
                int id = int.Parse(lvLessons.SelectedItems[0].SubItems[0].Text);
                Manager.UpdateLesson(id, lesson_name, zoomid, zoompass, teacher);
                Clear();
                Manager.RefreshLessons();
                RefreshOut();
            }
        }
        private void lvLessons_KeyDown(object sender, KeyEventArgs e)
        {
            btnDelete_Click(null, null);
        }
    }
}
