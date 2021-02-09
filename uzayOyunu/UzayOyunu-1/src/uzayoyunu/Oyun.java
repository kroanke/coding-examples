/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package uzayoyunu;

import java.awt.Color;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.Rectangle;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;
import java.lang.System.Logger.Level;
import java.util.ArrayList;
import java.util.logging.Logger;
import javax.imageio.ImageIO;
import javax.imageio.stream.FileImageInputStream;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.Timer;

/**
 *
 * @author kroanke
 */

class Mermi{
    
    private int x;
    private int y;

    public Mermi(int x, int y) {
        this.x = x;
        this.y = y;
    }

    public int getX() {
        return x;
    }

    public void setX(int x) {
        this.x = x;
    }

    public int getY() {
        return y;
    }

    public void setY(int y) {
        this.y = y;
    }
    
    
}
public class Oyun extends JPanel implements KeyListener,ActionListener{
       
    Timer zamanlayici = new Timer(5, this);
    
    private int sure = 0;
    private int kullanilan_mermi = 0;
    private int sarjor = 20;
    private int kalan_mermi = 20;
    
    private BufferedImage uzay_gemisi;
    private BufferedImage mermi_resim;
    private BufferedImage uzay;
    
    private ArrayList<Mermi> mermiler = new ArrayList<Mermi>();
    
    private int mermidirY = 7;  //merminin hizi
    private int topX = 0;       //topun baslangic noktasi
    
    private int topdirX =1;     //topun hareket etme hizi
    
    private int uzayGemisiX = 0; //uzay gemisinin baslangic noktasi
    
    private int dirUzayX = 30; //klavyeden yon tuslarina bastigimizda uzay gemisinin
                               //X koordinatinda
                               //ne kadar hareket edeceginin degeri
    
    private  long nextSecond = System.currentTimeMillis() + 1000;
    private  int framesInLastSecond = 0;
    private  int framesInCurrentSecond = 0;
    
    
    public boolean kontrol(){
        for(Mermi mermi: mermiler){
            if(new Rectangle(mermi.getX(), mermi.getY(), 5, 5).intersects(new Rectangle(topX, 0, 40, 40))){
                return true;
                
            }
        }
        return false;
    }
    
    
    public Oyun(){
        
        try {
            uzay_gemisi = ImageIO.read(new FileImageInputStream(new File("uzaygemisi1.png")));
            mermi_resim = ImageIO.read(new FileImageInputStream(new File("mermi1.png")));
            uzay = ImageIO.read(new FileImageInputStream(new File("space.png")));
            
        } catch (IOException ex) {
            Logger.getLogger(Oyun.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        
        

        
        setBackground(Color.WHITE);
        
        zamanlayici.start();
        
        
    }

    @Override
    protected void paintComponent(Graphics g) {
        super.paintComponent(g); //To change body of generated methods, choose Tools | Templates.

        g.drawImage(uzay, 0,0, null);
    }

    @Override
    public void paint(Graphics g) {
        super.paint(g); //To change body of generated methods, choose Tools | Templates.
        sure += 5;
        g.setColor(Color.RED);
        
        g.fillOval(topX, 10, 40, 40);
        
        g.drawImage(uzay_gemisi, uzayGemisiX, 490, uzay_gemisi.getWidth()/10, uzay_gemisi.getHeight()/10,this);
           for(Mermi mermi: mermiler){
               if(mermi.getY() < 0){
                   mermiler.remove(mermi);
               }
           }
           
//           g.setColor(Color.WHITE);
           
           for(Mermi mermi: mermiler){
               g.fillOval(mermi.getX(), mermi.getY(), 5, 5);
               g.drawImage(mermi_resim, mermi.getX()-23, mermi.getY()-20, mermi_resim.getWidth()/5, mermi_resim.getHeight()/5,this);

           }
           g.setColor(Color.WHITE);
           g.drawString("Kalan mermi: " + kalan_mermi,680, 560);
           long currentTime = System.currentTimeMillis();
           if(currentTime > nextSecond){
               nextSecond += 1000;
               framesInLastSecond = framesInCurrentSecond;
               framesInCurrentSecond = 0;
               
           }

           framesInCurrentSecond++;
           g.drawString("FPS: " + framesInLastSecond,720, 540);

           
           if(kontrol()){
               zamanlayici.stop();
               String message = "Oyunu Kazandin\n"+
                                "Harcanan Mermi: " + kullanilan_mermi +
                                "\nGecen Sure: " + sure / 1000.0 + " saniye";
               JOptionPane.showMessageDialog(this, message);
               
               
               System.exit(0);
           }
           
    }

    @Override
    public void repaint() {
        super.repaint(); //To change body of generated methods, choose Tools | Templates.
    }
    
    
    @Override
    public void keyTyped(KeyEvent e) {
        
        
    }

    @Override
    public void keyPressed(KeyEvent e) {
        
        int c = e.getKeyCode();
        
        if(c == KeyEvent.VK_LEFT){
            if(uzayGemisiX <= 0){
                uzayGemisiX = 0;
            }
            else{
                uzayGemisiX -= dirUzayX;
                
            }
        }
        else if(c == KeyEvent.VK_RIGHT){
            if(uzayGemisiX >= 750){
                uzayGemisiX = 750;
            }
            else{
                
                uzayGemisiX += dirUzayX;
            }
        }
        else if(c == KeyEvent.VK_UP){
            
            mermiler.add(new Mermi(uzayGemisiX+35,470));
            
            
            kullanilan_mermi++;
            kalan_mermi--; 
            if(kullanilan_mermi == sarjor){
                String message = sarjor + " mermiden 0 merminiz kaldi\n" + "Kaybettiniz!";
                JOptionPane.showMessageDialog(this, message);
                System.exit(0);
               } 
           
        }
        
    }

    @Override
    public void keyReleased(KeyEvent e) {
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        
        for(Mermi mermi: mermiler){
            mermi.setY(mermi.getY() - mermidirY);
        }
        
        
        
        topX += topdirX;
        
        if(topX >= 750){
            topdirX = -topdirX; //eger X koordinati 750yi gecerse
                                //topu, negatif hizla toplayip ters tarafa 
                                //gitmesini sagliyoruz.
        }
        if(topX <= 0){
            topdirX = -topdirX; //eger X koordinati 0'dan eksiye dogru gitmeye 
                                //calisirsa topu negatif hizla toplayip ters 
                                //tarafa gitmesini sagliyoruz.
        }
        
        repaint();
        
        
    }
    
}
