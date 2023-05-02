using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using dotnetapp.Context;
using dotnetapp.Core.Interface;
using dotnetapp.Models;

namespace dotnetapp.Core
{
    public class JobSeeker : IJobSeeker
    {
        private readonly yogaTrainerContext yogaTrainerContext;
        public JobSeeker(yogaTrainerContext yogaTrainerContext)
        {
            this.yogaTrainerContext = yogaTrainerContext;
        }
        public string AddProfile(JobSeekerModel data)
        {
            try
            {
                if (data != null)
                {
                    yogaTrainerContext.jobSeekers.Add(data);
                    yogaTrainerContext.SaveChanges();
                    return "PROFILE ADDED";
                }
                else
                {
                    return "Error";
                }
            }
            catch (Exception)
            {



                throw;
            }
        }
        public string DeleteProfile(int personId)
        {
            try
            {
                var d = yogaTrainerContext.jobSeekers.Find(personId);
                if (d != null)
                {
                    yogaTrainerContext.jobSeekers.Remove(d);
                    yogaTrainerContext.SaveChanges();
                    return $"REMOVE {d.PersonName}";
                }
                return "Error";
            }
            catch
            {
                return "Error";
            }



        }
        public string EditProfile(string personId, JobSeekerModel data)
        {
            try
            {
                if (data != null)
                {
                    if (data.PersonId == null)
                    {
                        return "ID MUST NOT BE IN O";
                    }
                    var u = yogaTrainerContext.jobSeekers.Find(data.PersonId);
                    if (u != null)
                    {
                        u.PersonName = data.PersonName;
                        u.JobAdress = data.JobAdress;
                        u.PersonExp = data.PersonExp;
                        u.Phone = data.Phone;
                        u.Email = data.Email;
                        yogaTrainerContext.Update(u);
                        yogaTrainerContext.SaveChanges();
                        return "UPDATE SUCCESSFULLY";
                    }
                    else
                    {
                        return "Error";
                    }
                }
                else
                {
                    throw new Exception("ENTER THE VALID VALUE");
                }
            }
            catch (Exception)
            {



                throw;
            }
        }
        public IEnumerable<JobSeekerModel> ViewProfile()
        {
            try
            {
                return yogaTrainerContext.jobSeekers.ToList();



            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
