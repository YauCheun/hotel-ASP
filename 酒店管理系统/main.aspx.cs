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

public partial class main : System.Web.UI.Page
{
    private int A;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckUser())
            Response.Redirect("Default.aspx");  
    }
    private bool CheckUser()  //  验证用户是否登录
    {
        if (Session["login_name"] == null)
        {
            Response.Write("<Script Language=JavaScript>alert('请登录！');</Script>");
            return false;
        }
        return true;

    }
    protected void BtnBook_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString =
            ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
        conn.Open();
        // 检查房间号是否已存在
        SqlCommand Cmd = new SqlCommand();
        Cmd.Connection = conn;
        Cmd.CommandText = "select [RoomId] from [Book]";
        SqlDataReader dr = Cmd.ExecuteReader();
        while (dr.Read())
        {        
            if (dr.GetString(0) == TxtRoomId.Text)
            {
                Response.Write("<Script Language=JavaScript>alert(\"该房间已经被预定，请您选择其他房间\")</Script>");
                conn.Close();
                return;
            }
        }
        conn.Close();
        string SqlStr;
        SqlStr = "Insert into [Book]([UserId],[RoomId],[BookTime],[BookDay]) values(@userid,@roomid,@booktime,@bookday)";
        Cmd.CommandText = SqlStr;
        // 添加参数对象,并给参数赋值
        SqlParameter para1 = new SqlParameter("@userid", SqlDbType.Int, 50);
        para1.Value = TxtUserId.Text;
        Cmd.Parameters.Add(para1);
        SqlParameter para2 = new SqlParameter("@roomid", SqlDbType.VarChar, 50);
        para2.Value = TxtRoomId.Text;
        Cmd.Parameters.Add(para2);
        SqlParameter para3 = new SqlParameter("@booktime", SqlDbType.DateTime, 50);
        string time= DateTime.Now.ToString();
        para3.Value = time;
        Cmd.Parameters.Add(para3);
        SqlParameter para4 = new SqlParameter("@bookday", SqlDbType.Int, 100);
        para4.Value = TxtDay.Text;
        Cmd.Parameters.Add(para4);
        try
        {
            conn.Open();            // 打开数据库连接
            Cmd.ExecuteNonQuery();      // 将添加记录
            Response.Write("<Script Language=JavaScript>alert(\"恭喜您预定成功\")</Script>");
        }
        catch (SqlException sqlException)
        { Response.Write(sqlException.Message); }   // 显示连接异常信息
        finally
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }
    }
}