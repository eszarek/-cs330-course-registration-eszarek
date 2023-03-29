using System;
using System.Collections.Generic;

namespace cs330_proj1
{
    public class CourseServices
    {
       // private CourseRepository repo = new CourseRepository();
        private readonly ICourseRepository _repo;

        public CourseServices(ICourseRepository courseRepo) {
         _repo=courseRepo;
        }

       public List<CourseOffering> GetOfferingsByGoalIdAndSemester(String theGoalId, String semester) {
          //finish this method during the tutorial 
         List<CoreGoal> theGoals = _repo.Goals;
         List <CourseOffering> theOfferings = _repo.Offerings;
         CoreGoal theGoal=null;
         foreach (CoreGoal cg in theGoals) {
            if(cg.Id.Equals(theGoalId)){
               theGoal=cg;
               break;
            }
            if (theGoal==null) throw new Exception ("Didn't find the goal");}
      
       //search list of courses, then for each course, search offerings
      List<CourseOffering> courseOfferingsThatMeetGoal = new List<CourseOffering>();
                  
      foreach(CourseOffering c in theOfferings) {
         if(c.Semester.Equals(semester) 
            && theGoal.Courses.Contains(c.TheCourse) ) 
         {
            courseOfferingsThatMeetGoal.Add(c);
         }
      
      }
      return courseOfferingsThatMeetGoal;}

        
        //Add more service functions here, as needed, for the project

        /* As a student, I want to see all available courses so that I know what my options are  */
      public List<Course> GetCourses () {
         List<Course> allCourses = _repo.Courses;
         return allCourses;
        }
           
          

        /* As a student, I want to see all course offerings by semester, so that I can choose from what's
           available to register for next semester */
         public List<CourseOffering> GetCourseOfferingsBySemester(string semester){
            List<CourseOffering> theOfferings = _repo.Offerings;
          
            List<CourseOffering> semesterOffering = new List<CourseOffering>();
                        
            foreach(CourseOffering c in theOfferings) {
               if(c.Semester.Equals(semester)) {
                  semesterOffering.Add(c);
               }
            }
            return semesterOffering;}
         
         /*As a student I want to see all course offerings by semester and department so that I can 
        choose major courses to register for */
         public List<CourseOffering> GetCourseOfferingsBySemesterAndDept(string semester, string department){
            List<CourseOffering> theOfferings = _repo.Offerings;
          
            List<CourseOffering> semesterAndDeptOffering = new List<CourseOffering>();
            List<CourseOffering> semesterOnly = new List<CourseOffering>();       
            foreach(CourseOffering a in theOfferings) {
               if(a.Semester.Equals(semester)){
                     semesterOnly.Add(a);}
               }
            foreach(CourseOffering b in semesterOnly){
               if(b.Department.Equals(department)){
                  semesterAndDeptOffering.Add(b);}
            }
            return semesterAndDeptOffering;
            }
        /* As a student I want to see all courses that meet a core goal, so that I can plan out
           my courses over the next few semesters and choose core courses that make sense for me */

        /* As a student I want to find a course that meets two different core goals, so that I can
        "feed two birds with one seed" (save time by taking one class that will fulfill two 
          requirements */

        /* As a freshman adviser, I want to see all the core goals which do not have any course offerings 
           for a given semester, so that I can work with departments to get some courses offered
           that students can take to meet those goals */
    }
}