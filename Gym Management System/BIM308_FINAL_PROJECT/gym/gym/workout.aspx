<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="workout.aspx.cs" Inherits="gym.Homepage" %>
<head>
    <title>Home Page</title>

    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css"/>
    <link rel="stylesheet" href="navbar.css"/>
    <link rel="stylesheet" href="footer.css"/>

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css"/>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" />
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
    

    <style>
        .imgA1 {
        z-index: 1;
    }
    .mySlides{
        z-index: -1;
    }
    footer{
        z-index: -2;
    }
    </style>
</head>
<body>
    <link href="team.css" rel="stylesheet" />
<div style="height: 70px; width: 100%; background-color: black;">
            <ul style="background-color: #232323; display: block; height: 70px;">
                  <li class="btn btn-dark"><a href="Homepage.aspx">Home</a></li>
                  <li class="btn btn-dark"><a href="shop.aspx">Shop</a></li>
                <li class="btn btn-dark"><a href="workout.aspx">Workout Videos</a></li>
                  <li class="btn btn-dark"><a href="contact.aspx">Contact</a></li>
                  <li class="btn btn-dark"><a href="team.aspx">Our Team</a></li>
                  <li style="float:right;" class="btn btn-info"><a href="signIn.aspx">Login</a></li>
             </ul>
        </div>
    <div class="row">
      <div class="column" style="padding-top: 0px; margin-left: 300px">
        <div class="card">
            <a target="_blank" href="https://www.youtube.com/watch?v=lWXhih3xbVc"><img src="chest.jpg" alt="chest" style="width:100%; height:100%"></a>
          <div class="container">
            <h2>Chest Workout</h2>
            
          </div>
        </div>
      </div>
        
      <div class="column" style="padding-top: 0px">
        <div class="card">
            <a href="https://www.youtube.com/watch?v=iGYeHsgb4CY"><img src="biceps.png" alt="biceps" style="width:100%"></a>
          <div class="container">
            <h2>Biceps Workout</h2>
            
          </div>
        </div>
      </div>

  
    </div>
    <footer style="margin-top:150px;">
            <div class="container1 bottom_border">
<div class="row">

<div class=" col-sm-4 col-md col-sm-4  col-12 col">
<h5 class="headin5_amrc col_white_amrc pt2">CONTACT US</h5>
<!--headin5_amrc-->
<p class="mb10">Eskisehir Teknik Universitesi</p>

<p><i class="fa fa fa-envelope"></i> <a href="mailto:ykaancan@gmail.com">ykaancan@gmail.com</a></p>
<p><i class="fa fa fa-envelope"></i> 
<a href="mailto:utku_ggs@hotmail.com">utku_ggs@hotmail.com</a></p>


</div>


<div class="col-sm-4 col-md  col-6 col">
<h5 class="headin5_amrc col_white_amrc pt2">WORKING HOURS</h5>
<!--headin5_amrc-->

<p>
   <i class="fa fa-clock-o" style="font-size:14px"></i>
WEEKDAYS:  10.00-22.00
</p>
<p>
  <i class="fa fa-clock-o" style="font-size:14px"></i>
   WEEKENDS: 12.00-24.00
</p>




</div>


</div>
</div>


<div class="container1">

<!--foote_bottom_ul_amrc ends here-->
<p class="text-center">Copyright @2021 | Designed by Kaan Can Yildirim &amp; Utkuhan Göl</p>


<!--social_footer_ul ends here-->
</div>

        </footer>


</body>
    



