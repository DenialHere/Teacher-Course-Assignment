using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject1912983
{
    public partial class index : System.Web.UI.Page
    {
        static OleDbConnection myconn;
        string passwordConfirm, jobTitle;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            
            formLogin.Visible = true;
            TeacherView.Visible = false;
            CoordView.Visible = false;
        }

        protected void ButtonView_Click(object sender, EventArgs e)
        {
            string id = dropEmployeeId.SelectedValue.ToString();
            myconn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/App_Data/SMTI.mdb"));
            myconn.Open();


            string sql = "SELECT * FROM CourseAssignments WHERE EmployeeId =@id";
            OleDbCommand myCmdTest = new OleDbCommand(sql, myconn);
            OleDbParameter myPar = new OleDbParameter("id", id);
            myPar.DbType = System.Data.DbType.String;
            myCmdTest.Parameters.Add(myPar);
            OleDbDataReader reader = myCmdTest.ExecuteReader();
            GridViewCoord.DataSource = reader;
            GridViewCoord.DataBind();
            reader.Close();
            if (GridViewCoord.Rows.Count <= 0)
            {
                LabelEmpty.Visible = true;
                LabelEmpty.Text = "Nothing found";
            }
            else 
            {
                LabelEmpty.Visible = false;
            }
        }

        protected void ButtonAssign_Click(object sender, EventArgs e)
        {
            string id = dropEmployeeId.SelectedValue.ToString();
            string courseCode = dropCourse.SelectedValue.ToString();
            string groupNumber = dropGroup.SelectedValue.ToString();
            string date = TextBoxDate.Text;


            myconn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/App_Data/SMTI.mdb"));
            myconn.Open();



            string sql = "SELECT count(*) from CourseAssignments WHERE EmployeeId=@id";
            OleDbCommand myCmdTest = new OleDbCommand(sql, myconn);
            OleDbParameter myPar = new OleDbParameter("id", id);
            myPar.DbType = System.Data.DbType.String;
            myCmdTest.Parameters.Add(myPar);
            myCmdTest.ExecuteNonQuery();
            int numberOfRows = (Int32)myCmdTest.ExecuteScalar();

            if (numberOfRows < 3)
            {
                LabelEmpty.Visible = false;
                sql = "INSERT INTO CourseAssignments (EmployeeId, CourseCode, GroupNumber, AssignedDate) " +
                 "VALUES (@id, @courseCode, @groupNumber, @date)";
                myCmdTest = new OleDbCommand(sql, myconn);
                myPar = new OleDbParameter("id", id);
                OleDbParameter myPar2 = new OleDbParameter("courseCode", courseCode);
                OleDbParameter myPar3 = new OleDbParameter("groupNumber", groupNumber);
                OleDbParameter myPar4 = new OleDbParameter("date", date);
                myPar.DbType = System.Data.DbType.String;
                myPar2.DbType = System.Data.DbType.String;
                myPar3.DbType = System.Data.DbType.String;
                myPar4.DbType = System.Data.DbType.String;
                myCmdTest.Parameters.Add(myPar);
                myCmdTest.Parameters.Add(myPar2);
                myCmdTest.Parameters.Add(myPar3);
                myCmdTest.Parameters.Add(myPar4);
                myCmdTest.ExecuteNonQuery();
            }
            else
            {
                LabelEmpty.Visible = true;
                LabelEmpty.Text = "Teacher can't be assigned to more than 3 courses";
            }
        }

        protected void TextBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            string username = TextBoxUsername.Text;
            string passwordEntered = TextBoxPassword.Text;

            try
            {
                myconn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/App_Data/SMTI.mdb"));
                myconn.Open();

                string sql = "SELECT Password FROM Users WHERE UserName =@user";
                OleDbCommand myCmdTest = new OleDbCommand(sql, myconn);
                OleDbParameter myPar = new OleDbParameter("user", username);
                myPar.DbType = System.Data.DbType.String;
                myCmdTest.Parameters.Add(myPar);
                OleDbDataReader reader = myCmdTest.ExecuteReader();
                while (reader.Read())
                {
                        passwordConfirm = reader[0].ToString();
                }
                reader.Close();



                


                sql = "SELECT JobTitle FROM Employees WHERE EmployeeId =@id";
                myCmdTest = new OleDbCommand(sql, myconn);
                myPar = new OleDbParameter("id", username);
                myPar.DbType = System.Data.DbType.String;
                myCmdTest.Parameters.Add(myPar);
                reader = myCmdTest.ExecuteReader();
                while (reader.Read())
                {
                        jobTitle = reader[0].ToString();

                }
                reader.Close();


                if (passwordEntered != passwordConfirm)
                {
                    LabelErrorMessage.Text = "Invalid username or password ";
                }
                else if (passwordEntered == passwordConfirm && jobTitle == "Coordinator")
                {
                    LabelErrorMessage.Text = "";
                    CoordView.Visible = true;
                    formLogin.Visible = false;


                    sql = "SELECT * FROM CourseAssignments";
                    myCmdTest = new OleDbCommand(sql, myconn);
                    reader = myCmdTest.ExecuteReader();
                    GridViewCoord.DataSource = reader;
                    GridViewCoord.DataBind();
                    reader.Close();

                    sql = "SELECT EmployeeId FROM Employees";
                    myCmdTest = new OleDbCommand(sql, myconn);
                    reader = myCmdTest.ExecuteReader();
                    dropEmployeeId.DataTextField = "EmployeeId";
                    dropEmployeeId.DataSource = reader;
                    dropEmployeeId.DataBind();
                    reader.Close();

                    sql = "SELECT CourseCode FROM Courses";
                    myCmdTest = new OleDbCommand(sql, myconn);
                    reader = myCmdTest.ExecuteReader();
                    dropCourse.DataTextField = "CourseCode";
                    dropCourse.DataSource = reader;
                    dropCourse.DataBind();
                    reader.Close();

                    sql = "SELECT GroupNumber FROM Groups";
                    myCmdTest = new OleDbCommand(sql, myconn);
                    reader = myCmdTest.ExecuteReader();
                    dropGroup.DataTextField = "GroupNumber";
                    dropGroup.DataSource = reader;
                    dropGroup.DataBind();
                    reader.Close();

                    TextBoxDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                }
                else {
                    LabelErrorMessage.Text = "";
                    formLogin.Visible = false;
                    TeacherView.Visible = true;
                    sql = "SELECT * FROM CourseAssignments WHERE EmployeeId = @id";
                    myCmdTest = new OleDbCommand(sql, myconn);
                    myPar = new OleDbParameter("id", username);
                    myPar.DbType = System.Data.DbType.String;
                    myCmdTest.Parameters.Add(myPar);
                    reader = myCmdTest.ExecuteReader();
                    GridViewAll.DataSource = reader;
                    GridViewAll.DataBind();
                    reader.Close();

                }






            }
            catch (Exception)
            {
                LabelErrorMessage.Text = "Invalid username or password " + passwordConfirm;
            }



        }
    }
}