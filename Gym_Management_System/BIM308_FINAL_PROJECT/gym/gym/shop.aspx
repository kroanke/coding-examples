<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="shop.aspx.cs" Inherits="gym.Homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="shop.css" rel="stylesheet" />
    <script>
        function buy() {
          alert("Successfully bought the equipment");
        }
    </script>

    <div class="wrapper">
    <div class="product-img">
      <img src="https://productimages.hepsiburada.net/s/31/375/10341435867186.jpg" height="420" width="327">
    </div>
    <div class="product-info">
      <div class="product-text">
        <h1>Punching Bag</h1>
        <p>Black punching ball. Easy to set up. Long lifetime</p>
      </div>
      <div class="product-price-btn">
        <p><span>299</span>$</p>
        <button type="button" onclick="buy()">buy now</button>
      </div>
    </div>
  </div>
  <div class="wrapper">
    <div class="product-img">
      <img src="https://m.media-amazon.com/images/I/919d46mH0cL._AC_UL320_.jpg" alt="dumbell" height="420" width="327">
    </div>
    <div class="product-info">
      <div class="product-text">
        <h1>Gray Dumbell</h1>
        <p>High quality solid cast dumbbell encased in rubber,dumbbells will last throughout the years.</p>
      </div>
      <div class="product-price-btn">
        <p><span>39</span>$</p>
        <button type="button" onclick="buy()">buy now</button>
      </div>
    </div>
  </div>
    <div class="wrapper">
    <div class="product-img">
      <img src="https://images-na.ssl-images-amazon.com/images/I/615MG2tpqcL._AC_SL1500_.jpg" alt="treadmill" height="420" width="327">
    </div>
    <div class="product-info">
      <div class="product-text">
        <h1>Pink Treadmill</h1>
        <p>Portable Treadmill with Foldable Wheels</p>
      </div>
      <div class="product-price-btn">
        <p><span>49</span>$</p>
        <button type="button" onclick="buy()">buy now</button>
      </div>
    </div>
  </div>
    <div class="wrapper">
    <div class="product-img">
      <img src="https://smhttp-ssl-18062.nexcesscdn.net/media/prod.image/c/y/cybex-v-series-upright-bike.jpg" alt="bike" height="420" width="327">
    </div>
    <div class="product-info">
      <div class="product-text">
        <h1>Upright Bike</h1>
        <p>Upright Bike brings ease of use to indoor biking.</p>
      </div>
      <div class="product-price-btn">
        <p><span>299</span>$</p>
        <button type="button" onclick="buy()">buy now</button>
      </div>
    </div>
  </div>
    <div class="wrapper">
    <div class="product-img">
      <img src="https://smhttp-ssl-18062.nexcesscdn.net/media/prod.image/b/o/bosu-ball-1_2.jpg" alt="bosu-ball" height="420" width="327">
    </div>
    <div class="product-info">
      <div class="product-text">
        <h1>Bosu Ball</h1>
        <p>Created in 1999, the BOSU Ball has become one of the most popular and trusted fitness accessories in the industry.</p>
      </div>
      <div class="product-price-btn">
        <p><span>15</span>$</p>
        <button type="button" onclick="buy()">buy now</button>
      </div>
    </div>
  </div>
 
    

</asp:Content>