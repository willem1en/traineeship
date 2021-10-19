import java.time.LocalDate;
import java.util.ArrayList;

class Student {
    String name;
    int year;
    LocalDate startDate;
    ArrayList<Double> grades;

    Student(String name, int year, LocalDate startDate) {
        this.name = name;
        this.year = year;
        this.startDate = startDate;
        this.grades = new ArrayList<Double>();
    }

    void addGrade(double grade) {
        grades.add(grade);
    }

    double getAverageGrade() {
        double total = 0;
        for (double grade : grades) {
            total += grade;
        }
        return total/grades.size();
    }


}