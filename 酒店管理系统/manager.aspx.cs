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
public partial class manager : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckUser())
            Response.Redirect("Default.aspx");
        InitData();
        InitData1();
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

    protected void GV_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    private void InitData()   /// 按时间降序，读取入住信息数据
    {
        // 新建数据库连接conn，连接到SQL SERVER数据库
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
        DataSet ds = new DataSet();         // 新建DataSet对象
                                            // 新建DataAdapter对象，打开conn连接，检索Topic表的所有字段
      
        string sql = "SELECT [Book].[UserId], [Book].[RoomId], [Room].[RoomType], [Book].[BookDay], [Book].[BookTime] FROM [Book],[Room] where  Book.RoomId=Room.RoomId order by BookTime desc";


        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
     
        conn.Open();	 				// 打开数据库连接
        da.Fill(ds); 					// 将检索的记录行填充到DataSet对象ds中

        conn.Close();                   // 关闭数据库连接

        GV.DataSource = ds; 	 			//设置数据源
        GV.DataBind();   				//绑定数据源
      
    }
    private void InitData1()   /// 按时间降序，读取入住信息数据
    {
        // 新建数据库连接conn，连接到SQL SERVER数据库
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
        DataSet ds1 = new DataSet();         // 新建DataSet对象
                                            // 新建DataAdapter对象，打开conn连接，检索Topic表的所有字段

        string sql2 = "SELECT * FROM [Room] where RoomId not in (SELECT RoomId FROM [Book])";


        SqlDataAdapter da1 = new SqlDataAdapter(sql2, conn);

        conn.Open();	 				// 打开数据库连接
        da1.Fill(ds1); 					// 将检索的记录行填充到DataSet对象ds中

        conn.Close();                   // 关闭数据库连接

        GV1.DataSource = ds1; 	 			//设置数据源
        GV1.DataBind();                  //绑定数据源

    }
    private void deleteData(int topic_Id) // 删除预定信息
    {
        // 新建数据库连接conn，连接到SQL SERVER数据库
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString =
            ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
        // 新建Command对象
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "DELETE FROM [Book] where RoomId=@roomid";
        cmd.CommandType = CommandType.Text;
        // 添加查询参数对象,并给参数赋值
        SqlParameter para = new SqlParameter("@roomid", SqlDbType.VarChar);
        para.Value = topic_Id;
        cmd.Parameters.Add(para);
        try
        {
            conn.Open();  							// 打开数据库连接
            cmd.ExecuteNonQuery();  					//将添加记录
            Response.Redirect("manager.aspx");
        }
        catch (SqlException sqlException)
        { Response.Write(sqlException.Message); } 	// 显示连接异常信息
        finally
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

    }
    protected void GV_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument); 		//待处理的行下标
        int topicId = -1;
        switch (e.CommandName)
        {    //删除
            case "Delete":
                topicId = Convert.ToInt32(GV.Rows[index].Cells[1].Text);
                deleteData(topicId);
                InitData();
                InitData1();
                break;
            default:
                break;
        }


    }
}