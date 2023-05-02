using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using dotnetapp.Context;
using dotnetapp.Core.Interface;
using dotnetapp.Models;

namespace dotnetapp.Core
{
    public class Job :IJob
    {
        private readonly yogaTrainerContext _context;
        public Job(yogaTrainerContext context)
        {
            _context = context;
        }
        public string addJob(JobModel data)
        {
            try
            {
                if (data != null)
                {
                    _context.jobModels.Add(data);
                    _context.SaveChanges();
                    return "JOB CREATED";
                }
                else
                {
                    return "Give Me Proper Data";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }



        public string deleteJob(int jobId)
        {
            try
            {
                var del = _context.jobModels.Find(jobId);
                if (del != null)
                {
                    _context.jobModels.Remove(del);
                    _context.SaveChanges();
                    return $"REMOVE {del.JobId}";

                }
                return "Invaild Id,Please check it and come back";
            }
            catch (Exception)
            {
                throw;
            }
        }



        public string editJob(string jobId, JobModel data)
        {
            try
            {
                if (data != null)
                {
                    if (data.JobId == null)
                    {
                        return "ID MUST NOT BE IN 0";
                    }
                    var e = _context.jobModels.Find(data.JobId);
                    if (e != null)
                    {
                        e.JobDescription = data.JobDescription;
                        e.JobLocation = data.JobLocation;
                        e.FromDate = data.FromDate;
                        e.ToDate = data.ToDate;
                        e.WagePerDay = data.WagePerDay;
                        _context.Update(e);
                        _context.SaveChanges();
                        return "UPDATED SUCCESSFULLY";
                    }
                    else
                    {
                        return "Enter Valid Value";
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



        public IEnumerable<JobModel> getJob()
        {
            try
            {
                return _context.jobModels.ToList();
            }
            catch (Exception)
            {



                throw;
            }
        }


      
    }
}
