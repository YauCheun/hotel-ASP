<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manager.aspx.cs" Inherits="manager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        body{
            background-color:aliceblue;
        }
        .form1{
            width:900px;
            margin:100px auto;
        }
         .form1 h3{
        text-align: center;
        font-size: 26px;
        text-shadow: 1px 1px 1px rgba(0,0,0,0.3);
        color: #ff6637;
         }
    </style>
</head>
<body>
    <div class="form1">
        <h3>酒店管理界面</h3>
    <form id="form1" runat="server">
         <div>
    
        <asp:GridView ID="GV" runat="server" 
            AutoGenerateColumns="False" Caption="入住信息管理"  
            Width="900px" onrowcommand="GV_RowCommand" PageSize="7"
            BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" 
            CellPadding="8" CellSpacing="2" Font-Bold="True" Font-Size="X-Large" 
            onselectedindexchanged="GV_SelectedIndexChanged" EnableModelValidation="True" >
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <Columns>
                <asp:BoundField DataField="UserId" HeaderText="身份证号" />
                
                <asp:BoundField DataField="RoomId" HeaderText="房间号" />
                <asp:BoundField DataField="RoomType" HeaderText="房间类型" />
                 <asp:BoundField DataField="BookDay" HeaderText="预定天数" />
                 <asp:BoundField DataField="BookTime" HeaderText="预定时间" />

                <asp:ButtonField CommandName="Delete" HeaderText="删除" Text="删除" />
            </Columns>
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
      
   
         <asp:GridView ID="GV1" runat="server" 
            AutoGenerateColumns="False" Caption="空房信息管理"  
            Width="900px" onrowcommand="GV_RowCommand" PageSize="7"
            BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" 
            CellPadding="8" CellSpacing="2" Font-Bold="True" Font-Size="X-Large" 
            onselectedindexchanged="GV_SelectedIndexChanged" EnableModelValidation="True" >
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <Columns>           
                <asp:BoundField DataField="RoomId" HeaderText="房间号" />
                <asp:BoundField DataField="RoomType" HeaderText="房间类型" />
                 <asp:BoundField DataField="RoomPrice" HeaderText="价格" />

  

            </Columns>
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
        </asp:GridView>
      
    
    
    </div>
    </form>
        </div>
   

</body>
</html>
