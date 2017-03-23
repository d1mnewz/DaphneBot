﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="HelloBot.Forms.UserPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="../css/bootstrap.min.css" rel="stylesheet">
<link href="../css/datepicker3.css" rel="stylesheet">
<link href="../css/styles.css" rel="stylesheet">
        <link rel="shortcut icon" href="../images/icon.ico"
        type="image/x-icon" />
<!--Icons-->
<script src="../js/lumino.glyphs.js"></script>
    <title>DaphneBot</title>
</head>
<body runat="server">
   <div id="sidebar-collapse" class="col-sm-3 col-lg-2 sidebar">
		
		<ul class="nav menu">
			<li ><a href="Index.aspx"><svg class="glyph stroked dashboard-dial"><use xlink:href="#stroked-dashboard-dial"></use></svg> Dashboard</a></li>
			<li><a href="Teams.aspx"><svg class="glyph stroked male-user"><use xlink:href="#stroked-male-user""></use></svg> Teams</a></li>
            <li><a href="Users.aspx"><svg class="glyph stroked male-user"><use xlink:href="#stroked-male-user""></use></svg> Users</a></li>
            <li ><a href="Questions.aspx"><svg class="glyph stroked male-user"><use xlink:href="#stroked-male-user""></use></svg> Questions</a></li>
            <li ><a href="QAs.aspx"><svg class="glyph stroked male-user"><use xlink:href="#stroked-male-user""></use></svg> QAs</a></li>
            <li><a href="Statuses.aspx"><svg class="glyph stroked male-user"><use xlink:href="#stroked-male-user"></use></svg> Statuses</a></li>
            <li class="active"><a href="Template.aspx"><svg class="glyph stroked male-user"><use xlink:href="#stroked-calendar"></use></svg> Template</a></li>
			<li role="presentation" class="divider"></li>
			<li><a href="LoginForm.aspx"><svg class="glyph stroked male-user"><use xlink:href="#stroked-male-user"></use></svg> Login Page</a></li>
		</ul>
		<div class="attribution">Template by <a href="http://www.medialoot.com/item/lumino-admin-bootstrap-template/">Medialoot</a><br/><a href="http://www.glyphs.co" style="color: #333;">Icons by Glyphs</a></div>
	</div><!--/.sidebar-->
	
	<nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
		<div class="container-fluid">
			<div class="navbar-header">
				<button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#sidebar-collapse">
					<span class="sr-only">Toggle navigation</span>
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
				</button>
				<a class="navbar-brand" href="#"><span>daphne</span>Bot</a>
                
				<ul class="user-menu">
					<li class="dropdown pull-right">
						<a href="#" class="dropdown-toggle" data-toggle="dropdown"><svg class="glyph stroked male-user"><use xlink:href="#stroked-male-user"></use></svg> User <span class="caret"></span></a>
						<ul class="dropdown-menu" role="menu">
							<li><a href="#"><svg class="glyph stroked male-user"><use xlink:href="#stroked-male-user"></use></svg> Profile</a></li>
							<li><a href="#"><svg class="glyph stroked gear"><use xlink:href="#stroked-gear"></use></svg> Settings</a></li>
							<li><a href="#"><svg class="glyph stroked cancel"><use xlink:href="#stroked-cancel"></use></svg> Logout</a></li>
						</ul>
					</li>
				</ul>
			</div>
							
		</div><!-- /.container-fluid -->
	</nav>

    <div class="col-sm-9 col-sm-offset-3 col-lg-10 col-lg-offset-2 main">			
		
		<form runat="server">
		<div class="row">
			<div class="col-lg-12">
				<h1 class="page-header"><asp:Label ID="LoginLbl" runat="server" Text=""></asp:Label></h1>
                <div class="row">
                    <div class="table-responsive-vertical shadow-z-1">
                        <div id="demo" style="margin:1%">
                    <h2><asp:Label Text="Full name: " runat="server" ID="FNameLbl"></asp:Label></h2>
                    
                    <asp:DropDownList runat="server" CssClass="form-control" ID="rolesDDl" Width="15%">

                    </asp:DropDownList>
                            <div style="margin-top:1%">
                    <asp:Button ID="SaveBtn" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="SaveBtn_Click"></asp:Button>
                                </div>
                            </div>
                         </div>
                </div>
			</div>
		</div><!--/.row-->
    </form>
        	<script src="../js/jquery-1.11.1.min.js"></script>
	<script src="../js/bootstrap.min.js"></script>
	<script src="../js/chart.min.js"></script>
	<script src="../js/chart-data.js"></script>
	<script src="../js/easypiechart.js"></script>
	<script src="../js/easypiechart-data.js"></script>
	<script src="../js/bootstrap-datepicker.js"></script>
	</div>
</body>
</html>

