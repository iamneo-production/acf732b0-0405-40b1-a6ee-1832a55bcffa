using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using dotnetapp.Core;
using dotnetapp.Core.Interface;
using dotnetapp.Models;

namespace dotnetapp.Controllers
{
    [ApiController]
    //[Route("api/[Controller]")]
    public class JobController : ControllerBase
    {
        private readonly IJob _job;
        public JobController(IJob job)
        {
            _job = job;
        }
        [HttpPost]
        [Route("ADDJOB")]
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
        [Route("DELETEJOB")]
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
        [Route("UPDATEJOB")]
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
        [Route("admin/getAlljobs")]
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
