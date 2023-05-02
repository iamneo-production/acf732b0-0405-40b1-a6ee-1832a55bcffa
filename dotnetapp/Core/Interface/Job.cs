using dotnetapp.Context;
using dotnetapp.Core.Interface;
using dotnetapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dotnetapp.Core
{
    public class Job : IJob
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
                    return $"REMOVE {del.jobId}";
                   
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
                    if (data.jobId == null)
                    {
                        return "ID MUST NOT BE IN 0";
                    }
                    var e = _context.jobModels.Find(data.jobId);
                    if (e != null)
                    {
                        e.jobDescription = data.jobDescription;
                        e.jobLocation = data.jobLocation;
                        e.fromDate = data.fromDate;
                        e.toDate = data.toDate;
                        e.wagePerDay = data.wagePerDay;
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
