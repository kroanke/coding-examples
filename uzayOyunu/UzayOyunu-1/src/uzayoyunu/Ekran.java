/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package uzayoyunu;

import java.awt.HeadlessException;
import javax.swing.JFrame;

/**
 *
 * @author kroanke
 */
public class Ekran extends JFrame {

    public Ekran(String title) throws HeadlessException {
        super(title);
    }

   
    
    public static void main(String[] args) {
        // TODO code application logic here
        Ekran oyun_ekrani = new Ekran("Uzay Savaş Oyunu");
        
        oyun_ekrani.setResizable(false);
        oyun_ekrani.setFocusable(false);
        
        oyun_ekrani.setSize(800,600);
        
        oyun_ekrani.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        
        Oyun oyun = new Oyun();
        
        oyun.requestFocus(); 
        
        oyun.addKeyListener(oyun);
        
        oyun.setFocusable(true);
        oyun.setFocusTraversalKeysEnabled(false); //Klavye islemleri icin 
        
        
        oyun_ekrani.add(oyun);
        
        oyun_ekrani.setVisible(true); //Jframe, Jpanel eklendiginde direkt olarak olusmasi icin
        
        
        
    }
    
}
