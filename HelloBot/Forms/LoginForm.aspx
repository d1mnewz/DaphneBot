<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="HelloBot.Controllers.LoginForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <link rel="shortcut icon" href="../images/icon.ico"
        type="image/x-icon" />
    <title>DaphneBot</title>
</head>
<body>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous">
    <!-- Latest compiled and minified JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
    <div class="panel panel-default">
        <a href="Index.aspx"><img src="../resources/logo.png" alt="Mountain View" style="width:150px;height:75px;"></a>
        <button type="button" class="btn btn-primary">Teams</button>
        <button type="button" class="btn btn-primary">Users</button>
        <a href="LoginForm.aspx"><button type="button" style="float:right;margin-top:1.4%;margin-left:1%" class="btn btn-primary">Login</button></a>
    </div>
    <form id="form1" runat="server" method="get" action="">
        <div>
            <input type="text" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter slackteam" style="width:30%;margin-left:1%;margin-top:1%" />
            <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email" style="width:30%;margin-left:1%;margin-top:1%"/>
            <input type="password" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter password" style="width:30%;margin-left:1%;margin-top:1%"/>
        </div>
        <div style="margin:1%;  class="form-group">
             <button type="submit"  class="btn btn-primary">Login</button>
        </div>
    </form>
</body>
</html>
