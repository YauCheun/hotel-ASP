using System;
using System.Collections;
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

public partial class register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnReg_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString =
            ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
        conn.Open();
        // 检查用户是否已存在
        SqlCommand Cmd = new SqlCommand();
        Cmd.Connection = conn;
        Cmd.CommandText = "select [UserName] from [User]";
        SqlDataReader dr = Cmd.ExecuteReader();
        while (dr.Read())
        {
            if (dr.GetString(0) == TxtName.Text)
            {
                LblCaution.Text = TxtName.Text + "已经存在，请你选择另外的登录名！";
                conn.Close();
                return;
            }
        }
        conn.Close();
        string SqlStr;
        SqlStr = "Insert into [User]([UserId],[UserName],[PassWord],[UserPhone],[UserSex]) values(@LoginName,@UserName,@Password,@Phone,@Sex)";
        Cmd.CommandText = SqlStr;
        // 添加参数对象,并给参数赋值
        SqlParameter para1 = new SqlParameter("@LoginName", SqlDbType.Int, 50);
        para1.Value = TxtLoginName.Text;
        Cmd.Parameters.Add(para1);
        SqlParameter para2 = new SqlParameter("@UserName", SqlDbType.NVarChar, 50);
        para2.Value = TxtName.Text;
        Cmd.Parameters.Add(para2);
        SqlParameter para3 = new SqlParameter("@Password", SqlDbType.VarChar, 50);
        para3.Value = TxtPass.Text;
        Cmd.Parameters.Add(para3);
        SqlParameter para4 = new SqlParameter("@Phone", SqlDbType.Int, 100);
        para4.Value = TxtPhone.Text;
        Cmd.Parameters.Add(para4);
        SqlParameter para5 = new SqlParameter("@Sex", SqlDbType.NVarChar, 50);
        para5.Value = TxtSex.Text;
        Cmd.Parameters.Add(para5);
        try
        {
            conn.Open();            // 打开数据库连接
            Cmd.ExecuteNonQuery();      // 将添加记录
            Response.Write("<script language=javascript>alert('恭喜您注册成功！');</script>");
        }
        catch (SqlException sqlException)
        { Response.Write(sqlException.Message); }   // 显示连接异常信息
        finally
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }
    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        TxtLoginName.Text = "";
        TxtName.Text = "";
        TxtPass.Text = "";
        TxtPhone.Text = "";
        TxtSex.Text = "";
        LblCaution.Text = "";
        Response.Write("<script language=javascript>alert('用户已取消注册！');</script>");
    }

    protected void BtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}