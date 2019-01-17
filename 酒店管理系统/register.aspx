<%@ Page Language="C#" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
            margin:50px auto;
            height:535px;
            width:400px;
            padding:20px;
            padding-top:0;
            background-color:#fff;
            opacity:0.8;
            color:#666;
            line-height:30px;
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
        .form #TxtLoginName,#TxtName,#TxtPass,#TxtPhone,#TxtSex{
            height:35px;
            width:250px;
            padding-left:10px;
            font-size:16px;
              border-radius: 3px;
              margin-bottom:10px;
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
             .form #BtnReg,#BtnCancel,#BtnBack{
                 width:100px;
                 height:40px;
                 border:none;
                 border-radius:5px;
                 background-color:skyblue;
                 margin-left:40px;
                 margin-bottom:20px;
1             }
               .form #BtnBack{
                   margin-left:280px;
               }
              .form #BtnReg:hover,#BtnCancel:hover,#BtnBack:hover{
                  background-color:#666;
                  color:skyblue;
              }
    </style>
</head>
<body>
    <div class="form" >
    <form id="form1" runat="server">
       <div >
        <br />
           <h3>  请输入相关信息</h3>
       
     
        身份证号：<asp:TextBox ID="TxtLoginName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvLoginName" runat="server" 
            ControlToValidate="TxtLoginName" ErrorMessage="*必填"></asp:RequiredFieldValidator>
        <br />
         &nbsp;用户名 &nbsp;：<asp:TextBox ID="TxtName" runat="server" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvName" runat="server" 
            ControlToValidate="TxtName" ErrorMessage="*必填"></asp:RequiredFieldValidator>
        <br />
        　 &nbsp;密码 ：<asp:TextBox ID="TxtPass" runat="server" TextMode="Password" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvPass" runat="server" 
            ControlToValidate="TxtPass" ErrorMessage="*必填"></asp:RequiredFieldValidator>
        <br />
        &nbsp;手机号 &nbsp;：<asp:TextBox ID="TxtPhone" runat="server" ></asp:TextBox>
        <br />
            &nbsp; &nbsp;性   别 &nbsp;：<asp:TextBox ID="TxtSex" runat="server"></asp:TextBox>
        <br />
    
        <br />
        <br />
        　<asp:Button ID="BtnReg" runat="server"
          Text="注 册"  onclick="BtnReg_Click" />
        &nbsp;&nbsp;
        <asp:Button ID="BtnCancel" runat="server" 
         Text="取 消"  CausesValidation="False" onclick="BtnCancel_Click" />        &nbsp;&nbsp;
         <asp:Button ID="BtnBack" runat="server" 
          Text="返 回"  onclick="BtnBack_Click" CausesValidation="false" /><br />
        <br />
        <asp:Label ID="LblCaution" runat="server" ForeColor="Red"></asp:Label><br />
    </div>
    </form>
        </div>
</body>
</html>
