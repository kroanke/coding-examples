import 'menu.dart';
import 'package:flutter/material.dart';


class Home extends StatefulWidget {
  @override
  State<StatefulWidget> createState() => HomeState();
}

class HomeState extends State<Home> {
  void giris(){

  }
  @override
  Widget build(BuildContext context) {
    return initScreen();
  }

  Widget initScreen() {
    Size size = MediaQuery
        .of(context)
        .size;
    return Scaffold(
      backgroundColor: Color(0xff053F5E),
      appBar: AppBar(
        backgroundColor: Color(0xff053F5E),
        centerTitle: true,

      ),
      body: Container(
        child: Column(
          children: [
            Container(height: 300,
              width: 300,
              margin: EdgeInsets.only(top: 30, left: 45, right: 0),
              child: Image.asset("assets/doctorIcon.png"),
              decoration: BoxDecoration(

                  color: Colors.grey[100],
                  borderRadius: BorderRadius.only(
                      bottomLeft: Radius.circular(250), bottomRight: Radius.circular(250),
                      topRight: Radius.circular(250), topLeft: Radius.circular(250))),),

            Container(
              margin: EdgeInsets.only(top: 50, left: 45),
              child: Text(
                "Merhaba,",
                style: TextStyle(
                  color: Colors.white,
                  fontSize: 25,
                  fontFamily: 'Roboto',
                ),
              ),

            ),
             Container(
               margin: EdgeInsets.only(top: 10, left: 45),
               child: Text(
                 "Asma Abdoulkarim Omar",
                 style: TextStyle(
                   color: Colors.white,
                   fontSize: 25,
                   fontFamily: 'Roboto',
                 ),
               ),
             ),
             Container(
               width: 200,
              height: 54,
              margin: EdgeInsets.only(top: 50, left: 45),
              child: ElevatedButton(

                  onPressed: () {
                    Navigator.push(context, MaterialPageRoute(builder: (context) => HomePage()));
                  },

                child: Text('Giris'),

              ),
            ),




          ],
        ),
      ),
    );
  }
}
