﻿using Repitition_Task.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repitition_Task.Repostories;

public interface IStudntRepostory
{
    Guid WriteStudent(Student student);
    List<Student> ReadAllStudents();
    void RemoveStudent(Guid studentId);
    Student GetStudentById(Guid studentId);
    void UpdateStudent(Student student);
}
