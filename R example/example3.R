set.seed(2019165007)
u <- rnorm(1000)
mean_us <- function(n){
  res <-0
  for(i in 1:n){
    res <- res+u[i]
  }
  mean <- res/length(u)
  return(mean)
}
mean <- mean_us(length(u))

s_d <- function(x,n,mean){ 
  sum <-0
  for( i in 1:n){
    sum <- sum + (x[i]-mean)^2
  }
  sd2 <- sqrt(sum/(n-1))
  return(sd2)
}


var_1<- function(x,n,mean){ 
  sum <-0
  for( i in 1:n){
    sum <- sum + (x[i]-mean)^2
  }
  sd2 <- sqrt(sum/(n-1))
  varr <- sd2^2
  return(varr)
}

s_e <- function(x,n,mean){ 
  sum <-0
  for( i in 1:n){
    sum <- sum + (x[i]-mean)^2
  }
  sd2 <- sqrt(sum/(n-1))
  se <- sd2/sqrt(n)
  return(se)
}
print(paste("ortalama:",mean_us(length(u))))
print(paste("standart sapma:",s_d(u,length(u),mean)))
print(paste("varyans:",var_1(u,length(u),mean)))
print(paste("standart hata:",s_e(u,length(u),mean)))


