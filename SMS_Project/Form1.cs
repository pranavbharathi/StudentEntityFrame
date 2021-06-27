using SMS_Project.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using SMS_Project.Data.Entities;
using System.Data.Entity;
using SMS_Project.Data.Migrations;

namespace SMS_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CenterToScreen();
            SetupData();
        }

        BackgroundWorker bw;
        private void SetupData()
        {
            //try
            //{
            //    using (var ctx=new StudentContext())
            //    {
            //        var student = ctx.Students.FirstOrDefault();
            //        MessageBox.Show("Done");
            //    }
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            labelStatus.Text = "Setting up data please wait...";

            bw = new BackgroundWorker();
            bw.DoWork += Bw_DoWork;
            bw.RunWorkerCompleted += Bw_RunWorkerCompleted;

            bw.RunWorkerAsync();
        }
        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var initializer = new MigrateDatabaseToLatestVersion<StudentContext, Configuration>();
                Database.SetInitializer(initializer);
                using (var ctx = new StudentContext())
                {
                    if (!ctx.Teachers.Any())
                    {
                        var teachers = new List<Teacher>()
                        {
                            new Teacher()
                            {
                                Name = "Pranav",
                                Age=30,
                                Address="Mysore",
                                Classes = new List<Class>()
                                {
                                    new Class() { Name="Class_8",Strenght=30},
                                    new Class() { Name="Class_9",Strenght= 40}
                                }
                            },

                            new Teacher()
                            {
                                Name = "Bharat",
                                Age=28,
                                Address="Mysore",
         
                                Classes = new List<Class>()
                                {
                                    new Class() { Name="Class_7",Strenght=40},
                                    new Class() { Name="Class_10",Strenght= 50}
                                }
                            }
                        };
                        ctx.Teachers.AddRange(teachers);
                    }

                    ctx.SaveChanges();
                    e.Result = "Ready!";
                }
            }
            catch (Exception ex)
            {
                e.Result = ex.Message;
            }

        }
        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            labelStatus.Text = e.Result.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnClassDetails_Click(object sender, EventArgs e)
        {
            using (var ctx = new StudentContext())
            {
                var typename = ctx.Classes.FirstOrDefault()?.Teacher.Name ?? "NA";
                MessageBox.Show(typename);
            }
        }

        private void btnDeleteClass_Click(object sender, EventArgs e)
        {
            using (var ctx = new StudentContext())
            {
                var Classes = ctx.Classes.Find(1);
                ctx.Classes.Remove(Classes);
                try
                {
                    ctx.SaveChanges();
                    MessageBox.Show("Removed");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            using (var ctx = new StudentContext())
            {
                try
                {
                    var student = new Student()
                    {
                        Name = "Keshava",
                        Hobby="Cricket,dancing",
                        Age=16,
                        Address="Mysore",
                    };

                    ctx.Students.Add(student);
                    ctx.SaveChanges();
                    MessageBox.Show("Added");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnMale_Click(object sender, EventArgs e)
        {
            using(var ctx=new StudentContext())
            {
                var MaleStudents=from p in ctx.Students
                               where p.Gender.Equals("male") 
                                select new
                                {
                                    p.Name,
                                    p.Gender,
                                    p.Age
                                };
       
                dataGridView1.DataSource = MaleStudents.ToList();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var ctx = new StudentContext())
            {
                var Students = from p in ctx.Students
                                   where p.CourseId.Equals(1)
                                   select new
                                   {
                                       p.Name,
                                       p.Gender,
                                       p.Age,
                                       p.CourseId
                                   };


                dataGridView1.DataSource = Students.ToList();

            }

        }
    }
}
