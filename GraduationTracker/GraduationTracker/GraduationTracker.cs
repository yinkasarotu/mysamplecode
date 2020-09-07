﻿using GraduationTracker.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace GraduationTracker
{
    public partial class GraduationTracker : IGraduationTracker
    {
        IRepository _appIRepository;
        public GraduationTracker()
        {
            IUnityContainer container = UnityCommon.GetContainer();
            _appIRepository = container.Resolve<IRepository>();
        }

        public Tuple<bool, STANDING> HasGraduated(Diploma diploma, Student student)
        {
            var credits = 0;
            var average = 0;

            for (int i = 0; i < diploma.Requirements.Length; i++)
            {
                for (int j = 0; j < student.Courses.Length; j++)
                {
                    var requirement = _appIRepository.GetRequirement(diploma.Requirements[i]);


                    for (int k = 0; k < requirement.Courses.Length; k++)
                    {
                        if (requirement.Courses[k] == student.Courses[j].Id)
                        {
                            average += student.Courses[j].Mark;
                            if (student.Courses[j].Mark > requirement.MinimumMark)
                            {
                                credits += requirement.Credits;
                            }
                        }
                    }
                }
            }

            average = average / student.Courses.Length;
            return GetStanding(average);


        }


        Tuple<bool, STANDING> GetStanding(decimal average = 0.0m)
        {
            var standing = STANDING.None;

            if (average < 50)
                standing = STANDING.Remedial;
            else if (average < 80)
                standing = STANDING.Average;
            else if (average < 95)
                standing = STANDING.MagnaCumLaude;
            else
                standing = STANDING.MagnaCumLaude;
            switch (standing)
            {
                case STANDING.Remedial:
                    return new Tuple<bool, STANDING>(false, standing);
                case STANDING.Average:
                    return new Tuple<bool, STANDING>(true, standing);
                case STANDING.SumaCumLaude:
                    return new Tuple<bool, STANDING>(true, standing);
                case STANDING.MagnaCumLaude:
                    return new Tuple<bool, STANDING>(true, standing);

                default:
                    return new Tuple<bool, STANDING>(false, standing);
            }
        }



    }
}
