package javaapplication12;
import java.awt.*;  
import java.awt.event.*;  
import javax.swing.*;

class JavaApplication12 extends JFrame implements ActionListener  
{  
    // TODO yorum satirlari ekle
    // TODO telegramda cocugun attigi konuya gore sorulari duzenle
    
    JLabel label, label1;  
    int numberOfQuestions = 5;
    JRadioButton jb[]=new JRadioButton[numberOfQuestions];  
    JButton button1, button2;
    JButton button3, button4;
    ButtonGroup bg;  
    int correct = 0;
    int wrong = 0;
    int blank = 0;
    int current = 0;
    JavaApplication12(String s)  
    {  
        super(s);  
        label=new JLabel();  
        label1 = new JLabel();
        add(label);  
        bg=new ButtonGroup();  
        for(int i=0;i<5;i++)  
        {  
            jb[i]=new JRadioButton();     
            add(jb[i]);  
            bg.add(jb[i]);  
        }  
        button1 = new JButton("Diger Soru");  
        button2 = new JButton();
        button3 = new JButton("Sinava yeniden basla");
        button4 = new JButton("Cikis");
        button1.addActionListener(this);  
        button2.addActionListener(this);  
        button3.addActionListener(this);
        button4.addActionListener(this);
        add(button1);
        questions();  
        label.setBounds(30,40,450,20);
        label1.setBounds(70,40,450,60);
        jb[0].setBounds(50,80,300,20);  
        jb[1].setBounds(50,110,300,20);  
        jb[2].setBounds(50,140,300,20);  
        jb[3].setBounds(50,170,300,20);  
        button1.setBounds(300,240,100,30);  
        button2.setBounds(270,240,100,30); 
        button3.setBounds(50,240,200,30);
        button4.setBounds(370,240,100,30);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);  
        setLayout(null);
        setLocation(250,100);  
        setVisible(true);  
        setSize(500,350);
    }  
    public void actionPerformed(ActionEvent e)  
    {  
        if(e.getSource() == button1)  
        {  
            if(check() == 1)  
                correct++;
            if(check() == 0){
                wrong++;
            }
            current++;
            questions();    
            if(current==4)  
            {
                add(button4);
                button4.addActionListener(new ActionListener(){
                    @Override
                    public void actionPerformed(ActionEvent e) {
                        System.exit(0);
                    }
                });
                add(button3);
                button3.addActionListener(new ActionListener(){
                    @Override
                    public void actionPerformed(ActionEvent e) {
                        dispose();
                        new JavaApplication12("Sinav Uygulamasi");
                    }
                });
                add(button2);
                button1.setVisible(false);  
                button2.setText("Result");  
            }  
        }  
        if(e.getActionCommand().equals("Result"))  
        {  
            if(check() == 1)  
                correct++;
            if(check() == 0){
                wrong++;
            } 
            current++;
            button3 = new JButton("AAAA");
            add(button3);
            blank = numberOfQuestions - (correct + wrong);
            JOptionPane.showMessageDialog(this,"Dogru cevap sayisi = " + correct + "\nYanlis cevap sayisi = " + wrong +
                    "\nBos cevap sayisi = " + blank);  
 
        }  
    }  
    void questions()  
    {  
        jb[4].setSelected(true);  
        if(current == 0)  
        {  
            label.setText("Soru1: Asagidakilerden hangisi Constructor turlerindendir?");  
            jb[0].setText("Default Constructor");//CEVAP BU
            jb[1].setText("Abstract Constructor");
            jb[2].setText("Protected Class");
            jb[3].setText("Synchronized");   
        }  
        if(current == 1)  
        {  
            label.setText("Soru2: Java'da Interface icerisinde Constructor kullanilabilir mi?");  
            jb[0].setText("Hayir");//CEVAP BU
            jb[1].setText("Evet");
            jb[2].setVisible(false);
            jb[3].setVisible(false);

        }  
        if(current == 2)  
        {  
            label.setText("Soru3: ...., bir nesne başlatıldığında çağrılan özel yöntemdir");  
            add(label1);
            label1.setText("Bos birakilan yere asagidakilerden hangisi gelebilir?");
            jb[0].setText("Constructor");//CEVAP BU
            jb[1].setText("Interface");
            jb[2].setText("Class");
            jb[3].setText("Degisken");  
        }  
        if(current == 3)  
        {  
            jb[2].setVisible(true);
            jb[3].setVisible(true);
            remove(label1);
            label.setText("Soru4: Argumansiz Constructor'a ... denir.");  
            jb[0].setText("No-arg Constructor");//CEVAP BU
            jb[1].setText("Swing");
            jb[2].setText("boolean");
            jb[3].setText("Constructor");  
        }  
        if(current == 4)  
        {  
            label.setText("Soru5: Constructor'lari final olarak tanimlayabilir miyiz?");  
            jb[0].setText("Hayir");//CEVAP BU
            jb[1].setText("Evet");
            jb[2].setVisible(false);
            jb[3].setVisible(false);
        }  
        
        
        label.setBounds(30,40,450,20);  
        for(int i=0,j=0;i<=40;i+=30,j++)  
            jb[j].setBounds(50,80+i,200,20);  
    }  
    int check()  
    {

        //dogru cevaplar

        if(current==0){
            if(jb[0].isSelected()){
                return 1;
            }else if(jb[1].isSelected() || jb[2].isSelected() || jb[3].isSelected()){
                return 0;
            }
            
        }
        if(current==1)  
            if(jb[0].isSelected()){
                return 1;
            }else if(jb[1].isSelected()){
                return 0;
            } 
        if(current==2)  
            if(jb[0].isSelected()){
                return 1;
            }else if(jb[1].isSelected() || jb[2].isSelected() || jb[3].isSelected()){
                return 0;
            }
        if(current==3)  
            if(jb[0].isSelected()){
                return 1;
            }else if(jb[1].isSelected() || jb[2].isSelected() || jb[3].isSelected()){
                return 0;
            }  
        if(current==4)  
            if(jb[0].isSelected()){
                return 1;
            }else if(jb[1].isSelected()){
                return 0;
            }  
        return 2;  
    }  
    public static void main(String s[])  
    {  
        new JavaApplication12("Sinav Uygulamasi");  
    }  
}  
