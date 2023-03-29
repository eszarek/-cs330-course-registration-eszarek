using System;
using System.Collections.Generic;

namespace cs330_proj1
{
    public interface ICourseRepository{
        public List<Course> Courses {get;set;}
        public List<CoreGoal> Goals {get;set;}
        public List<CourseOffering> Offerings {get;set;}
    }
    public class CourseRepository: ICourseRepository {
        public List<Course> Courses {get;set;}
        public List<CoreGoal> Goals {get;set;}
        public List<CourseOffering> Offerings {get;set;}

        //Add more data as needed 
        public CourseRepository() {
            Courses = new List<Course>();
            Goals=new List<CoreGoal>();
            Offerings=new List<CourseOffering>();

            Course c1 = new Course() {
                Name="ARTD 201",
                Title="graphic design",
                Credits=3.0,
                Description="graphic design descr",
                Department="Design"

            };
            Course c2 = new Course() {
                Name="ARTS 101",
                Title="art studio",
                Credits=3.0,
                Description="studio descr",
                Department="Design"

            };
            Course c3 = new Course() {
                Name="STAT 201",
                Title="stats",
                Credits=4.0,
                Description="stats descr",
                Department="CSCI"

            };
            Course c4 = new Course() {
                Name="ENGL 302",
                Title="Math as a Communication language",
                Credits=4.0,
                Description="communication descr",
                Department="CSCI"

            };
            Courses.Add(c1);
            Courses.Add(c2);
            Courses.Add(c3);
            Courses.Add(c4);
            CourseOffering co1 = new CourseOffering() {
                TheCourse=c1,
                Section="D1",
                Semester="Spring 2021",
                Department=c1.Department


            };
            CourseOffering co2 = new CourseOffering() {
                TheCourse=c3,
                Section="01",
                Semester="Spring 2021",
                Department=c2.Department

            };
            CourseOffering co3 = new CourseOffering() {
                TheCourse=c2,
                Section="01",
                Semester="Spring 2022",
                Department=c2.Department


            };
            CourseOffering co4 = new CourseOffering() {
                TheCourse=c4,
                Section="01",
                Semester="Fall 2020",
                Department=c4.Department
            };
            CourseOffering co5 = new CourseOffering() {
                TheCourse=c4,
                Section="D1",
                Semester="Fall 2020",
                Department=c4.Department
            };
            Offerings.Add(co1);
            Offerings.Add(co2);
            Offerings.Add(co3);
            Offerings.Add(co4);
            Offerings.Add(co5);
            CoreGoal cg1 = new CoreGoal() {
                Id="CG1",
                Name="Artistic Expression",
                Description="Desc for artistic expression",
                Courses = new List<Course>() {
                    c1,c2
                }

            };
            CoreGoal cg2 = new CoreGoal() {
                Id="CG2",
                Name="Quantitative Literacy",
                Description="Desc for quantitative literacy",
                Courses = new List<Course>() {
                    c2,c3
                }

            };
            CoreGoal cg3 = new CoreGoal() {
                Id="CG3",
                Name="Effective Communication",
                Description="Desc for communication",
                Courses = new List<Course>() {
                    c4,c3
                }

            };
            Goals.Add(cg1);
            Goals.Add(cg2);
            Goals.Add(cg3);
        }//end constructor


        public List<CourseOffering> getOfferingsByGoalIdAndSemester(String theGoalId, String semester) {
            CoreGoal theGoal=null;
            foreach(CoreGoal cg in Goals) {
                if(cg.Id.Equals(theGoalId)) {
                    theGoal=cg; break;

                }
            }
            if(theGoal==null) throw new Exception("Didn't find the goal");
            //search list of courses, then for each course, search offerings
            List<CourseOffering> courseOfferingsThatMeetGoal = new List<CourseOffering>();
            
            foreach(CourseOffering c in Offerings) {
                if(c.Semester.Equals(semester) 
                    && theGoal.Courses.Contains(c.TheCourse) ) 
                    {courseOfferingsThatMeetGoal.Add(c);}



            }//end for
            return courseOfferingsThatMeetGoal;
        }



    }
    
}
