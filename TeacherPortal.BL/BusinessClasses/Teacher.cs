using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherPortal.UI.Models.Models;

namespace TeacherPortal.BL.BusinessClasses
{
    /// <summary>
    /// Business class to represent a teacher
    /// </summary>
    public class Teacher : BusinessBase
    {

        #region Field

        /// <summary>
        /// Field for the repository 
        /// </summary>
        private readonly TeacherRepository teacherRepository;

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Teacher() : base()
        {
            teacherRepository = new TeacherRepository(StudentGradingContext);
        }

        #endregion

        #region Business Logic Methods

        /// <summary>
        /// Method to Add a teacher to the database
        /// </summary>
        /// <param name="teacher">The teacher to be added</param>
        /// <returns>true if the teacher was added</returns>
        public async Task<bool> AddTeacherAsync(TeacherModel teacher)
        {
            var added = true;


            try
            {
                var convertedTeacher = CreateTeacherEnitity(teacher);
                await Task.Run(() => teacherRepository.Add(convertedTeacher));
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
        /// <returns>A teacher if found. Null otherwise</returns>
        public async Task<TeacherModel> FindTeacherAsync(int id)
        {
            var teacher = new TeacherModel();
            try
            {
                //find the teacher
                var foundTeacher = await Task.Run(() => teacherRepository.GetId(id));

                if (foundTeacher != null)
                {
                    //add teacherId if found
                    if (foundTeacher.TeacherId != 0)
                        teacher.TeacherId = foundTeacher.TeacherId;

                    teacher.FirstName = foundTeacher.FirstName;
                    teacher.LastName = foundTeacher.LastName;
                }
            }
            catch (Exception ex)
            {

            }

            return teacher;
        }

        /// <summary>
        /// Method to delete a teacher
        /// </summary>
        /// <param name="teacherId">The student to be deleted</param>
        /// <returns>True if the teacher was Deleted</returns>
        public async Task<bool> DeleteTeacherAsync(int teacherId)
        {
            var deleted = true;

            try
            {
                await Task.Run(() => teacherRepository.DeleteTeacher(teacherId));
            }
            catch (Exception ex)
            {
                deleted = false;
            }

            return deleted;
        }

        /// <summary>
        /// Method to Update a teacher
        /// </summary>
        /// <param name="teacher">The teacher to update</param>
        /// <returns>True if the student was updated</returns>
        public async Task<bool> UpdateTeacherAsync(TeacherModel teacher)
        {
            var updated = true;

            try
            {
                var convertedTeacher = CreateTeacherEnitity(teacher);
                await Task.Run(() => teacherRepository.Update(convertedTeacher));
            }
            catch (Exception ex)
            {
                updated = false;
            }

            return updated;
        }

        /// <summary>
        /// Method to get all teachers
        /// </summary>
        /// <returns>A list of all teachers</returns>
        public async Task<List<TeacherModel>> GetAllTeacherAsync()
        {
            List<TeacherModel> teacherList = new List<TeacherModel>();

            try
            {
                var allTeachers = await Task.Run(() => teacherRepository.GetAll());

                teacherList = (from teacher in allTeachers
                               select new TeacherModel()
                               {
                                   TeacherId = teacher.TeacherId,
                                   FirstName = teacher.FirstName,
                                   LastName = teacher.LastName,
                                   FullName = teacher.FirstName + " " + teacher.LastName 

                               }).ToList<TeacherModel>();

            }

            catch (Exception ex)
            {

            }

            return teacherList;
        }



        /// <summary>
        /// Method to check if a teacher is registered
        /// </summary>
        /// <param name="teacher">The teacher to check</param>
        /// <returns>True if the teacher is registered</returns>
        public async Task<bool> IsRegisteredAsync(TeacherModel teacher)
        {
            var isRegistered = false;
            try
            {
                var foundTeacher = await FindTeacherAsync(teacher.TeacherId);

                //teacher is found the id matched and first and last names match
                if (foundTeacher != null && foundTeacher.FirstName == teacher.FirstName && foundTeacher.LastName == teacher.LastName)
                    isRegistered = true;

            }
            catch (Exception ex)
            {

            }

            return isRegistered;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Method to convert a teacher to an teacher entity
        /// </summary>
        /// <param name="teacher">The teacher to convert</param>
        /// <returns>A teacher entity object</returns>
        private Entities.Teacher CreateTeacherEnitity(TeacherModel teacher)
        {
            var convertedTeacher = new Entities.Teacher();

            if (teacher != null)
            {
                //add if the teacherId is not 0
                if (teacher.TeacherId != 0)
                    convertedTeacher.TeacherId = teacher.TeacherId;

                convertedTeacher.FirstName = teacher.FirstName;
                convertedTeacher.LastName = teacher.LastName;
            }
            return convertedTeacher;
        }

        #endregion
    }
}

