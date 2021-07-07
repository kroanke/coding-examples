<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="gym.Homepage" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="contact.css" rel="stylesheet" />
    <script>
        function submit() {
            alert("We have recieved your message.");
        }
    </script>
    <div class="container" style="">
  <form action="#">

    <label for="fname">First Name</label>
    <input type="text" id="fname" name="firstname" placeholder="Your name..">

    <label for="lname">Last Name</label>
    <input type="text" id="lname" name="lastname" placeholder="Your last name..">
    
    <label for="phone">Phone Number</label>
    <input type="tel" id="phone" name="phone" placeholder="Your Phone Number..">
    
    <label for="mail">E-Mail</label>
    <input type="email" id="mail" name="mail" placeholder="Your E-Mail..">

    

    <label for="subject">Subject</label>
    <textarea id="subject" name="subject" placeholder="Write something.." style="height:200px"></textarea>

    <input type="button" onclick="submit()" value="Submit" style="width: 100%; on margin-top: -20px; background-color: green;">
      

  </form>
</div>
</asp:Content>