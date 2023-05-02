using Microsoft.AspNetCore.Mvc;
using dotnetapp;
using dotnetapp.Models;
using System.Collections.Generic;
using dotnetapp.Core;
using System;

namespace dotnetapp.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class JobController : ControllerBase
    {
        private readonly Job _job;
        public JobController(Job job) 
        {
            _job = job;
        }
        [HttpPost]
        [Route("ADD JOB")]
        public ResponseModel addJob(JobModel data)
        {
            try
            {
                if (data != null)
                {
                    var res1 = _job.addJob(data);
                    ResponseModel responseModel = new ResponseModel();
                    responseModel.Response = res1;
                    responseModel.Message = "Successfully Added";
                    responseModel.Status = true;
                    return responseModel;
                }
                else
                {
                    ResponseModel responseModel = new ResponseModel();
                    responseModel.ErrorMessage = "Not Added,Please Enter the data Properly";
                    responseModel.Status = false;
                    return responseModel;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpDelete]
        [Route("DELETE JOB")]
        public ResponseModel deleteJob(int jobId)
        {
            try
            {
                if (jobId != null)
                {
                    var reponse = _job.deleteJob(jobId);
                    ResponseModel responseModel = new ResponseModel();
                   // responseModel.Response = reponse;
                    responseModel.Message = "Deleted Successfully";
                    responseModel.Status = true;
                    return responseModel;

                }
                else
                {
                    ResponseModel responseModel = new ResponseModel();
                    responseModel.ErrorMessage = "Invaild ID,Please Check";
                    responseModel.Status = false;
                    return responseModel;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPut]
        [Route("UPDATE JOB")]
        public ResponseModel editJob(string jobId, JobModel data)
        {
            try
            {
                if (jobId != null)
                {
                    var response1 = _job.editJob(jobId, data);
                    ResponseModel responseModel = new ResponseModel();
                    responseModel.Response = response1;
                    responseModel.Message = "Updated Successfully";
                    responseModel.Status = true;
                    return responseModel;
                }
                else
                {
                    ResponseModel responseModel = new ResponseModel();
                    responseModel.ErrorMessage = "Invaild ID,Please Check";
                    responseModel.Status = false;
                    return responseModel;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        [Route("READ JOB")]
        public IEnumerable<JobModel> getJob()
        {
            try
            {

                var res4 = _job.getJob();
                return res4;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
