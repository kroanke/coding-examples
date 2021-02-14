ogrenci <- c("Ahmet", "Veli", "Ayse", "Merve", "Osman")
notlar <- c(66,50, 20,60, 80,90, 100,100, 50,40)
donem_sonu_notlari <- c()
donem_sonu_harf_notlari <- c()
not_frekans <- c(0,  0,  0,  0,  0,  0,  0,  0)
yuzdelik_frekans <- c(0,  0,  0,  0,  0,  0,  0,  0)

mat<-matrix(list(), nrow=5, ncol=5)
mat[[1,1]] <- c(ogrenci[1])
mat[[2,1]] <- c(ogrenci[2])
mat[[3,1]] <- c(ogrenci[3])
mat[[4,1]] <- c(ogrenci[4])
mat[[5,1]] <- c(ogrenci[5])
#ahmet
mat[[1,2]] <- c(notlar[1])
mat[[1,3]] <- c(notlar[2])
#veli
mat[[2,2]] <- c(notlar[3])
mat[[2,3]] <- c(notlar[4])
#ayse
mat[[3,2]] <- c(notlar[5])
mat[[3,3]] <- c(notlar[6])
#merve
mat[[4,2]] <- c(notlar[7])
mat[[4,3]] <- c(notlar[8])
#osman
mat[[5,2]] <- c(notlar[9])
mat[[5,3]] <- c(notlar[10])



not_hesapla <- function(x,y){
  son_not = x * 40/100 + y * 60/100
  round(son_not)
}

for(i in seq(1,10,2))
  donem_sonu_notlari <- append(donem_sonu_notlari,not_hesapla(notlar[i], notlar[i+1]))
  
harf_notu <- function(donem_sonu_notlari){
  if(donem_sonu_notlari >= 90 && donem_sonu_notlari <= 100){
    a = "AA"
  }
  else if(donem_sonu_notlari >= 82 && donem_sonu_notlari <= 89){
    a = "BA"
  }
  else if(donem_sonu_notlari >= 73 && donem_sonu_notlari <= 81){
    a = "BB"
  }
  else if(donem_sonu_notlari >= 65 && donem_sonu_notlari <= 72){
    a = "CB"
  }
  else if(donem_sonu_notlari >= 57 && donem_sonu_notlari <= 64){
    a = "CC"
  }
  else if(donem_sonu_notlari >= 48 && donem_sonu_notlari <= 56){
    a = "DC"
  }
  else if(donem_sonu_notlari >= 40 && donem_sonu_notlari <= 47){
    a = "DD"
  }
  else if(donem_sonu_notlari >= 0 && donem_sonu_notlari <= 39){
    a = "FF"
  }
}
for(i in 1:5)
  donem_sonu_harf_notlari <- append(donem_sonu_harf_notlari,harf_notu(donem_sonu_notlari[i]))
  
#ahmet son not
mat[[1,4]] <- c(donem_sonu_notlari[1])
#veli son not
mat[[2,4]] <- c(donem_sonu_notlari[2])
#ayse son not
mat[[3,4]] <- c(donem_sonu_notlari[3])
#merve son not
mat[[4,4]] <- c(donem_sonu_notlari[4])
#osman son not
mat[[5,4]] <- c(donem_sonu_notlari[5])

#ahmet harf notu
mat[[1,5]] <- c(donem_sonu_harf_notlari[1])
#veli harf notu
mat[[2,5]] <- c(donem_sonu_harf_notlari[2])
#ayse harf notu
mat[[3,5]] <- c(donem_sonu_harf_notlari[3])
#merve harf notu
mat[[4,5]] <- c(donem_sonu_harf_notlari[4])
#osman harf notu
mat[[5,5]] <- c(donem_sonu_harf_notlari[5])

for (i in 1:5)
  if(donem_sonu_harf_notlari[i] == "AA"){
    not_frekans[1] = not_frekans[1] + 1
  }else if(donem_sonu_harf_notlari[i] == "BA"){
    not_frekans[2] = not_frekans[2] + 1
  }else if(donem_sonu_harf_notlari[i] == "BB"){
    not_frekans[3] = not_frekans[3] + 1
  }else if(donem_sonu_harf_notlari[i] == "CB"){
    not_frekans[4] = not_frekans[4] + 1
  }else if(donem_sonu_harf_notlari[i] == "CC"){
  not_frekans[5] = not_frekans[5] + 1
  }else if(donem_sonu_harf_notlari[i] == "DC"){
    not_frekans[6] = not_frekans[6] + 1
  }else if(donem_sonu_harf_notlari[i] == "DD"){
    not_frekans[7] = not_frekans[7] + 1
  }else if(donem_sonu_harf_notlari[i] == "FF"){
    not_frekans[8] = not_frekans[8] + 1
  }
#harf notlari frekanslari
print("AA BA BB CB CC DC DD FF")
print(not_frekans)

for (i in 1:8)
  yuzdelik_frekans[i] = not_frekans[i] * 20
print("Harf notlarinin yuzdeleri ")
print(yuzdelik_frekans)

#butun tablo sirasiyla, isim, vize notu, final notu, donem sonu notu, donem sonu harfi
print(mat)


