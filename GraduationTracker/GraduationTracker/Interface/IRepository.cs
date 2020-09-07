using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker.Interface
{
    public interface IRepository
    {
        Student GetStudent(int id);
        Diploma GetDiploma(int id);

        Requirement GetRequirement(int id);
        Requirement[] GetRequirements();

    }
}
