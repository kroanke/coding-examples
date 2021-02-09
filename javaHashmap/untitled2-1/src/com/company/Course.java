package com.company;

public class Course {

    private String name;
    private String grade;
    private String status;
    public Grade_Calculate grade_calculator;




    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getGrade() {
        return grade;
    }

    public void setGrade(String grade) {
        this.grade = grade;
    }

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }



    public Course(String name, String status) {
        this.name = name;
        this.status = status;
    }
}
