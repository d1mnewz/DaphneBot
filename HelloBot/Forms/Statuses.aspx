<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Statuses.aspx.cs" Inherits="HelloBot.Forms.Statuses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="../css/bootstrap.min.css" rel="stylesheet">
<link href="../css/datepicker3.css" rel="stylesheet">
<link href="../css/styles.css" rel="stylesheet">
    <link href="../css/Table.css" rel="stylesheet">
        <link rel="shortcut icon" href="../images/icon.ico"
        type="image/x-icon" />
<!--Icons-->
<script src="../js/lumino.glyphs.js"></script>
    <title>DaphneBot</title>
</head>
<body runat="server">
   <div id="sidebar-collapse" class="col-sm-3 col-lg-2 sidebar">
		
		<ul class="nav menu">
			<li><a href="Index.aspx"><svg class="glyph stroked dashboard-dial"><use xlink:href="#stroked-dashboard-dial"></use></svg> Dashboard</a></li>
			<li><a href="Teams.aspx"><svg class="glyph stroked male-user"><use xlink:href="#stroked-male-user""></use></svg> Teams</a></li>
            <li><a href="Users.aspx"><svg class="glyph stroked male-user"><use xlink:href="#stroked-male-user""></use></svg> Users</a></li>
            <li ><a href="Questions.aspx"><svg class="glyph stroked male-user"><use xlink:href="#stroked-male-user""></use></svg> Questions</a></li>
            <li ><a href="QAs.aspx"><svg class="glyph stroked male-user"><use xlink:href="#stroked-male-user""></use></svg> QAs</a></li>
            <li class="active"><a href="Statuses.aspx"><svg class="glyph stroked male-user"><use xlink:href="#stroked-male-user"></use></svg> Statuses</a></li>
            <li><a href="Template.aspx"><svg class="glyph stroked male-user"><use xlink:href="#stroked-calendar"></use></svg> Template</a></li>
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
		
		
		<div class="row">
			<div class="col-lg-12">
			</div>
		</div><!--/.row-->
        <div class="row">
			<div class="col-lg-12">
				<div class="panel panel-default">
					<div class="panel-heading">Statuses</div>
					<div id="demo">

            <!-- Responsive table starts here -->
            <!-- For correct display on small screens you must add 'data-title' to each 'td' in your table -->
            <div class="table-responsive-vertical shadow-z-1">
            <!-- Table starts here -->
            <table id="table" class="table table-hover table-mc-light-blue">
                <thead>
                  <tr>
                    <th>ID</th>
                    <th>User</th>
                    <th>Collecting Deadline</th>
                  </tr>
                </thead>
                <tbody>
                    <asp:Label ID="resultStr" runat="server" Text=""></asp:Label>
                </tbody>
              </table>
              </div>
            </div>
				</div>
			</div>
		</div><!--/.row-->	
    </div><!--/.row-->	



    
    <script src="../js/jquery-1.11.1.min.js"></script>
	<script src="../js/bootstrap.min.js"></script>
	<script src="../js/chart.min.js"></script>
	<script src="../js/chart-data.js"></script>
	<script src="../js/easypiechart.js"></script>
	<script src="../js/easypiechart-data.js"></script>
	<script src="../js/bootstrap-datepicker.js"></script>
	<script src="../js/bootstrap-table.js"></script>
		
</body>
</html>

