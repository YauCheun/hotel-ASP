using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void BtnReg_Click(object sender, EventArgs e)
    {
            Response.Redirect("register.aspx");
    }
        protected void BtnLogin_Click(object sender, EventArgs e)
    {
        //获取用户在页面上的输入
        string userLoginName = TxtName.Text.Trim();	//用户登录名
        string userPassword = TxtPass.Text.Trim();	//密码
        int type = RadioButtonList1.SelectedIndex;
        SqlDataReader dr; // 新建DataReader对象
        // 新建数据库连接conn，连接到SQL SERVER数据库

        SqlConnection conn = new SqlConnection();
        conn.ConnectionString =
            ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
        // 新建Command对象
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        if (type == 0)
        {
            cmd.CommandText = "SELECT [PassWord] FROM [User] where  UserName=@LoginName";
            cmd.CommandType = CommandType.Text;
            // 添加查询参数对象,并给参数赋值
            SqlParameter para = new SqlParameter("@LoginName", SqlDbType.NVarChar, 50);
            para.Value = userLoginName;
            cmd.Parameters.Add(para);
            try                         // 打开conn连接，检索User表的Password字段
            {
                conn.Open();                // 打开数据库连接
                dr = cmd.ExecuteReader();   // 将检索的记录行填充到DataReader对象中
                if (dr.Read())              //如果用户存在
                {                       // 如果密码正确，显示登录成功
                    if (dr.GetString(0) == userPassword)
                    {   // 登录成功后记下该用户登录名，以便后续功能使用
                        Session.Add("login_name", userLoginName);
                        TxtName.Text = "";
                        Response.Redirect("main.aspx");
                    }
                    else                //如果密码错误，给出提示
                    {
                        Response.Write("<Script Language=JavaScript>alert(\"密码错误，请重新输入密码！\")</Script>");
                    }
                }
                else  //如果用户不存在
                {
                    Response.Write("<Script Language=JavaScript>alert(\"对不起，用户不存在！\")</Script>");
                }
                dr.Close();                         //关闭DataReader对象
            }
            catch (SqlException sqlException)
            {
                Response.Write(sqlException.Message);  // 显示连接异常信息
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            
        }
        else
        {
            cmd.CommandText = "SELECT [MaPassWord] FROM [Manager] where  ManagerId=@LoginName";
            cmd.CommandType = CommandType.Text;
            // 添加查询参数对象,并给参数赋值
            SqlParameter para = new SqlParameter("@LoginName", SqlDbType.Int, 50);
            para.Value = userLoginName;
            cmd.Parameters.Add(para);
            try                         // 打开conn连接，检索User表的Password字段
            {
                conn.Open();                // 打开数据库连接
                dr = cmd.ExecuteReader();   // 将检索的记录行填充到DataReader对象中
                if (dr.Read())              //如果用户存在
                {                       // 如果密码正确，显示登录成功
                    if (dr.GetString(0) == userPassword)
                    {   // 登录成功后记下该用户登录名，以便后续功能使用
                        Session.Add("login_name", userLoginName);
                        TxtName.Text = "";
                        Response.Redirect("manager.aspx");

                    }
                    else                //如果密码错误，给出提示
                    {
                        Response.Write("<Script Language=JavaScript>alert(\"密码错误，请重新输入密码！\")</Script>");
                    }
                }
                else  //如果用户不存在
                {
                    Response.Write("<Script Language=JavaScript>alert(\"对不起，用户不存在！\")</Script>");
                }
                dr.Close();                         //关闭DataReader对象
            }
            catch (SqlException sqlException)
            {
                Response.Write(sqlException.Message);  // 显示连接异常信息
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
     
    }

  
}