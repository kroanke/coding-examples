package com.company;

import java.util.List;

public class MasterStudent extends Student{
    private String thesistopic;

    public String getThesistopic() {
        return thesistopic;
    }

    public void setThesistopic(String thesistopic) {
        this.thesistopic = thesistopic;
    }

    public MasterStudent(String name, String surname, Integer age, String gender, String university, String department, Integer year, int grade, String status, String thesistopic) {
        super(name, surname, age, gender, university, department, year);
        this.thesistopic = thesistopic;
    }
}
