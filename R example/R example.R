check_integer <- function(){
  tryCatch(
    expr = {
      x <- as.integer(readline(prompt = "X'in degerini giriniz: "))
      print("g(f(x)) fonksiyonunun sonucu: ")
      print(g_function(x))
    },
    error = function(e){
      message("Hatayla karsilasildi")
    },
    warning = function(w){
      message("Sayisal olmayan bir deger girildi")
      check_integer()
    }
  )
}




f_function <- function(x){
  x = x+5
  sqrt(x)
  
}
g_function <- function(x) {
  (f_function(x)*f_function(x)-3*f_function(x)+5)
}

check_integer()
