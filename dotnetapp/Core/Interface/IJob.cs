using dotnetapp.Models;
using System.Collections.Generic;

namespace dotnetapp.Core.Interface
{
    public interface IJob
    {
        string addJob(JobModel data);
        string editJob(string jobId, JobModel data);
        IEnumerable<JobModel> getJob();
        string deleteJob(int jobId);
    }
}
