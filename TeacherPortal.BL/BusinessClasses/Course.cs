using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherPortal.UI.Models.Models;

namespace TeacherPortal.BL.BusinessClasses
{
    /// <summary>
    /// Business class to represent a course
    /// </summary>
    public class Course : BusinessBase
    {

        #region Field

        /// <summary>
        /// Field for the course repository 
        /// </summary>
        private readonly CourseRepository courseRepository; 
        
        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Course() :base()
        {
            courseRepository = new CourseRepository(StudentGradingContext);
        }

        #endregion

        #region Business Logic Methods

        /// <summary>
        /// Method to Add a course to the database
        /// </summary>
        /// <param name="course">The course to be added</param>
        /// <returns>true if the teacher was added</returns>
        public async Task<bool> AddCourseAsync(CourseModel course)
        {
            var added = true;


            try
            {
                var convertedCourse = CreateCourseEnitity(course);
                await Task.Run(() => courseRepository.Add(convertedCourse));
            }
            catch (Exception ex)
            {
                //TODO: add login
                added = false;
            }

            return added;
        }

        /// <summary>
        /// Method to find a teacher by the id 
        /// </summary>
        /// <param name="id">The teacher id for the teacher to find</param>
        /// <returns>A course if found. Null otherwise</returns>
        public async Task<CourseModel> FindCourseAsync(int id)
        {
            var course = new CourseModel();
            try
            {
                //find the teacher
                var foundCourse = await Task.Run(() => courseRepository.GetId(id));

                if (foundCourse != null)
                {
                    //add courseId if found
                    if (foundCourse.CourseId != 0)
                        course.CourseId = foundCourse.CourseId;

                    course.Name = foundCourse.Name;
                    course.Description = foundCourse.Description;
                }
            }
            catch (Exception ex)
            {

            }

            return course;
        }

        /// <summary>
        /// Method to delete a course
        /// </summary>
        /// <param name="courseId">The course to be deleted</param>
        /// <returns></returns>
        public async Task<bool> DeleteCourseAsync(int courseId)
        {
            var deleted = true;

            try
            {
                await Task.Run(() => courseRepository.DeleteCourse(courseId));
            }
            catch (Exception ex)
            {
                deleted = false;
            }

            return deleted;
        }

        /// <summary>
        /// Method to Update a course
        /// </summary>
        /// <param name="course">The course to update</param>
        /// <returns>True if the course was updated</returns>
        public async Task<bool> UpdateCourseAsync(CourseModel course)
        {
            var updated = true;

            try
            {
                var convertedCourse = CreateCourseEnitity(course);
                await Task.Run(() => courseRepository.Update(convertedCourse));
            }
            catch (Exception ex)
            {
                updated = false;
            }

            return updated;
        }

        /// <summary>
        /// Method to get all courses
        /// </summary>
        /// <returns>A list of all courses</returns>
        public async Task<List<CourseModel>> GetAllCourseAsync()
        {
            List<CourseModel> courseList = new List<CourseModel>();

            try
            {
                var allCourses = await Task.Run(() => courseRepository.GetAll());

                courseList = (from course in allCourses
                               select new CourseModel()
                               {
                                   CourseId = course.CourseId,
                                   Name = course.Name,
                                   Description = course.Description

                               }).ToList<CourseModel>();

            }

            catch (Exception ex)
            {

            }

            
            return courseList;
        }


        /// <summary>
        /// Method to enroll a student into the course
        /// </summary>
        /// <param name="studentId">The studentId of the student</param>
        /// <param name="courseId">The courseId of the student</param>
        /// <returns>True if the student was enrolled in the course</returns>
        public async Task<bool> EnrollStudentInCourseAysnc(int studentId,int courseId)
        {
            var added = false;
            try
            {
                 added = await Task.Run(() => courseRepository.EnrollStudentIntoCourse(studentId, courseId));
            }
            catch(Exception ex)
            {
                
            }

            return added;
        }

        /// <summary>
        /// Method to assign a teacher to a course
        /// </summary>
        /// <param name="teacherId">The teacher id</param>
        /// <param name="courseId">The course id</param>
        /// <returns>True if the teacher was assigned to the course</returns>
        public async Task<bool> AssignTeacherToCourseAsync(int teacherId,int courseId)
        {
            var added = false;
            
            try
            {
                added = await Task.Run(() => courseRepository.AssignTeacherToCourse(teacherId, courseId));
            }

            catch (Exception ex)
            {

            }

            return added;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Method to convert a course to an course entity
        /// </summary>
        /// <param name="course">The course to convert</param>
        /// <returns>A course entity object</returns>
        private Entities.Course CreateCourseEnitity(CourseModel course)
        {
            var convertedCourse = new Entities.Course();

            if (course != null)
            {
                //add if the courseId is not 0
                if (course.CourseId != 0)
                    convertedCourse.CourseId = course.CourseId;

                convertedCourse.Name = course.Name;
                convertedCourse.Description = course.Description;
            }
            return convertedCourse;
        }

        #endregion
    }
}
