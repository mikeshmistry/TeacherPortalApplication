using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherPortal.UI.Models.Models;

namespace TeacherPortal.BL.BusinessClasses
{
    /// <summary>
    /// Business class for grade object
    /// </summary>
    public class Grade : BusinessBase
    {
        #region Fields

        private GradeRepository gradeRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Grade() : base()
        {
            gradeRepository = new GradeRepository(StudentGradingContext);
        }

        #endregion

        #region Business Logic Methods

        /// <summary>
        /// Method to check if a grade exists for a student
        /// </summary>
        /// <param name="courseId">The course id</param>
        /// <param name="studentId">The student id</param>
        /// <returns>True if there is a grade for the student</returns>
        public async Task<bool> DoesGradeExistAsync(int courseId, int studentId)
        {

            var doesGradeExist = false;

            try
            {
                doesGradeExist = await Task.Run(() => gradeRepository.DoesGradeExist(studentId, courseId));
            }
            catch (Exception ex)
            {

            }

            return doesGradeExist;
        }

        /// <summary>
        /// Method to add a grade for a student
        /// </summary>
        /// <param name="studentId">The student Id</param>
        /// <param name="courseId">The course Id</param>
        /// <param name="grade">The letter grade</param>
        /// <returns>True if the grade was added for the student</returns>
        public async Task<bool> AssignGradeToStudentAsync(int studentId, int courseId, string grade)
        {
            var added = false;

            try
            {
                added = await Task.Run((() => gradeRepository.AssignGradeToStudent(studentId, courseId, grade)));
            }

            catch (Exception ex)
            {

            }

            return added;
        }

        /// <summary>
        /// Method to find a student grade record
        /// </summary>
        /// <param name="courseId">The course Id</param>
        /// <param name="studentId">The student Id</param>
        /// <returns>A new gradeModel object if found. Null otherwise</returns>
        public async Task<GradeModel> FindAssignedStudentGradeAsync(int courseId, int studentId)
        {
            var gradeModel = new GradeModel();

            try
            {
                var foundGrade = await Task.Run(() => gradeRepository.FindGrade(courseId, studentId));


                gradeModel = ConvertGradeEntity(foundGrade);
            }
            catch (Exception ex)
            {

            }

            return gradeModel;
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Method to convert a grade entity to a grade model
        /// </summary>
        /// <param name="grade">The grade to convert to</param>
        /// <returns>A GradeModel</returns>
        private GradeModel ConvertGradeEntity(Entities.Grade grade)
        {

            var gradeModel = new GradeModel();

            gradeModel.GradeId = grade.GradeId;
            gradeModel.LetterGrade = grade.LetterGrade;

            //Convert the Course
            if (grade.Course != null)
            {
                gradeModel.Course = new CourseModel()
                {
                    CourseId = grade.Course.CourseId,
                    Name = grade.Course.Name,
                    Description = grade.Course.Description
                };
            }

            //Convert the Student
            if (grade.Student != null)
            {
                gradeModel.Student = new StudentModel()
                {
                    StudentId = grade.Student.StudentId,
                    FirstName = grade.Student.FirstName,
                    LastName = grade.Student.LastName
                };
            }

            return gradeModel;
        }
        #endregion 
    }
}
