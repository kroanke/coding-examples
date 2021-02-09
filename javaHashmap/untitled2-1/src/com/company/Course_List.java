package com.company;

import java.util.ArrayList;
import java.util.List;

public class Course_List {

    public List<ClassExample> courses;

    public Course_List() {
        this.courses = new ArrayList<ClassExample>();
    }

    public List<ClassExample> getCourses() {
        return courses;
    }

    @Override
    public String toString(){
        String x = "";
        for(int i = 0; i<this.courses.size(); i++){
            String courseName = this.courses.get(i).getName();
            String courseGrade = this.courses.get(i).getGrade();
            String courseStatus = this.courses.get(i).getStatus();

            x += ("\nCourse Name: " + courseName
                    + "\nCourse Grade: " + courseGrade
                    + "\nCourse Status: " + courseStatus);
        }
        return x;
    }


}
