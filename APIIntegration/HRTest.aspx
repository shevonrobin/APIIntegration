<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HRTest.aspx.cs" Inherits="APIIntegration.HRTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="font-family:Arial">  
                <tr> 
                    <td>  
                            <asp:Button ID="btnadd" runat="server" Text="Add" OnClick="btnadd_Click" />  
                    </td> 
                </tr> 
                <tr>  
                    <td>  
                        <b>Result</b>  
                    </td>  
                    <td>  
                        <asp:Label ID="lblResult" runat="server" Text="Label"></asp:Label>  
                    </td>  
            </tr>  
            </table>  
        </div>
    </form>
</body>
</html>
