<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="team.aspx.cs" Inherits="gym.Homepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="team.css" rel="stylesheet" />
    <h1 style="text-align: center;">OUR TEAM</h1>
    <div class="row">
      <div class="column" style="padding-top: 0px; margin-left: 300px">
        <div class="card">
          <img src="kaan.jpeg" alt="kaan" style="width:100%">
          <div class="container">
            <h2>Kaan Can Yildirim</h2>
            <p class="title">CEO &amp; Personal Trainer</p>
            <p>Eskisehir Teknik Universitesi Spor Bilimleri Fakultesi 2015 mezunu. Emekli profesyonel basketbolcu ve Personal Trainer.</p>
            <p>ykaancan@gmail.com</p>
            <p><button class="button"><a href="mailto:ykaancan@gmail.com" style="color: white; text-decoration: none;">Contact</a></button></p>
          </div>
        </div>
      </div>
        
      <div class="column" style="padding-top: 0px">
        <div class="card">
          <img src="utku2.png" alt="utku" style="width:100%">
          <div class="container">
            <h2>Utkuhan Göl</h2>
            <p class="title">CEO &amp; Personal Trainer</p>
            <p>2017 Turkiye vucut gelistirme sampiyonu. Grup dersleri veriyor.</p>
            <p>utku_ggs@hotmail.com</p>
            <p><button class="button"><a href="mailto:utku_ggs@hotmail.com" style="color: white; text-decoration: none;">Contact</a></button></p>
          </div>
        </div>
      </div>

  
    </div>




</asp:Content>