import java.util.ArrayList;

public class CustomerInfo {
    String ad;
    String soyad;
    String adres;
    String telefonNo;
    ArrayList<String> telefonNumaralari = new ArrayList<>();
    CustomerInfo(){

    }
    CustomerInfo(String ad, String soyad, String adres, String telefonNo){
        this.ad = ad;
        this.soyad = soyad;
        this.adres = adres;
        this.telefonNo = telefonNo;

    }

    public String getAd() {
        return ad;
    }

    public void setAd(String ad) {
        this.ad = ad;
    }

    public String getSoyad() {
        return soyad;
    }

    public void setSoyad(String soyad) {
        this.soyad = soyad;
    }

    public String getAdres() {
        return adres;
    }

    public void setAdres(String adres) {
        this.adres = adres;
    }

    public String getTelefonNo() {
        return telefonNo;
    }

    public void setTelefonNo(String telefonNo) {
        this.telefonNo = telefonNo;
    }

    public void setTelefonNumaralari(ArrayList<String> telefonNumaralari){
        this.telefonNumaralari = telefonNumaralari;
    }
    public ArrayList<String> getTelefonNumaralari(){
        return telefonNumaralari;
    }

    @Override
    public String toString(){
        return "Ad: " + ad + " Soyad: " + soyad + " Adres: " + adres + " Telefon Numarasi: " + telefonNumaralari;
    }
}
