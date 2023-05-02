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
    public class JobSeekerController : ControllerBase
    {
        private readonly IJobSeeker context1;
        public JobSeekerController(IJobSeeker context1)
        {
            this.context1 = context1;
        }
        [HttpPost]
        [Route("ADDPROFILE")] //delete the spaces for routing names
        public ResponseModel AddProfile(JobSeekerModel data)
        {
            try
            {
                if (data != null)
                {
                    var response1 = context1.AddProfile(data);
                    ResponseModel responseModel = new ResponseModel();

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
        [Route("DELETEPROFILE")]
        public ResponseModel DeleteProfile(int personId)
        {
            try
            {
                if (personId != null)
                {
                    var reponse2 = context1.DeleteProfile(personId);
                    ResponseModel responseModel = new ResponseModel();
                    responseModel.Response = reponse2;
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
        [Route("UPDATEPROFILE")]
        public ResponseModel EditProfile(string personId, JobSeekerModel data)
        {
            try
            {
                if (personId != null)
                {
                    var response3 = context1.EditProfile(personId, data);
                    ResponseModel responseModel = new ResponseModel();

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
        [Route("admin/Profile")]
        public IEnumerable<JobSeekerModel> ViewProfile()
        {
            try
            {
                var response = context1.ViewProfile();
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        
    }
}
