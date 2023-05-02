using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using dotnetapp.Context;
using dotnetapp.Models;
using dotnetapp.Core.Interface;

namespace dotnetapp.Core
{
    public class JobSeeker : ControllerBase
    {
        private readonly yogaTrainerContext yogaTrainerContext;
        public JobSeeker(yogaTrainerContext yogaTrainerContext)
        {
            this.yogaTrainerContext = yogaTrainerContext;
        }
        public string AddProfile(jobSeekerModel data)
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
        public string DeleteProfile(string personId)
        {
            try
            {
                var d = yogaTrainerContext.jobSeekers.Find(personId);
                if (d != null)
                {
                    yogaTrainerContext.jobSeekers.Remove(d);
                    yogaTrainerContext.SaveChanges();
                    return $"REMOVE {d.personName}";
                }
                return "Error";
            }
            catch
            { 
                return "Error";
            }

        }
        public string EditProfile(string personId, jobSeekerModel data)
        {
            try
            {
                if (data != null)
                {
                    if (data.personId == null)
                    {
                        return "ID MUST NOT BE IN O";
                    }
                    var u = yogaTrainerContext.jobSeekers.Find(data.personId);
                    if (u != null)
                    {
                        u.personName = data.personName;
                        u.personAddress = data.personAddress;
                        u.personExp = data.personExp;
                        u.personPhone = data.personPhone;
                        u.PersonEmail = data.PersonEmail;
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
        public IEnumerable<jobSeekerModel> ViewProfile()
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
