package com.company;

public class ClassExample extends Course{

    private int mid1;
    private int mid2;
    private int finalscore;

    public ClassExample(String name, String status, int mid1, int mid2, int finalscore) {
        super(name, status);
        this.mid1 = mid1;
        this.mid2 = mid2;
        this.finalscore = finalscore;
    }

    public int getMid1() {
        return mid1;
    }

    public void setMid1(int mid1) {
        this.mid1 = mid1;
    }

    public int getMid2() {
        return mid2;
    }

    public void setMid2(int mid2) {
        this.mid2 = mid2;
    }

    public int getFinalscore() {
        return finalscore;
    }

    public void setFinalscore(int finalscore) {
        this.finalscore = finalscore;
    }


}
