import java.io.*;
import java.lang.reflect.Array;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.sql.SQLOutput;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Scanner;


class Node{
        CustomerInfo data;
        Node prev;
        Node next;
        public Node(CustomerInfo customer){
            this.data = customer;
        }
    }

class A{
    static Node head, tail = null;

    static void addNode(CustomerInfo customer) {
        Node newNode = new Node(customer);
        if(head == null){
            head = tail = newNode;
            head.prev = null;
            tail.next = null;
        }
        else{
            tail.next = newNode;
            newNode.prev = tail;
            tail = newNode;
            tail.next = null;
        }
        System.out.println("Calisan listeye eklendi");
    }
    //Kayitlari soyadlarin ilk harfine gore artan alfabetik sirayla siralayan method
    public static void sortAlphabetical(){
        Node current = null, index = null;
        CustomerInfo temp;
        if(head == null){
            return;
        }
        else{
            //ic ice for dongusu, butun kayitlari karsilastiracagimiz icin var
            for(current = head; current.next != null; current = current.next){
                for(index = current.next; index != null; index = index.next){
                    //iki kaydin soyadlarinin bas harflerinin karsilastirilmasi
                    if(String.valueOf(index.data.soyad.charAt(0)).compareTo(String.valueOf(current.data.soyad.charAt(0))) <= 0){
                        temp = current.data;
                        current.data = index.data;
                        index.data = temp;
                    }
                }
            }
        }
    }
    //Kayitlari soyadlarin ilk harfine gore azalan alfabetik sirayla siralayan method
    public static void sortUnAlphabetical(){
        Node current = null, index = null;
        CustomerInfo temp;
        if(head == null){
            return;
        }
        else{
            //ic ice for dongusu, butun kayitlari karsilastiracagimiz icin var
            for(current = head; current.next != null; current = current.next){
                for(index = current.next; index != null; index = index.next){
                    //iki kaydin soyadlarinin bas harflerinin karsilastirilmasi
                    if(String.valueOf(index.data.soyad.charAt(0)).compareTo(String.valueOf(current.data.soyad.charAt(0))) >= 0){
                        temp = current.data;
                        current.data = index.data;
                        index.data = temp;
                    }
                }
            }
        }
    }
    public static void display() {
        //current Node'u head'i gosteriyor.
        Node current = head;
        if(head == null) {
            System.out.println("List is empty");
            return;
        }
        while(current != null) {

            System.out.print(current.data + " \n");
            current = current.next;
        }
        System.out.println();
    }
    public static void searchNode(String ad, String soyad){
        int i = 1;
        boolean flag = false;
        Node current = head;

        if(head == null){
            System.out.println("Liste bos");
            return;
        }

        while(current != null){
            if(current.data.getAd().equals(ad) && current.data.getSoyad().equals(soyad)) {
                flag = true;
                break;
            }
            current = current.next;
            i++;
        }
        if(flag){
            System.out.println("Aradiginiz musteri listede bulunmaktadir");
            System.out.println("Ad: " + current.data.ad + " Soyad: " + current.data.soyad + " Adres: " + current.data.adres + " Telefon No: " + current.data.telefonNumaralari);
        }
        else{

            System.out.println("Aradiginiz musteri listede bulunmamaktadir");
        }

    }
    public static void deleteNode(Node del){

        if(head == null || del == null){
            return;
        }
        if(head == del){
            head = del.next;
        }
        if(del.next != null){
            del.next.prev = del.prev;
        }
        if(del.prev != null){
            del.prev.next = del.next;
        }

        return;

    }
    public static Node findDeletedNode(String ad, String soyad){
        int i = 1;
        boolean flag = false;
        Node current = head;

        if(head == null){
            System.out.println("Liste bos");
            return null;
        }
        while(current != null){
            if(current.data.getAd().equals(ad)){
                if(current.data.getSoyad().equals(soyad)) {
                    flag = true;
                    break;
                }
            }

            current = current.next;
            i++;
        }
        if(flag){
            System.out.println("Silmek istediginiz musteri listede bulunmaktadir");
            System.out.println("Ad: " + current.data.ad + " Soyad: " + current.data.soyad + " Adres: " + current.data.adres + " Telefon No: " + current.data.telefonNumaralari);
        }
        else{

            System.out.println("Silmek istediginiz musteri listede bulunmamaktadir");
        }

        return current;
    }
    public static void main(String[] args) throws IOException {
        CustomerInfo[] customers = new CustomerInfo[6];
        for(int i = 0; i < 6; i++){
            customers[i] = new CustomerInfo();
        }
        String path = "customer.txt";
        String data = null;
        String[] veriler = new String[6];





        File file = new File(path);
        Scanner reader = new Scanner(file);
        int i = 0;
        int customer_sayisi = 0;

        while(reader.hasNextLine() && i < 6){
            data = reader.nextLine();
            String[] numara = data.split(",");
            veriler[i] = data;
            i++;
        }


        String[] name = new String[2];
        String[] a = new String[5];

        for(String veri: veriler){
            String[] kelimeler = veri.split(",");
            int arrLength = kelimeler.length;



            a = veriler[customer_sayisi].split(",");
            int index = 0;

            index++;




            ArrayList<String> telefonNo = new ArrayList<>();
            name = kelimeler[0].split(" ");

            customers[customer_sayisi].setAd(name[0]);
            customers[customer_sayisi].setSoyad(name[name.length-1]);
            customers[customer_sayisi].setAdres(kelimeler[1]);
            for(int c = 0; c < arrLength; c++){
                if(kelimeler[c].startsWith("0")){
                    telefonNo.add(kelimeler[c]);

                }
            }
            customers[customer_sayisi].setTelefonNumaralari(telefonNo);
            customer_sayisi++;


        }




        head = tail = null;

        //MENU
        boolean exit = true;
        Scanner sc = new Scanner(System.in);

        while(exit){
            System.out.println("Menuye hosgeldiniz\n" +
                    "1- Text dosyasindaki verileri listeye ekle\n" +
                    "2- Klavyeden listeye veri ekle(Isim,Soyisim,Adres,Telefon No)\n" +
                    "3- Klavyeden adi ve soyadi girilen bir musterinin bilgilerini yazdir\n" +
                    "4- Adi ve soyadi girilen musteriyi listeden sil\n" +
                    "5- Listenin içindeki tüm kayıtlar artan alfabetik sırada (A’dan Z’ye) ekrana yazdır\n" +
                    "6- Listenin içindeki tüm kayıtlar azalan sırada (Z’den A’ya) ekrana yazdır\n" +
                    "7- CIKIS");
            int index = sc.nextInt();
            switch (index){
                case 1:
                    for( i = 0; i < 6; i++){
                        addNode(customers[i]);
                    }
                    break;
                case 2:
                    System.out.println("Listeye veri eklemek icin duzgun bir sirayla musterinin bilgilerini giriniz(Isim,Soyisim,Adres,Telefon No)");
                    System.out.println("Ad: ");
                    String ad = sc.next();
                    System.out.println("Soyad: ");
                    String soyad = sc.next();
                    System.out.println("Adres: ");
                    String adres = sc.next();
                    System.out.println("Telefon No: ");
                    String telefonNo = sc.next();

                    CustomerInfo customer = new CustomerInfo();
                    customer.setAd(ad);
                    customer.setSoyad(soyad);
                    customer.setAdres(adres);
                    customer.telefonNumaralari.add(telefonNo);
                    System.out.println(customer.telefonNumaralari);
                    addNode(customer);
                    break;
                case 3:
                    System.out.println("Aramak istediginiz musterinin adi ve soyadini giriniz:");
                    System.out.println("Adi: ");
                    String add = sc.next();
                    System.out.println("Soyadi: ");
                    String soyadd = sc.next();
                    searchNode(add,soyadd);
                    break;
                case 4:
                    System.out.println("Silinecek musterinin Adi ve Soyadini giriniz");
                    System.out.println("Ad: ");
                    String isim = sc.next();
                    System.out.println("Soyad: ");
                    String soyisim = sc.next();

                    deleteNode(findDeletedNode(isim,soyisim));
                    break;
                case 5:
                    System.out.println("Tum kayitlarin ARTAN alfabetik sirasi: ");
                    sortAlphabetical();
                    display();
                    break;
                case 6:
                    System.out.println("\nTum kayitlarin AZALAN alfabetik sirasi: ");
                    sortUnAlphabetical();
                    display();
                    break;
                case 7:
                    exit = false;
                    break;
            }

        }

//        System.out.println("======================================");
//
//
//        //Z-A display
//
//
//        //A-Z display
//
//
//        //serach if a node with given name and surname exists
//        System.out.println("Aranan veri: \n Isim: Ali Soyisim: Davarci");
//        System.out.println("======================================");
//
//
//        deleteNode(findDeletedNode("Ahmet","Demir"));
//        System.out.println("======================================");
//        System.out.println("Yeni listenin gorunumu: ");
//        display();
//        deleteNode(findDeletedNode("Veli","Tuz"));
//        System.out.println("======================================");
//        System.out.println("Yeni listenin gorunumu: ");
//        display();

    }
}


