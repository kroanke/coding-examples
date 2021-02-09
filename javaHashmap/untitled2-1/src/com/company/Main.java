package com.company;

import java.util.Scanner;

public class Main {



    public static void main(String[] args) {
	// write your code here

        Grade_Calculate gradeCalculate = new Grade_Calculate() {
            @Override
            public int grade_calculator(int mid1weight, int mid1point, int mid2weight, int mid2point, int finalweight, int finalpoint) {
                int finalresult = ((mid1point * mid1weight) + (mid2point * mid2weight) + (finalpoint * finalweight))/100;

                return finalresult;
            }
        };

        //System.out.println(gradeCalculate.grade_calculator(20,60,20,60,60, 70));


        University university = new University();

        Student osman = new Student("osman","gultekin",22, "erkek", "abc", "cs", 2021);

        ClassExample osman101 = new ClassExample("cs101", "finished", 48,50,90);
        ClassExample osman201 = new ClassExample("cs201", "finished", 60,60,60);

        osman.getCourse_list().courses.add(osman101);
        osman.getCourse_list().courses.add(osman201);

        university.students.put("osman", osman);

        int x = gradeCalculate.grade_calculator(20,osman101.getMid1(),20,osman101.getMid2(),60,osman101.getFinalscore());
        calculateGrade(osman101, x);
        ;
        //osman101.calculateGrade();
        int y = gradeCalculate.grade_calculator(20,osman201.getMid1(),20,osman201.getMid2(),60,osman201.getFinalscore());
        calculateGrade(osman201, y);

        Student aykut = new Student("aykut","elmas",22, "erkek", "abc", "cs", 2022);

        ClassExample aykut101 = new ClassExample("cs201", "finished", 60,60,60);
        ClassExample aykut201 = new ClassExample("cs301", "finished", 70,70,70);

        aykut.getCourse_list().courses.add(aykut101);
        aykut.getCourse_list().courses.add(aykut201);

        university.students.put("aykut", aykut);

        int a = gradeCalculate.grade_calculator(20,aykut101.getMid1(),20,aykut101.getMid2(),60,aykut101.getFinalscore());
        calculateGrade(aykut101, a);
        int b =gradeCalculate.grade_calculator(25,aykut201.getMid1(),25,aykut201.getMid2(),50,aykut201.getFinalscore());
        calculateGrade(aykut201, b);


        Student cagri = new Student("cagri","han",4, "erkek", "abc", "cs", 2022);

        ClassExample cagri101 = new ClassExample("cs101", "finished", 90,90,90);
        ClassExample cagri201 = new ClassExample("cs201", "finished", 45,75,90);
        ClassExample cagri301 = new ClassExample("cs301", "finished", 40,80,90);

        cagri.getCourse_list().courses.add(cagri101);
        cagri.getCourse_list().courses.add(cagri201);
        cagri.getCourse_list().courses.add(cagri301);



        university.students.put("cagri", cagri);

        int o = gradeCalculate.grade_calculator(25,cagri101.getMid1(),25,cagri101.getMid2(),50,cagri101.getFinalscore());
        calculateGrade(cagri101, o);
        int u = gradeCalculate.grade_calculator(25,cagri201.getMid1(),25,cagri201.getMid2(),50,cagri201.getFinalscore());
        calculateGrade(cagri201, u);
        int i = gradeCalculate.grade_calculator(25,cagri301.getMid1(),25,cagri301.getMid2(),50,cagri301.getFinalscore());
        calculateGrade(cagri301, i);



        Scanner scan = new Scanner(System.in);
        System.out.print("Student name: ");
        String studentName = scan.next();
        System.out.println(university.students.get(studentName));




    }
    public static void calculateGrade(ClassExample e, int x){
        if(x > 60){
            e.setGrade("passed");
//                System.out.println("Mid1 point:" + mid1point);
//                System.out.println("Mid2 point:" + mid2point);
//                System.out.println("Final point:" + finalpoint);
//                System.out.println("Final result:" + finalresult);


        }
        else{
            e.setGrade("failed");
//                System.out.println("Mid1 point: " + mid1point);
//                System.out.println("Mid2 point: " + mid2point);
//                System.out.println("Final point: " + finalresult);
//                System.out.println("Final result:" + finalresult);

        }
    }
}
