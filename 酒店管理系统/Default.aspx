<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body{
            background:url(./images/2.jpg);
            position:fixed;
            top: 0;
            left: 0;
            width:100%;
            height:100%;
            min-width: 1000px;
            z-index:-10;
            zoom: 1;
            background-color: #fff;
            background-repeat: no-repeat;
            background-size: cover;
                  -webkit-background-size: cover;
                    -o-background-size: cover;
            background-position: center -300px;
        }
        .form{
            margin:100px auto;
            width:400px;
            padding:40px;
            background-color:#fff;
            opacity:0.8;
            color:#666;
            line-height:20px;
            font-size:16px;
            font-weight:600;
            box-shadow: 10px 4px 12px rgba(0,0,0,0.8);
            border-radius: 5px;
            margin-left:750px;
        }
        .form span{
            font-size:12px;
            color:#666;
        }
        .form #TxtName,#TxtPass{
            height:35px;
            width:250px;
            padding-left:10px;
            font-size:16px;
              border-radius: 3px;
        }
         .form h3{
             text-align:center;
               font-size:26px;
             text-shadow:1px 1px 1px rgba(0,0,0,0.3);
             color:skyblue;
         }
           .form #RadioButtonList1{
               margin-left:90px;
           }
             .form #BtnReg,#BtnLogin{
                 width:120px;
                 height:40px;
                 border:none;
                 border-radius:5px;
                 background-color:skyblue;
                 margin-left:40px;
1             }
              .form #BtnReg:hover,#BtnLogin:hover{
                  background-color:#666;
                  color:skyblue;
              }
    </style>
</head>
<body>
    <div class="form">
    <form id="form1" runat="server">
    <div style="width: 400px">
        <h3>酒店用户登录</h3>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;登录名：<asp:TextBox ID="TxtName" runat="server" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvTxtName" runat="server" 
            ControlToValidate="TxtName" ErrorMessage="*必填"></asp:RequiredFieldValidator>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;密　码：<asp:TextBox ID="TxtPass" runat="server" TextMode="Password" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvTxtPass" runat="server" 
            ControlToValidate="TxtPass" ErrorMessage="*必填"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:RadioButtonList ID="RadioButtonList1" runat="server"   RepeatDirection="Horizontal" >
             <asp:ListItem  >用户</asp:ListItem>
             <asp:ListItem >管理员</asp:ListItem>
        </asp:RadioButtonList>
        <br />
      
        
        <asp:Button ID="BtnReg" runat="server"
            OnClick="BtnReg_Click" Text="注册"   CausesValidation="false" /> &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
        <asp:Button ID="BtnLogin" runat="server"  
            OnClick="BtnLogin_Click" Text="登 录" /><br />
        <br />
        <asp:Label ID="LblCaution" runat="server" ForeColor="Red"></asp:Label>
    </div>
    </form>
        </div>
</body>
</html>
